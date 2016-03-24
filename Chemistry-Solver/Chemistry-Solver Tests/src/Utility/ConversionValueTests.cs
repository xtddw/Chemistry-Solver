using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSmith.ChemistrySolver.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSmith.ChemistrySolver.Utility.Tests
{
    [TestClass()]
    public class ConversionValueTests
    {
        /// <summary>
        /// Checks for the correct output when dealing with compound unit conversion.
        /// </summary>
        [TestMethod()]
        public void ConversionValue_CompoundUnitConversion_ProperOperation()
        {
            var valueInFeetPerSecond = new ConversionValue(46d, new[] { "feet" }, new[] { "second" }, "velocity");
            var feetToMiles = new ConversionValue(0.000189394, new[] { "miles" }, new[] { "feet" }, "length");
            var secondToHour = new ConversionValue(3600d, new[] { "second" }, new[] { "hour" }, "time");
            var valueInMPH = valueInFeetPerSecond * feetToMiles * secondToHour;
            valueInMPH.Value = System.Math.Round(valueInMPH.Value, 4);

            Assert.AreEqual("31.3636 miles per hour", valueInMPH.ToString());
        }

        /// <summary>
        /// Checks for the correct output when dealing with regular unit conversion.
        /// </summary>
        [TestMethod()]
        public void ConversionValue_ReuglarUnitConversion_ProperOperation()
        {
            var valueInJoules = new ConversionValue(151320d, new[] { "Joules" }, null, "Energy");
            var joulesToKCal = new ConversionValue(0.000239006, new[] { "Calorie" }, new[] { "Joules" }, "Energy");
            var valueInKCal = valueInJoules * joulesToKCal;

            Assert.AreEqual("36.16638792 Calorie", valueInKCal.ToString());
        }

        /// <summary>
        /// Checks for correct output when a unit is assigned a null value.
        /// </summary>
        [TestMethod()]
        public void ConversionValue_NullUnits_UnitCanceling()
        {
            var valueInCM = new ConversionValue(200d, null, null, "length");
            var centimetersToFeet = new ConversionValue(0.0328084, new[] { "feet" }, new[] { "centimeter" }, "length");
            var valueInFeet = valueInCM * centimetersToFeet;

            Assert.AreEqual("6.56168 feet per centimeter", valueInFeet.ToString());
        }

        /// <summary>
        /// Checks for correct output when a unit is assigned an empty string.
        /// </summary>
        [TestMethod()]
        public void ConversionValue_EmptyStringUnits_UnitCanceling()
        {
            var valueInCM = new ConversionValue(200d, new[] { string.Empty }, new[] { string.Empty }, "length");
            var centimetersToFeet = new ConversionValue(0.0328084, new[] { "feet" }, new[] { "centimeter" }, "length");
            var valueInFeet = valueInCM * centimetersToFeet;

            Assert.AreEqual("6.56168 feet per centimeter", valueInFeet.ToString());
        }

        /// <summary>
        /// Checks for correct output when all values are unitless.
        /// </summary>
        [TestMethod()]
        public void ConversionValue_AllValuesUnitless()
        {
            var valueInCM = new ConversionValue(200d, null, null, "length");
            var centimetersToFeet = new ConversionValue(0.0328084, null, null, "length");
            var valueInFeet = valueInCM * centimetersToFeet;

            Assert.AreEqual(valueInFeet.Value.ToString(), valueInFeet.ToString());
        }

        /// <summary>
        /// Checks for correct output when the order of multiplication is reversed.
        /// </summary>
        [TestMethod()]
        public void ConversionValue_ComputationOrderReversed()
        {
            var valueInJoules = new ConversionValue(151320d, new[] { "Joules" }, null, "Energy");
            var joulesToKCal = new ConversionValue(0.000239006, new[] { "Calorie" }, new[] { "Joules" }, "Energy");
            var valueInKCal = joulesToKCal * valueInJoules;

            Assert.AreEqual("36.16638792 Calorie", valueInKCal.ToString());
        }

        /// <summary>
        /// Tests the equal() method in the conversion value.
        /// </summary>
        [TestMethod()]
        public void ConversionValue_EqualsOther()
        {
            var valueInInches = new ConversionValue(15d, new[] { "Inches" }, null, "Length");
            var otherValueInInches = new ConversionValue(15d, new[] { "Inches" }, null, "Length");

            var valueInFeet = new ConversionValue(1.25, new[] { "Feet" }, null, "Length");
            var feetToInches = new ConversionValue(12d, new[] { "Inches" }, new[] { "Feet" }, "Length");
            var convertedToInches = valueInFeet * feetToInches;

            Assert.IsTrue(valueInInches.Equals(otherValueInInches));
            Assert.IsTrue(otherValueInInches.Equals(valueInInches));

            if(valueInInches.Equals(otherValueInInches) && otherValueInInches.Equals(convertedToInches))
            {
                Assert.IsTrue(valueInInches.Equals(convertedToInches));
            }

            Assert.IsFalse(valueInInches.Equals(null));
        }
    }
}