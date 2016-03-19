using System;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing a stoichiometric value.
    /// </summary>
    public class Value
    {
        /// <summary>
        /// A numeric value representing the quantity of the substance that appears in a stoichiometric <see cref="Value"/>.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// The units that are associated with a stoichiometric <see cref="Value"/>.
        /// </summary>
        public string Units { get; set; }

        /// <summary>
        /// The susbstance that's apart of a stoichiometric <see cref="Value"/>.
        /// </summary>
        public Tuple<Molecule, int> Substance { get; set; }

        /// <summary>
        /// Constructs a new <see cref="Value"/>.
        /// </summary>
        /// <param name="amount">The amount of a substance, relative to its units.</param>
        /// <param name="units">The units of the substance.</param>
        /// <param name="substance">A <see cref="Tuple{T1, T2}"/> representing the molecule.</param>
        public Value(double amount, string units, Tuple<Molecule, int> substance)
        {
            Amount = amount;
            Units = units;
            Substance = substance;
        }

        /// <summary>
        /// Constructs an empty <see cref="Value"/>.
        /// </summary>
        public Value()
        {
            Amount = 0.0;
            Units = string.Empty;
            Substance = Tuple.Create(new Molecule(), 0);
        }

        /// <summary>
        /// Constructs a new <see cref="Value"/> from another <see cref="Value"/>.
        /// </summary>
        /// <param name="value"></param>
        public Value(Value value)
        {
            Amount = value.Amount;
            Units = value.Units;
            Substance = value.Substance;
        }

        /// <summary>
        /// Converts a <see cref="Value"/> into a string.
        /// </summary>
        /// <returns>A string representation of a Value.</returns>
        public override string ToString()
        {
            return $"{Amount:F4} {Units} {Substance.Item1}";
        }
    }
}
