using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BSmith.ChemistrySolver.Utility
{
    public class UnitConverter
    {
    
        public UnitConverter()
        {

        }

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
