namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing an element.
    /// </summary>
    public class Element
    {
        /// <summary>
        /// The element's atomic number.
        /// </summary>
        public int AtomicNumber { get; private set; }

        /// <summary>
        /// The element's molar mass.
        /// </summary>
        public double MolarMass { get; private set; }

        /// <summary>
        /// The element's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The element's symbol.
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Constructs a new element.
        /// </summary>
        /// <param name="atomic_number">The atomic number of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="symbol">The elements symbol.</param>
        /// <param name="molar_mass">The molar mass of the element.</param>
        public Element(int atomic_number, string name, string symbol, double molar_mass)
        {
            AtomicNumber = atomic_number;
            Name = name;
            MolarMass = molar_mass;
            Symbol = symbol;
        }

        /// <summary>
        /// Converts the element into a string.
        /// </summary>
        /// <returns>A string representation of the Element.</returns>
        public override string ToString()
        {
            return $"Name: {Name}\nAtomic Number: {AtomicNumber} | \nSymbol: {Symbol}\n Molar Mass: {MolarMass}";
        }

        /// <summary>
        /// Compares the equality between two elements.
        /// </summary>
        /// <param name="element">The element to check equality against.</param>
        /// <returns>A boolean value stating the equality of the elements.</returns>
        public bool Equals(Element element)
        {
            var result = false;

            if(Name == element.Name
                && MolarMass == element.MolarMass
                && AtomicNumber == element.AtomicNumber)
            {
                result = true;
            }

            return result;
        }
    }
}