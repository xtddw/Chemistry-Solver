using System;
using System.Collections.Generic;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing a molecule.
    /// </summary>
    public class Molecule
    {
        /// <summary>
        /// A collection of <see cref="Tuple{T1, T2}"/> that represent the elements and their quantities found in the molecule.
        /// </summary>
        public List<Tuple<Element, int>> Elements { get; private set; } = new List<Tuple<Element, int>>();

        /// <summary>
        /// Constructs an empty Molecule.
        /// </summary>
        public Molecule() { }

        /// <summary>
        /// Calculates the molecule's molar mass.
        /// </summary>
        /// <returns>The molecule's molar mass.</returns>
        public double MolarMass()
        {
            var molar_mass = 0.0;

            for (int element_index = 0; element_index < Elements.Count; ++element_index)
            {
                molar_mass += Elements[element_index].Item1.MolarMass * Elements[element_index].Item2;
            }

            return molar_mass;
        }

        /// <summary>
        /// Converts the Molecule into a string.
        /// </summary>
        /// <returns>A string representation of the Molecule.</returns>
        public override string ToString()
        {
            string output = string.Empty;

            foreach (Tuple<Element, int> atom in Elements)
            {
                output += atom.Item1.Symbol + "_(" + atom.Item2 + ")";
            }

            return output;
        }
    }
}
