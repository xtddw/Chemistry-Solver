using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BSmith.ChemistrySolver.Utility
{
    /// <summary>
    /// Provides functionality for converting values from one unit to another.
    /// </summary>
    public class UnitConversion
    {
        /// <summary>
        /// The conversion tables used to convert numbers from one unit to another.
        /// </summary>
        public List<ConversionTable> TableData { get; } = new List<ConversionTable>();

        /// <summary>
        /// The selected table being used for unit conversion calculations.
        /// </summary>
        public ConversionTable ConversionTable { get; set; } = new ConversionTable(string.Empty);

        /// <summary>
        /// The input value being used for unit conversion calculations.
        /// </summary>
        public ConversionValue InputValue { get; set; } = new ConversionValue();

        /// <summary>
        /// The conversion ratio used for unit conversion calculations.
        /// </summary>
        public ConversionValue ConversionRatio { get; set; } = new ConversionValue();

        /// <summary>
        /// Constructs an empty <see cref="UnitConversion"/>
        /// </summary>
        public UnitConversion() {}

        /// <summary>
        /// Converts one unit to another.
        /// </summary>
        /// <returns>The converted unit.</returns>
        public ConversionValue PerformConversion() => InputValue * ConversionRatio;

        /// <summary>
        /// Gets the <see cref="Utility.ConversionTable"/> that has the type <paramref name="conversionType"/>
        /// </summary>
        /// <param name="conversionType">The type of unit conversion the table performs.</param>
        /// <returns>A <see cref="Utility.ConversionTable"/> with the appropriate <paramref name="conversionType"/></returns>
        public ConversionTable GetConversionTable(string conversionType)
               => TableData.FirstOrDefault(table => table.ConversionType.Equals(conversionType));

        /// <summary>
        /// Creates a new <see cref="Utility.ConversionTable"/> from a collection of lines.
        /// </summary>
        /// <param name="lines">A collection of lines that hold the data for a single <see cref="Utility.ConversionTable"/>.</param>
        /// <returns>A new <see cref="Utility.ConversionTable"/>.</returns>
        public ConversionTable CreateConversionTable(List<List<string>> lines)
        {
            ConversionTable table = null;

            if(lines.Count > 1 &&
               lines[0].Count >= lines.Count)
            {
                table = new ConversionTable(lines[0][0]);
                var tableHeader = lines[0].ToList();
                var indexOfFirstTrailingEmpty = tableHeader.IndexOf(tableHeader.FirstOrDefault(conversionValue => conversionValue.Equals(string.Empty)));
                var tableWidth = (indexOfFirstTrailingEmpty != -1) ? indexOfFirstTrailingEmpty : tableHeader.Count;

                for(var rowIndex = 0; rowIndex < lines.Count; ++rowIndex)
                {
                    for (var columnIndex = 0; columnIndex < tableWidth; ++columnIndex)
                    {
                        if(rowIndex == 0)
                        {
                            table.Table.AddColumn(lines[rowIndex][columnIndex]);
                        }
                        else
                        {
                            table.Table.AddValue(lines[0][columnIndex], lines[rowIndex][columnIndex]);
                        }
                    }
                }
            }

            return table;
        }

        /// <summary>
        /// Creates conversion tables from a .csv file.
        /// </summary>
        /// <param name="fileName">The name of the .csv file, including the extension.</param>
        public void LoadConversionTablesFromCSV(string fileName)
        {
            if (fileName.Substring(fileName.Length - 4).Equals(".csv"))
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    var conversionRowData = string.Empty;
                    var lineBlock = new List<List<string>>();

                    while ((conversionRowData = file.ReadLine()) != null)
                    {     
                        var lineData = Regex.Split(conversionRowData, @",").ToList();

                        if (lineData.All(conversionValue => conversionValue.Equals(string.Empty)))
                        {
                            TableData.Add(CreateConversionTable(lineBlock).Transpose());
                            lineBlock.Clear();                       
                        }
                        else
                        {
                            lineBlock.Add(lineData);
                        }
                    }
                }
            }
        }
    }
}
