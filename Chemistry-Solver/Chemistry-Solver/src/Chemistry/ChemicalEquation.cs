using BSmith.Math;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class that represents a chemical equation.
    /// </summary>
    public class ChemicalEquation
    {
        private List<ParticleQuantityPair<Molecule, int>> reactants_;
        public List<ParticleQuantityPair<Molecule, int>> Reactants { get { return reactants_; } set { reactants_ = value; } }

        private List<ParticleQuantityPair<Molecule, int>> products_;
        public List<ParticleQuantityPair<Molecule, int>> Products { get { return products_; } set { products_ = value; } }

        /// <summary>
        /// Constructs an empty Chemical Equation.
        /// </summary>
        public ChemicalEquation()
        {
            reactants_ = new List<ParticleQuantityPair<Molecule, int>>();
            products_ = new List<ParticleQuantityPair<Molecule, int>>();
        }

        /// <summary>
        /// Constructs a new ChemicalEquation with the values from another.
        /// </summary>
        /// <param name="equation">The equation to pull values from.</param>
        public ChemicalEquation(ChemicalEquation equation)
        {
            reactants_ = new List<ParticleQuantityPair<Molecule, int>>();
            reactants_.AddRange(equation.Reactants);

            products_ = new List<ParticleQuantityPair<Molecule, int>>();
            products_.AddRange(equation.Products);
        }

        /// <summary>
        /// Gets the unique elements from one side of a ChemicalEquation.
        /// </summary>
        /// <param name="element_pairs">A list of molecules.</param>
        /// <returns>The unique elements from the supplied molecules.</returns>
        private List<ParticleQuantityPair<Element, int>> GetUniqueElements(List<ParticleQuantityPair<Molecule, int>> element_pairs)
        {
            var unique_elements = new List<ParticleQuantityPair<Element, int>>();

            for (var molecule_index = 0; molecule_index < element_pairs.Count; ++molecule_index)
            {
                for (var element_index = 0; element_index < element_pairs[molecule_index].Particle.Elements.Count; ++element_index)
                {
                    var match = unique_elements.Find(element => element.Particle.Equals(element_pairs[molecule_index].Particle.Elements[element_index].Particle));

                    if (match == null)
                    {
                        var element = new ParticleQuantityPair<Element, int>(
                            element_pairs[molecule_index].Particle.Elements[element_index].Particle,
                            element_pairs[molecule_index].Particle.Elements[element_index].Quantity * element_pairs[molecule_index].Quantity);

                        unique_elements.Add(element);
                    }
                    else
                    {
                        match.Quantity += (element_pairs[molecule_index].Particle.Elements[element_index].Quantity * element_pairs[molecule_index].Quantity);
                    }
                }
            }

            return unique_elements;
        }

        /// <summary>
        /// Checks to see if the ChemicalEquation is balanced.
        /// </summary>
        /// <param name="equation">The equation to check.</param>
        /// <returns>A boolean value indicating whether or not the equation is balanced.</returns>
        public bool IsBalanced()
        {
            var reactant_elements = GetUniqueElements(Reactants);
            var product_elements = GetUniqueElements(Products);
            var equality_count = 0;

            // Check equality between counted elements
            if (reactant_elements.Count == product_elements.Count)
            {
                foreach (var element_pair in reactant_elements)
                {
                    for (var element_index = 0; element_index < product_elements.Count; ++element_index)
                    {
                        if (element_pair.Particle.Equals(product_elements[element_index].Particle)
                            && element_pair.Quantity == product_elements[element_index].Quantity)
                        {
                            ++equality_count;
                        }
                    }
                }
            }

            return (equality_count != 0 && equality_count == reactant_elements.Count) ? true : false;
        }

      
        /// <summary>
        /// Balances a ChemicalEquation.
        /// </summary>
        public void Balance()
        {
            if (Products.Count != 0
                && Reactants.Count != 0
                && !IsBalanced())
            {
                var elements = GetUniqueElements(Reactants);
                var molecules = new List<ParticleQuantityPair<Molecule, int>>();
                molecules.AddRange(Reactants);
                molecules.AddRange(Products);

                var matrix = new Matrix(elements.Count, molecules.Count);

                // Populate matrix data with element amounts.
                for (var row_index = 0; row_index < matrix.Data.GetLength(0); ++row_index)
                {
                    for (var col_index = 0; col_index < matrix.Data.GetLength(1); ++col_index)
                    {
                        var element_match = molecules[col_index].Particle.Elements.Find(element_pair => element_pair.Particle.Equals(elements[row_index].Particle));

                        if (element_match != null)
                        {
                            var product_scalar = (col_index >= Reactants.Count) ? -1 : 1;
                            var element_coefficient = new Fraction(element_match.Quantity);

                            element_coefficient = Fraction.Multiply(element_coefficient, product_scalar);
                            matrix.Data[row_index, col_index] = Fraction.Add(matrix.Data[row_index, col_index], element_coefficient);
                        }
                    }
                } 

                // Solve the matrix.
                var X = Matrix.Submatrix(matrix, new[] { 0, matrix.Data.GetLength(0) - 1 }, new[] { 0, matrix.Data.GetLength(1) - 2 });
                var Y = Matrix.Submatrix(matrix, new[] { 0, matrix.Data.GetLength(0) - 1 }, new[] { matrix.Data.GetLength(1) - 1, matrix.Data.GetLength(1) - 1 });

                var XtX = Matrix.Multiply(Matrix.Transpose(X), X);
                var XtY = Matrix.Multiply(Matrix.Transpose(X), Y);

                var solution_mat = Matrix.Multiply(Matrix.Inverse(XtX), XtY);

                var molecule_coefficients = new Fraction[molecules.Count];
                double LCM = 1.00;


                // Create solution vector.
                for (var i = 0; i < molecule_coefficients.Length; ++i)
                {
                    if (i < solution_mat.Data.GetLength(0))
                    {
                        molecule_coefficients[i] = Functions.Abs(solution_mat.Data[i, 0]);
                        LCM = Functions.LeastCommonMultiple(molecule_coefficients[i].Denominator, (long)LCM);
                    }
                    else
                    {
                        molecule_coefficients[i] = new Fraction(1);
                    }
                }

                // Normalize values.
                for (var i = 0; i < molecule_coefficients.Length; ++i)
                {
                    var multiple = (LCM / molecule_coefficients[i].Denominator);
                    molecule_coefficients[i] = Math.Fraction.Multiply(molecule_coefficients[i], new Math.Fraction((int)multiple * (int)LCM, (int)multiple), true);

                    if (i < Reactants.Count)
                    {
                        Reactants[i].Quantity = (int)molecule_coefficients[i].Approximate();
                    }
                    else
                    {
                        Products[System.Math.Abs(Reactants.Count - i)].Quantity = (int)molecule_coefficients[i].Approximate();
                    }
                }
            }
        }

        /// <summary>
        /// Creates a molecule from a properly formatted string.
        /// </summary>
        /// <param name="input">The molecule to create.</param>
        /// <returns>A molecule.</returns>
        public static Molecule CreateMolecule(string input)
        {
            var ptable = new PeriodicTable();
            ptable.LoadData("..\\..\\data\\ElementData.csv");

            var molecule = new Molecule();
            var elements = Regex.Matches(input, @"[A-Z]{1}[a-z]{0,2}");
            var subscripts = Regex.Matches(input, @"\b\d{1,}\b");

            for (var i = 0; i < elements.Count; ++i)
            {
                var element = ptable.FindElementBySymbol(elements[i].Value);
                var element_count = 0;
                int.TryParse(subscripts[i].Value, out element_count);

                molecule.Elements.Add(new ParticleQuantityPair<Element, int>(element, element_count));
            }

            return molecule;
        }

        /// <summary>
        /// Interprets a properly formatted string to create a chemical equation.
        /// </summary>
        /// <param name="equation">The equation to interpret.</param>
        /// <returns>A chemical equation.</returns>
        public static ChemicalEquation InterpretEquation(string equation)
        {
            var chemical_equation = new ChemicalEquation();

            var molecules = Regex.Matches(equation, @"([^+>\-\s]{1,}){1,}");
            var arrow_separator = Regex.Matches(equation, @"[-]{2}[>]{1}");
            var elements = Regex.Matches(equation, @"[A-Z]{1}[a-z]{0,2}");
            var subscripts = Regex.Matches(equation, @"\b\d{1,}\b");

            if (elements.Count == subscripts.Count)
            {
                if (arrow_separator.Count == 0) // Only reactants present
                {
                    var reactants = new List<ParticleQuantityPair<Molecule, int>>();

                    foreach (Match molecule in molecules)
                    {
                        reactants.Add(new ParticleQuantityPair<Molecule, int>(CreateMolecule(molecule.Value), 1));
                    }

                    chemical_equation.Reactants = reactants;
                }
                else if (arrow_separator.Count == 1) // Reactants and produts present
                {

                    var reactants = new List<ParticleQuantityPair<Molecule, int>>();
                    var products = new List<ParticleQuantityPair<Molecule, int>>();

                    for (var i = 0; i < molecules.Count; ++i)
                    {
                        // Reactants
                        if (molecules[i].Index < arrow_separator[0].Index)
                        {
                            reactants.Add(new ParticleQuantityPair<Molecule, int>(CreateMolecule(molecules[i].Value), 1));
                        }
                        else // Products
                        {
                            products.Add(new ParticleQuantityPair<Molecule, int>(CreateMolecule(molecules[i].Value), 1));
                        }
                    }

                    chemical_equation.Reactants = reactants;
                    chemical_equation.Products = products;
                }
            }

            return chemical_equation;
        }

        /// <summary>
        /// Converts the ChemicalEquation into a string.
        /// </summary>
        /// <returns>A string representation of the ChemicalEquation.</returns>
        public override string ToString()
        {
            string output = string.Empty;

            for (int reactants_index = 0; reactants_index < reactants_.Count; ++reactants_index)
            {
                output += reactants_[reactants_index].Quantity + reactants_[reactants_index].Particle.ToString();
                output += (reactants_index < reactants_.Count - 1) ? " + " : string.Empty;
            }

            if (products_.Count != 0)
            {
                output += " --> ";
            }

            for (int products_index = 0; products_index < products_.Count; ++products_index)
            {
                output += products_[products_index].Quantity + products_[products_index].Particle.ToString();
                output += (products_index < products_.Count - 1) ? " + " : string.Empty;
            }

            return output;
        }
    }
}