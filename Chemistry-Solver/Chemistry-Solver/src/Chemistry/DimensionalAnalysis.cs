using System.Collections.Generic;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class that provides dimensional analysis functionality.
    /// </summary>
    public class DimensionalAnalysis
    {
        private List<Ratio> ratios_;
        public List<Ratio> Ratios { get { return ratios_; } private set { ratios_ = value; } }

        /// <summary>
        /// Constructs an empty Dimensional Analysis object.
        /// </summary>
        public DimensionalAnalysis()
        {
            Ratios = new List<Ratio>();
        }

        /// <summary>
        /// Creates and new conversion ratio.
        /// </summary>
        /// <param name="numerator">The numerator of the ratio.</param>
        /// <param name="denominator">The denominator of the ratio.</param>
        public void GenerateRatio(Value numerator, Value denominator)
        {
            ratios_.Add(new Ratio(numerator, denominator));
        }

        /// <summary>
        /// Calculates the result of dimensional analysis.
        /// </summary>
        /// <returns>The result as a value object.</returns>
        public Value CalculateResult()
        {
            Value result = new Value();

            for (int numerator_index = 0; numerator_index < ratios_.Count; ++numerator_index)
            {
                for (int denominator_index = 0; denominator_index < ratios_.Count; ++denominator_index)
                {
                    if (ratios_[denominator_index].Denominator.Units.Equals(ratios_[numerator_index].Numerator.Units)
                        && ratios_[denominator_index].Denominator.Substance.Equals(ratios_[numerator_index].Numerator.Substance)
                        && !ratios_[numerator_index].Numerator.Units.Equals(string.Empty)
                        && !ratios_[numerator_index].Numerator.Substance.Equals(new Molecule()))
                    {
                        ratios_[numerator_index].Numerator.Units = string.Empty;
                        ratios_[numerator_index].Numerator.Substance = new ParticleQuantityPair<Molecule, int>(new Molecule(), 0);

                        ratios_[denominator_index].Denominator.Units = string.Empty;
                        ratios_[denominator_index].Denominator.Substance = new ParticleQuantityPair<Molecule, int>(new Molecule(), 0);
                    }
                    
                }

                ratios_[numerator_index].Simplify();
            }

            for (int ratio_index = 1; ratio_index < ratios_.Count; ++ratio_index)
            {
                ratios_[0].MultiplyByRatio(ratios_[ratio_index]);
            }

            result = ratios_[0].Numerator;

            return result;
        }
    }
}