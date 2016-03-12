namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing a stoichiometric value.
    /// </summary>
    public class Value
    {      
        private double amount_;
        public double Amount { get { return amount_; } set { amount_ = value; } }

        private string units_;
        public string Units { get { return units_; } set { units_ = value; } }

        private ParticleQuantityPair<Molecule, int> substance_;
        public ParticleQuantityPair<Molecule, int> Substance { get { return substance_; } set { substance_ = value; } }

        /// <summary>
        /// Constructs a new Value.
        /// </summary>
        /// <param name="amount">The amount of a substance, relative to its units.</param>
        /// <param name="units">The units of the substance.</param>
        /// <param name="substance">A partical-quantity pair representing the substance.</param>
        public Value(double amount, string units, ParticleQuantityPair<Molecule, int> substance)
        {
            Amount = amount;
            units_= units;
            Substance = substance;
        }

        /// <summary>
        /// Constructs an empty Value.
        /// </summary>
        public Value()
        {
            Amount = 0.0;
            Units = string.Empty;
            Substance = new ParticleQuantityPair<Molecule, int>(new Molecule(), 0);
        }

        /// <summary>
        /// Constructs a new Value from another Value.
        /// </summary>
        /// <param name="value"></param>
        public Value(Value value)
        {
            Amount = value.Amount;
            Units = value.Units;
            Substance = value.Substance;
        }

        /// <summary>
        /// Converts a Value into a string.
        /// </summary>
        /// <returns>A string representation of a Value.</returns>
        public override string ToString()
        {
            return string.Format("{0:F4} {1} {2}", amount_, units_, substance_.Particle);
        }
    }
}
