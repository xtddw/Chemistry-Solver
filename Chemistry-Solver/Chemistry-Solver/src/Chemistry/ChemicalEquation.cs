using BSmith.Math;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class that represents a chemical equation.
    /// </summary>
    public class ChemicalEquation
    {
        /// <summary>
        /// The reactants found in the <see cref="ChemicalEquation"/>.
        /// </summary>
        public List<Tuple<Molecule, int>> Reactants { get; set; } = new List<Tuple<Molecule, int>>();

        /// <summary>
        /// The products found in the <see cref="ChemicalEquation"/>.
        /// </summary>
        public List<Tuple<Molecule, int>> Products { get; set; } = new List<Tuple<Molecule, int>>();

        /// <summary>
        /// A <see cref="PeriodicTable"/> all chemical equations use to extract element information from.
        /// </summary>
        public static PeriodicTable PTable { get; set; } = null;

        /// <summary>
        /// Constructs an empty Chemical Equation.
        /// </summary>
        public ChemicalEquation() { }

        /// <summary>
        /// Constructs a new <see cref="ChemicalEquation"/> from a string with element information from <paramref name="ptable"/>.
        /// </summary>
        /// <param name="equation">The equation to pull values from.</param>
        /// <param name="ptable">A periodic table to extract element information from.</param>
        public ChemicalEquation(string equation)
        {
            InterpretEquation(equation);
        }

        /// <summary>
        /// Gets the unique elements from one side of a ChemicalEquation.
        /// </summary>
        /// <param name="element_pairs">A list of molecules.</param>
        /// <returns>The unique elements from the supplied molecules.</returns>
        private List<Tuple<Element, int>> GetUniqueElements(List<Tuple<Molecule, int>> element_pairs)
        {
            var unique_elements = new List<Tuple<Element, int>>();

            for (var molecule_index = 0; molecule_index < element_pairs.Count; ++molecule_index)
            {
                for (var element_index = 0; element_index < element_pairs[molecule_index].Item1.Elements.Count; ++element_index)
                {
                    var match = unique_elements.Find(element => element.Item1.Equals(element_pairs[molecule_index].Item1.Elements[element_index].Item1));

                    if (match == null)
                    {
                        var element = Tuple.Create(
                            element_pairs[molecule_index].Item1.Elements[element_index].Item1,
                            element_pairs[molecule_index].Item1.Elements[element_index].Item2 * element_pairs[molecule_index].Item2);

                        unique_elements.Add(element);
                    }
                    else
                    {
                        var matchIndex = unique_elements.IndexOf(match);

                        unique_elements[matchIndex] = Tuple.Create(
                        match.Item1,
                        match.Item2 + (element_pairs[molecule_index].Item1.Elements[element_index].Item2 * element_pairs[molecule_index].Item2));
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
                        if (element_pair.Item1.Equals(product_elements[element_index].Item1)
                            && element_pair.Item2 == product_elements[element_index].Item2)
                        {
                            ++equality_count;
                        }
                    }
                }
            }

            return (equality_count != 0 && equality_count == reactant_elements.Count) ? true : false;
        }
      
        /// <summary>
        /// Balances the <see cref="ChemicalEquation"/>.
        /// </summary>
        public void Balance()
        {
            if (Products.Count != 0
                && Reactants.Count != 0
                && !IsBalanced())
            {
                var elements = GetUniqueElements(Reactants);
                var molecules = new List<Tuple<Molecule, int>>();
                molecules.AddRange(Reactants);
                molecules.AddRange(Products);

                var matrix = new Matrix(elements.Count, molecules.Count);

                // Populate matrix data with element amounts.
                for (var row_index = 0; row_index < matrix.Data.GetLength(0); ++row_index)
                {
                    for (var col_index = 0; col_index < matrix.Data.GetLength(1); ++col_index)
                    {
                        var element_match = molecules[col_index].Item1.Elements.Find(element_pair => element_pair.Item1.Equals(elements[row_index].Item1));

                        if (element_match != null)
                        {
                            var product_scalar = (col_index >= Reactants.Count) ? -1 : 1;
                            var element_coefficient = new Fraction(element_match.Item2);

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
                        Reactants[i] = Tuple.Create(Reactants[i].Item1, (int)molecule_coefficients[i].Approximate());
                    }
                    else
                    {
                        Products[System.Math.Abs(Reactants.Count - i)] = Tuple.Create(
                        Products[System.Math.Abs(Reactants.Count - i)].Item1, 
                        (int)molecule_coefficients[i].Approximate());
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
            var molecule = new Molecule();
            var elements = Regex.Matches(input, @"[A-Z]{1}[a-z]{0,2}");
            var subscripts = Regex.Matches(input, @"\b\d{1,}\b");

            for (var i = 0; i < elements.Count; ++i)
            {
                var element = PTable.FindElementBySymbol(elements[i].Value);
                var element_count = 0;
                int.TryParse(subscripts[i].Value, out element_count);

                molecule.Elements.Add(Tuple.Create(element, element_count));
            }

            return molecule;
        }

        /// <summary>
        /// Interprets a properly formatted string to create a chemical equation.
        /// </summary>
        /// <param name="equation">The equation to interpret.</param>
        /// <returns>A chemical equation.</returns>
        private void InterpretEquation(string equation)
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
                    var reactants = new List<Tuple<Molecule, int>>();

                    foreach (Match molecule in molecules)
                    {
                        reactants.Add(new Tuple<Molecule, int>(CreateMolecule(molecule.Value), 1));
                    }

                    Reactants = reactants;
                }
                else if (arrow_separator.Count == 1) // Reactants and produts present
                {

                    var reactants = new List<Tuple<Molecule, int>>();
                    var products = new List<Tuple<Molecule, int>>();

                    for (var i = 0; i < molecules.Count; ++i)
                    {
                        // Reactants
                        if (molecules[i].Index < arrow_separator[0].Index)
                        {
                            reactants.Add(Tuple.Create(CreateMolecule(molecules[i].Value), 1));
                        }
                        else // Products
                        {
                            products.Add(Tuple.Create(CreateMolecule(molecules[i].Value), 1));
                        }
                    }

                    Reactants = reactants;
                    Products = products;
                }
            }
        }

        /// <summary>
        /// Converts the ChemicalEquation into a string.
        /// </summary>
        /// <returns>A string representation of the ChemicalEquation.</returns>
        public override string ToString()
        {
            string output = string.Empty;

            for (int reactants_index = 0; reactants_index < Reactants.Count; ++reactants_index)
            {
                output += Reactants[reactants_index].Item2 + Reactants[reactants_index].Item1.ToString();
                output += (reactants_index < Reactants.Count - 1) ? " + " : string.Empty;
            }

            if (Products.Count != 0)
            {
                output += " --> ";
            }

            for (int products_index = 0; products_index < Products.Count; ++products_index)
            {
                output += Products[products_index].Item2 + Products[products_index].Item1.ToString();
                output += (products_index < Products.Count - 1) ? " + " : string.Empty;
            }

            return output;
        }
    }
}