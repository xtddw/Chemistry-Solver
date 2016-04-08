using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BSmith.ChemistrySolver.Utility.Tests
{
    [TestClass]
    public class UnitConverterTests
    {
        /// <summary>
        /// Tests the table creation process where a collection of lines is extracted from a .csv file, and is sent to the <see cref="UnitConversion.CreateConversionTable(List{List{string}})"/> method. 
        /// </summary>
        [TestCategory("Unit Converter Table Creation"), TestMethod]
        public void UnitConverter_CreateTableFromLines()
        {
            var unitConverter = new UnitConversion();
            var lineBlock = new List<List<string>>();

            var row1 = new List<string> { "Energy", "Erg", "Joule", "Kilocalorie", "Kilowatt hour" };
            var row2 = new List<string> { "Erg", "1", "1.00E-07", "2.39E-11", "2.78E-14" };
            var row3 = new List<string> { "Joule", "", "1", ".000239006", "2.78E-07" };
            var row4 = new List<string> { "Kilocalorie", "", "", "1", ".00116222" };
            var row5 = new List<string> { "Kilowatt hour", "", "", "", "1" };

            lineBlock.Add(row1);
            lineBlock.Add(row2);
            lineBlock.Add(row3);
            lineBlock.Add(row4);
            lineBlock.Add(row5);

            var table = unitConverter.CreateConversionTable(lineBlock);

            Assert.IsNotNull(table);
        }

        /// <summary>
        /// Tests the table creation process, ensuring that the correct number of tables is read from a .csv file.
        /// </summary>
        [TestCategory("Unit Converter Table Creation"), TestMethod]
        public void UnitConverter_CreateTablesFromCSV()
        {
            var unitConverter = new UnitConversion();
            unitConverter.LoadConversionTablesFromCSV("..\\..\\..\\Chemistry-Solver\\data\\UnitConversion.csv");

            Assert.IsTrue(unitConverter.TableData.Count == 8);
        }

        /// <summary>
        /// Tests for accurate <see cref="ConversionValue"/> extraction from a <see cref="ConversionTable"/> read from a .csv file.
        /// </summary>
        [TestCategory("Unit Converter Value Extraction"), TestMethod]
        public void UnitConverter_ReadConversionValueCorrect()
        {
            var unitConverter = new UnitConversion();
            unitConverter.LoadConversionTablesFromCSV("..\\..\\..\\Chemistry-Solver\\data\\UnitConversion.csv");

            var timeTable = unitConverter.GetConversionTable("Volume");
            var pintToQuart = timeTable.GetConversionValue("Pint", "Quart");

            Assert.AreEqual(pintToQuart, new ConversionValue(1d/2d, new[] { "Quart" }, new[] { "Pint" }, "Volume"));
        }
    }
}
