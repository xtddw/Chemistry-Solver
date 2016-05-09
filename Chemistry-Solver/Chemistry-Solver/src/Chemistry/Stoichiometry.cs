using System;
using System.Linq;
using System.Collections.Generic;
using BSmith.ChemistrySolver.Utility;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class providing stoichiometry functionality.
    /// </summary>
    public class Stoichiometry
    {
        public UnitConversion UnitConverter { get; } = new UnitConversion();

        /// <summary>
        /// Constructs a new Stoichiometry object.
        /// </summary>
        public Stoichiometry() { }

        /// <summary>
        /// Creates a scalar value based on the relationship between the <paramref name="molecule"/> and it's units.
        /// </summary>
        /// <param name="molecule">The molecule to generate a scalar for.</param>
        /// <returns>The scalar value that</returns>
        private double CalculateIndividualScalar(Tuple<Tuple<Molecule, int>, string> molecule)
        {
            var scalar = 0d;

            if (molecule.Item2.Equals("mass"))
            {
                scalar = molecule.Item1.Item2 * molecule.Item1.Item1.MolarMass();
            }
            else if (molecule.Item2.Equals("moles"))
            {
                scalar = molecule.Item1.Item2;
            }
            else if (molecule.Item2.Equals("particles"))
            {
                //Avogadro's Number
                scalar = 6.022E+23;
            }

            return scalar;
        }
        /// <summary>
        /// Creates a scalar representing the relationship between <paramref name="canceledMolecule"/> and remaining, in the specified units.
        /// </summary>
        /// <param name="canceledMolecule">The molecule and units that will be canceled after conversion.</param>
        /// <param name="remainingMolecule">The molecule and units that will remain after conversion.</param>
        /// <returns>A decimal representing the appropriate conversion value.</returns>
        private double CreateConversionScalar(Tuple<Tuple<Molecule, int>, string> canceledMolecule, Tuple<Tuple<Molecule, int>, string> remainingMolecule)
        {
            var scalar = 0.0;

            if(canceledMolecule != null && remainingMolecule != null)
            {
                scalar = CalculateIndividualScalar(remainingMolecule) / CalculateIndividualScalar(canceledMolecule);
            }

            return scalar;
        }

        private List<Tuple<Tuple<Molecule, int>, string>> CreateConversionInfo(ChemicalEquation equation)
        {
            List<Tuple<Tuple<Molecule, int>, string>> header = null;

            if (equation.IsBalanced())
            {
                header = new List<Tuple<Tuple<Molecule, int>, string>>();

                var combined = equation.Reactants.Concat(equation.Products);

                foreach (var molecule in combined)
                {
                    header.Add(Tuple.Create(molecule, "mass"));
                    header.Add(Tuple.Create(molecule, "moles"));
                    header.Add(Tuple.Create(molecule, "particles"));
                }
            }

            return header;
        }

        public void CreateConversionTable(ChemicalEquation equation)
        {
            var tableData = new List<List<string>>();

            if (equation.IsBalanced())
            {
                var conversionInfo = CreateConversionInfo(equation);
                var columnHeader = conversionInfo.Select(molecule => $"{molecule.Item1.Item2}{molecule.Item1.Item1.ToString()} {molecule.Item2}").ToList();
                tableData.Add(columnHeader);

                // Adds the conversion type of the table.
                tableData[0].Insert(0, equation.ToString());

                for (var rowIndex = 1; rowIndex < columnHeader.Count; ++rowIndex)
                {
                    var rowHeader = columnHeader[rowIndex];

                    if (tableData.Count == rowIndex)
                    {
                        tableData.Add(new List<string>());
                        tableData[rowIndex].Add(rowHeader);
                        tableData[rowIndex].AddRange(new string[rowIndex - 1]);
                    }                 

                    for (var colIndex = rowIndex; colIndex < columnHeader.Count; ++colIndex)
                    {
                        var canceledUnit = conversionInfo[rowIndex - 1];
                        var remainingUnit = conversionInfo[colIndex - 1];
                        var conversionScalar = CreateConversionScalar(canceledUnit, remainingUnit);

                        tableData[rowIndex].Add(conversionScalar.ToString());                       
                    }
                }

                UnitConverter.ConversionTable = UnitConverter.CreateConversionTable(tableData).Transpose();
            }
        }
    }
}
