using System.Collections.Generic;
using System;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class that provides dimensional analysis functionality.
    /// </summary>
    public class DimensionalAnalysis
    {
        /// <summary>
        /// The ratio's used when performing dimensional analysis.
        /// </summary>
        public List<Ratio> Ratios { get; private set; }

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
            Ratios.Add(new Ratio(numerator, denominator));
        }

        /// <summary>
        /// Calculates the result of dimensional analysis.
        /// </summary>
        /// <returns>The result as a value object.</returns>
        public Value CalculateResult()
        {
            Value result = new Value();

            for (int numerator_index = 0; numerator_index < Ratios.Count; ++numerator_index)
            {
                for (int denominator_index = 0; denominator_index < Ratios.Count; ++denominator_index)
                {
                    if (Ratios[denominator_index].Denominator.Units.Equals(Ratios[numerator_index].Numerator.Units)
                        && Ratios[denominator_index].Denominator.Substance.Equals(Ratios[numerator_index].Numerator.Substance)
                        && !Ratios[numerator_index].Numerator.Units.Equals(string.Empty)
                        && !Ratios[numerator_index].Numerator.Substance.Equals(new Molecule()))
                    {
                        Ratios[numerator_index].Numerator.Units = string.Empty;
                        Ratios[numerator_index].Numerator.Substance = Tuple.Create(new Molecule(), 0);

                        Ratios[denominator_index].Denominator.Units = string.Empty;
                        Ratios[denominator_index].Denominator.Substance = Tuple.Create(new Molecule(), 0);
                    }
                    
                }

                Ratios[numerator_index].Simplify();
            }

            for (int ratio_index = 1; ratio_index < Ratios.Count; ++ratio_index)
            {
                Ratios[0].MultiplyByRatio(Ratios[ratio_index]);
            }

            result = Ratios[0].Numerator;

            return result;
        }
    }
}