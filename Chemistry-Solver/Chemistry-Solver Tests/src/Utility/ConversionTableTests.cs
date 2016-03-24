using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BSmith.ChemistrySolver.Utility.Tests
{
    /// <summary>
    /// Tests the <see cref="ConversionTable"/> class.
    /// </summary>
    [TestClass()]
    public class ConversionTableTests
    {
        /// <summary>
        /// Tests <see cref="ConversionTable.GetConversionValue(string, string)"/> for conversion ratios in regular order.
        /// </summary>
        [TestMethod()]
        public void ConversionTable_GetRegularConversionValue()
        {           
            var column1 = new List<string>(new[] { "Length", "Meter", "Feet" });
            var column2 = new List<string>(new[] { "Meter", "1", null });
            var column3 = new List<string>(new[] { "Feet", "3.280833599", "1" });

            var table = new List<List<string>>();
            table.Add(column1);
            table.Add(column2);
            table.Add(column3);

            var conversionTable = new ConversionTable(table, table[0][0]);
            var conversionValue = conversionTable.GetConversionValue("Meter", "Feet");
            var expectedValue = new ConversionValue(3.280833599, new[] { "Meter" }, new[] { "Feet" }, "Length");

            Assert.AreEqual(expectedValue, conversionValue);
        }

        /// <summary>
        /// Tests <see cref="ConversionTable.GetConversionValue(string, string)"/> for conversion ratios in inverse order.
        /// </summary>
        [TestMethod()]
        public void ConversionTable_GetInverseConversionValue()
        {
            var column1 = new List<string>(new[] { "Length", "Meter", "Feet" });
            var column2 = new List<string>(new[] { "Meter", "1", null });
            var column3 = new List<string>(new[] { "Feet", "3.280833599", "1" });

            var table = new List<List<string>>();
            table.Add(column1);
            table.Add(column2);
            table.Add(column3);

            var conversionTable = new ConversionTable(table, table[0][0]);
            var conversionValue = conversionTable.GetConversionValue("Feet", "Meter");
            var expectedValue = new ConversionValue(1d/3.280833599, new[] { "Feet" }, new[] { "Meter" }, "Length");

            Assert.AreEqual(expectedValue, conversionValue);
        }
    }
}
