using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BSmith.ChemistrySolver.Utility
{
    /// <summary>
    /// Represents a conversion ratio used in <see cref="Chemistry.DimensionalAnalysis"/>.
    /// </summary>
    public class ConversionValue
    {
        /// <summary>
        /// The unit in the numerator position of a conversion ratio.
        /// </summary>
        public List<string> UpperUnits { get; set; } = new List<string>();

        /// <summary>
        /// The unit in the denominator position of a conversion ratio.
        /// </summary>
        public List<string> LowerUnits { get; set; } = new List<string>();

        /// <summary>
        /// The type of unit conversion this <see cref="ConversionValue"/> is associated with.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The numeric value indicating how much of <see cref="UpperUnit"/> is equal to exactly 1 of <see cref="LowerUnit"/>.
        /// </summary>
        public double Value { get; set; } = 0d;

        /// <summary>
        /// Constructs an empty conversion value.
        /// </summary>
        public ConversionValue() { }

        /// <summary>
        /// Constructs a new conversion value with the given parameters.
        /// </summary>
        /// <param name="value">A numeric value representing how much of 'upperUnit' is equal to exactly 1 of 'lowerUnit'.</param>
        /// <param name="upperUnit">The unit in the numerator position of a conversion value.</param>
        /// <param name="lowerUnit">The unit in the denominator position of a conversion value.</param>
        /// <param name="type">The type of unit conversion this ratio is associated with. Ex: distance, time, temperature, etc.</param>
        public ConversionValue(double value, string upperUnit, string lowerUnit, string type)
        {
            Value = value;
            UpperUnits.Add(upperUnit);
            LowerUnits.Add(lowerUnit);
            Type = type;
        }

        /// <summary>
        /// Constructs a new conversion value with the given parameters.
        /// </summary>
        /// <param name="value">A numeric value representing how much of 'upperUnits' is equal to exactly 1 of 'lowerUnits'.</param>
        /// <param name="upperUnits">The units found in the numerator position of a conversion value.</param>
        /// <param name="lowerUnits">The units found in the denominator position of a conversion value.</param>
        /// <param name="type">The type of unit conversion this ratio is associaved with. Ex: distance, time, temperature, etc.</param>
        public ConversionValue(double value, string[] upperUnits, string[] lowerUnits, string type)
        {
            Value = value;
            UpperUnits.AddRange(upperUnits);
            LowerUnits.AddRange(lowerUnits);
            Type = type;
        }

        /// <summary>
        /// Cancels units found both in the upper and the lower portions of a ratio.
        /// </summary>
        private void CancelUnits()
        {
            // Remove empty values for proper string formatting in the ToString() method
            UpperUnits.RemoveAll(str => str?.Equals(string.Empty) ?? false);
            LowerUnits.RemoveAll(str => str?.Equals(string.Empty) ?? false);

            for (var i = 0; i < UpperUnits.Count; ++i)
            {
                var removableUnit = LowerUnits.FirstOrDefault(lowerUnit => lowerUnit?.Equals(UpperUnits[i]) ?? false);

                if ((UpperUnits?.Remove(removableUnit) ?? false) &&
                    (LowerUnits?.Remove(removableUnit) ?? false))
                {
                    --i;
                }
            }
        }

        /// <summary>
        /// Multiplies two conversion values together.
        /// </summary>
        /// <param name="value1">The 'input' unit.</param>
        /// <param name="value2">The 'output' unit.</param>
        /// <returns>A condensed <see cref="ConversionValue"/> that takes on the simplest version of a combination of both units.</returns>
        public static ConversionValue operator *(ConversionValue value1, ConversionValue value2)
        {
            var conversionResult = new ConversionValue();

            conversionResult.Value = (value1?.Value ?? 0d) * (value2?.Value ?? 0d);
            conversionResult.UpperUnits.AddRange(value1?.UpperUnits);
            conversionResult.UpperUnits.AddRange(value2?.UpperUnits);
            conversionResult.LowerUnits.AddRange(value1?.LowerUnits);
            conversionResult.LowerUnits.AddRange(value2?.LowerUnits);
            conversionResult.Type = value1.Type;
            conversionResult.CancelUnits();

            return conversionResult;
        }

        /// <summary>
        /// Converts a <see cref="ConversionValue"/> into a string.
        /// </summary>
        /// <returns>A string representing a conversion value.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append($"{Value} ");

            for (var i = 0; i < UpperUnits.Count; ++ i)
            {
                builder.Append($"{UpperUnits?[i]} " ?? string.Empty);
            }

            for (var i = 0; i < LowerUnits.Count; ++i)
            {
                builder.Append((LowerUnits[0] != null) ? "per " : string.Empty);
                builder.Append($"{LowerUnits?[i]} " ?? string.Empty);
            }

            return builder.ToString().Trim();
        }           
    }
}
