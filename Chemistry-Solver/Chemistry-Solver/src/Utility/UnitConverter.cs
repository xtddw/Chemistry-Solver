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

        void LoadConversionTablesFromCSV(string fileName)
        {
            if (fileName.Substring(fileName.Length - 4).Equals(".csv"))
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    var conversionRowData = string.Empty;

                    while ((conversionRowData = file.ReadLine()) != null)
                    {
                        string[] lineData = Regex.Split(conversionRowData, @",");

                        /*
                            Assume format of file is Table -> Empty Row -> Table ... Until end of file
                        */
                        //Separation between conversion tables.
                        if (lineData.All(conversionValue => !conversionValue.Equals(string.Empty)))
                        {

                        }
                    }
                }
            }
        }
    }
}
