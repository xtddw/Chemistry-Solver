using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BSmith.ChemistrySolver.Utility.Tests
{
    /// <summary>
    /// Tests the <see cref="ConversionTable"/> class.
    /// </summary>
    [TestClass]
    public class ConversionTableTests
    {
        /// <summary>
        /// Tests <see cref="ConversionTable.GetConversionValue(string, string)"/> for conversion ratios in regular order.
        /// </summary>
        [TestCategory("Conversion Table Value Extraction"), TestMethod]
        public void ConversionTable_GetRegularConversionValue()
        {           
            var row1 = new List<string> { "Energy", "Erg", "Joule", "Kilocalorie", "Kilowatt hour" };
            var row2 = new List<string> { "Erg", "1", "1.00E-07", "2.39E-11", "2.78E-14" };
            var row3 = new List<string> { "Joule", "", "1", ".000239006", "2.78E-07"};
            var row4 = new List<string> { "Kilocalorie", "", "", "1", ".00116222" };
            var row5 = new List<string> { "Kilowatt hour", "", "", "", "1" };

            var table = new List<List<string>>();
            table.Add(row1);
            table.Add(row2);
            table.Add(row3);
            table.Add(row4);
            table.Add(row5);

            var conversionTable = new ConversionTable(table, table[0][0]);
            var conversionValue = conversionTable.GetConversionValue("Erg", "Kilocalorie");
            var expectedValue = new ConversionValue(2.39E-11, new[] { "Kilocalorie" }, new[] { "Erg" }, "Energy");

            Assert.AreEqual(expectedValue, conversionValue);
        }

        /// <summary>
        /// Tests <see cref="ConversionTable.GetConversionValue(string, string)"/> for conversion ratios in inverse order.
        /// </summary>
        [TestCategory("Conversion Table Value Extraction"), TestMethod]
        public void ConversionTable_GetInverseConversionValue()
        {
            var row1 = new List<string> { "Energy", "Erg", "Joule", "Kilocalorie", "Kilowatt hour" };
            var row2 = new List<string> { "Erg", "1", "1.00E-07", "2.39E-11", "2.78E-14" };
            var row3 = new List<string> { "Joule", "", "1", ".000239006", "2.78E-07" };
            var row4 = new List<string> { "Kilocalorie", "", "", "1", ".00116222" };
            var row5 = new List<string> { "Kilowatt hour", "", "", "", "1" };

            var table = new List<List<string>>();
            table.Add(row1);
            table.Add(row2);
            table.Add(row3);
            table.Add(row4);
            table.Add(row5);

            var conversionTable = new ConversionTable(table, table[0][0]);
            var conversionValue = conversionTable.GetConversionValue("Joule", "Erg");
            var expectedValue = new ConversionValue(1d/ 1.00E-07, new[] { "Erg" }, new[] { "Joule" }, "Energy");

            Assert.AreEqual(expectedValue, conversionValue);
        }

        /// <summary>
        /// Tests <see cref="ConversionTable.GetConversionValue(string, string)"/> with units that are null.
        /// </summary>
        [TestCategory("Conversion Table Value Extraction"), TestMethod]
        public void ConversionTable_GetConversionValueWithNullUnit()
        {
            var row1 = new List<string> { "Energy", "Erg", "Joule", "Kilocalorie", "Kilowatt hour" };
            var row2 = new List<string> { "Erg", "1", "1.00E-07", "2.39E-11", "2.78E-14" };
            var row3 = new List<string> { "Joule", "", "1", ".000239006", "2.78E-07" };
            var row4 = new List<string> { "Kilocalorie", "", "", "1", ".00116222" };
            var row5 = new List<string> { "Kilowatt hour", "", "", "", "1" };

            var table = new List<List<string>>();
            table.Add(row1);
            table.Add(row2);
            table.Add(row3);
            table.Add(row4);
            table.Add(row5);

            var conversionTable = new ConversionTable(table, table[0][0]);
            var conversionValue = conversionTable.GetConversionValue(null, "Kilocalorie");
            var expectedValue = new ConversionValue();

            Assert.AreEqual(expectedValue, conversionValue);
        }

        /// <summary>
        /// Tests <see cref="ConversionTable.GetConversionValue(string, string)"/> with units that aren't in the <see cref="ConversionTable"/>.
        /// </summary>
        [TestCategory("Conversion Table Value Extraction"), TestMethod]
        public void ConversionTable_GetConversionValueWithMissingUnit()
        {
            var row1 = new List<string> { "Energy", "Erg", "Joule", "Kilocalorie", "Kilowatt hour" };
            var row2 = new List<string> { "Erg", "1", "1.00E-07", "2.39E-11", "2.78E-14" };
            var row3 = new List<string> { "Joule", "", "1", ".000239006", "2.78E-07" };
            var row4 = new List<string> { "Kilocalorie", "", "", "1", ".00116222" };
            var row5 = new List<string> { "Kilowatt hour", "", "", "", "1" };

            var table = new List<List<string>>();
            table.Add(row1);
            table.Add(row2);
            table.Add(row3);
            table.Add(row4);
            table.Add(row5);

            var conversionTable = new ConversionTable(table, table[0][0]);
            var conversionValue = conversionTable.GetConversionValue("Meter", "Kilocalorie");
            var expectedValue = new ConversionValue();

            Assert.AreEqual(expectedValue, conversionValue);
        }

        /// <summary>
        /// Tests <see cref="ConversionTable.Transpose()"/> to ensure that transposing twice returns the original table.
        /// </summary>
        [TestCategory("Conversion Table Utility"), TestMethod]
        public void ConversionTable_TransposeCycleEqualsOriginal()
        {
            var row1 = new List<string> { "Energy", "Erg", "Joule", "Kilocalorie", "Kilowatt hour" };
            var row2 = new List<string> { "Erg", "1", "1.00E-07", "2.39E-11", "2.78E-14" };
            var row3 = new List<string> { "Joule", "", "1", ".000239006", "2.78E-07" };
            var row4 = new List<string> { "Kilocalorie", "", "", "1", ".00116222" };
            var row5 = new List<string> { "Kilowatt hour", "", "", "", "1" };

            var table = new List<List<string>>();
            table.Add(row1);
            table.Add(row2);
            table.Add(row3);
            table.Add(row4);
            table.Add(row5);

            var transposedTable = new ConversionTable(table, table[0][0]);
            var originalTable = new ConversionTable(table, table[0][0]);

            Assert.AreEqual(transposedTable.Transpose().Transpose(), originalTable);
        }
    }
}
