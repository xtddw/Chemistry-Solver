namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing an element.
    /// </summary>
    public class Element
    {
        private int atomic_number_;
        public int AtomicNumber { get { return atomic_number_; } private set { atomic_number_ = value; } }

        private double molar_mass_;
        public double MolarMass { get { return molar_mass_; } private set { molar_mass_ = value; } }

        private string name_;
        public string Name { get { return name_; } private set { name_ = value; } }

        private string symbol_;
        public string Symbol { get { return symbol_; } private set { symbol_ = value; } }

        private System.Drawing.Point location_;
        public System.Drawing.Point Location{ get { return location_; } private set { location_ = value; } }

        /// <summary>
        /// Constructs a new element.
        /// </summary>
        /// <param name="atomic_number">The atomic number of the element.</param>
        /// <param name="name">The name of the element.</param>
        /// <param name="symbol">The elements symbol.</param>
        /// <param name="molar_mass">The molar mass of the element.</param>
        public Element(int atomic_number, string name, string symbol, double molar_mass, System.Drawing.Point location)
        {
            AtomicNumber = atomic_number;
            Name = name;
            MolarMass = molar_mass;
            Symbol = symbol;
            location_ = new System.Drawing.Point(location.X, location.Y);
        }

        /// <summary>
        /// Converts the element into a string.
        /// </summary>
        /// <returns>A string representation of the Element.</returns>
        public override string ToString()
        {
            return string.Format("Name: {0}\nAtomic Number: {1}\nSymbol: {2}\nMolar Mass: {3}\nLocation: {4}, {5}", this.Name, this.AtomicNumber, this.Symbol, this.MolarMass, this.Location.X, this.Location.Y);
        }

        /// <summary>
        /// Compares the equality between two elements.
        /// </summary>
        /// <param name="element">The element to check equality against.</param>
        /// <returns>A boolean value stating the equality of the elements.</returns>
        public bool Equals(Element element)
        {
            var result = false;

            if(this.Name == element.Name
                && this.MolarMass == element.MolarMass
                && this.AtomicNumber == element.AtomicNumber)
            {
                result = true;
            }

            return result;
        }
    }
}