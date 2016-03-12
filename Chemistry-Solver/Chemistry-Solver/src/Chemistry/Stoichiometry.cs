namespace BSmith.Chemistry
{
    /// <summary>
    /// A class providing stoichiometry functionality.
    /// </summary>
    public class Stoichiometry
    {
        private DimensionalAnalysis dimensional_analysis_;

        /// <summary>
        /// Constructs a new Stoichiometry object.
        /// </summary>
        public Stoichiometry()
        {
            dimensional_analysis_ = new DimensionalAnalysis();
        }

        /// <summary>
        /// A helper function that finds the appropriate conversion value from the specified value.
        /// </summary>
        /// <param name="value">A Value.</param>
        /// <returns>A decimal representing the appropriate conversion value.</returns>
        private double ConversionValue(Value value)
        {
            var result = 0.0;

            if (value.Units.Equals("grams"))
            {
                result = value.Substance.Quantity * value.Substance.Particle.MolarMass();
            }
            else if (value.Units.Equals("moles"))
            {
                result = value.Substance.Quantity;
            }
            else if (value.Units.Equals("particles"))
            {
                result = 6.022E+23; //Avogadro's Number
            }

            return result;
        }

        /// <summary>
        /// Converts the input Value into the desired output Value.
        /// </summary>
        /// <param name="input">An input Value.</param>
        /// <param name="output">An output Value.</param>
        /// <returns>The calculated output Value.</returns>
        public Value CalculateOutput(Value input, Value output)
        {
            dimensional_analysis_.Ratios.Clear();
            dimensional_analysis_.GenerateRatio(input, new Value(1.0, string.Empty, new ParticleQuantityPair<Molecule, int>(new Molecule(), 0)));

            Value output_numerator = new Value(ConversionValue(output), output.Units, output.Substance);        
            Value output_denominator = new Value(ConversionValue(input), input.Units, input.Substance);

            dimensional_analysis_.GenerateRatio(output_numerator, output_denominator);

            return dimensional_analysis_.CalculateResult();
        }
    }
}
