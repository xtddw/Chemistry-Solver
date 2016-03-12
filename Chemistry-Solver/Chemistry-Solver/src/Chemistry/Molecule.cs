using System.Collections.Generic;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing a molecule.
    /// </summary>
    public class Molecule
    {
        private List<ParticleQuantityPair<Element, int>> elements_;
        public List<ParticleQuantityPair<Element, int>> Elements { get { return elements_; } private set { elements_ = value; } }

        /// <summary>
        /// Constructs an empty Molecule.
        /// </summary>
        public Molecule()
        {
            elements_ = new List<ParticleQuantityPair<Element, int>>();
        }

        /// <summary>
        /// Calculates the molar mass of the molecule.
        /// </summary>
        /// <returns>The molecule's molar mass.</returns>
        public double MolarMass()
        {
            var molar_mass = 0.0;

            for (int element_index = 0; element_index < elements_.Count; ++element_index)
            {
                molar_mass += elements_[element_index].Particle.MolarMass * elements_[element_index].Quantity;
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

            foreach (ParticleQuantityPair<Element, int> atom in elements_)
            {
                output += atom.Particle.Symbol + "_(" + atom.Quantity + ")";
            }

            return output;
        }
    }
}
