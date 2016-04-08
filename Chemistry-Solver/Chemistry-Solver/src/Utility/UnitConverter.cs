using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BSmith.ChemistrySolver.Utility
{
    /// <summary>
    /// Provides functionality for converting values from one unit to another.
    /// </summary>
    public class UnitConverter
    {
        /// <summary>
        /// The conversion tables used to convert numbers from one unit to another.
        /// </summary>
        public List<ConversionTable> ConversionTables { get; } = new List<ConversionTable>();

        /// <summary>
        /// Constructs an empty <see cref="UnitConverter"/>
        /// </summary>
        public UnitConverter() {}

        /// <summary>
        /// Creates a new <see cref="ConversionTable"/> from a collection of lines.
        /// </summary>
        /// <param name="lines">A collection of lines that hold the data for a single <see cref="ConversionTable"/>.</param>
        /// <returns>A new <see cref="ConversionTable"/>.</returns>
        public ConversionTable CreateConversionTableFromLines(List<List<string>> lines)
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
                            ConversionTables.Add(CreateConversionTableFromLines(lineBlock).Transpose());
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
