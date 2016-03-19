﻿namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing a ratio of Values.
    /// </summary>
    public class Ratio
    {
        /// <summary>
        /// The numerator of the ratio.
        /// </summary>
        public Value Numerator { get; set; }

        /// <summary>
        /// The denominator of the ratio.
        /// </summary>
        public Value Denominator { get; set; }

        /// <summary>
        /// Constructs a new Ratio.
        /// </summary>
        /// <param name="numerator">A numerator Value.</param>
        /// <param name="denominator">A denominator Value.</param>
        public Ratio(Value numerator, Value denominator) 
        {
            Numerator = new Value(numerator);
            Denominator = new Value(denominator);
        }

        /// <summary>
        /// Constructs an empty Ratio.
        /// </summary>
        public Ratio()
        {
            Numerator = new Value();
            Denominator = new Value();
        }

        /// <summary>
        /// Simplifies a Ratio.
        /// </summary>
        public void Simplify()
        {
            if (Denominator.Amount != 0)
            {
                Numerator.Amount /= Denominator.Amount;
                Denominator.Amount = 1.0;
            }
            else
            {
                Numerator.Amount = 0.0;
                Denominator.Amount = 0.0;
            }

        }

        /// <summary>
        /// Multiplies two Ratios together.
        /// </summary>
        /// <param name="ratio"></param>
        public void MultiplyByRatio(Ratio ratio)
        {
            Numerator.Amount *= ratio.Numerator.Amount;
            Denominator.Amount *= ratio.Denominator.Amount;

            Numerator.Units += ratio.Numerator.Units;
            Numerator.Substance = ratio.Numerator.Substance;
        }

        /// <summary>
        /// Conterts a Ratio to a string.
        /// </summary>
        /// <returns>A string representation of a Ratio.</returns>
        public override string ToString()
        {
            return $"{Numerator} / {Denominator}";
        }
    }
}