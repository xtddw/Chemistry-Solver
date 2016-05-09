using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BSmith.Chemistry
{
    /// <summary>
    /// A class containing element information.
    /// </summary>
    public class PeriodicTable
    {
        /// <summary>
        /// The list of elements in the periodic table.
        /// </summary>
        public List<Element> ElementData { get; private set; } = new List<Element>();

        /// <summary>
        /// Constructs a new <see cref="PeriodicTable"/> with element data from the .csv file, <paramref name="fileName"/>.
        /// </summary>
        /// <param name="fileName">A .csv file containing element information.</param>
        public PeriodicTable(string fileName) 
        {
            LoadDataFromCSV(fileName);
        }

        /// <summary>
        /// Loads element data from the specified .csv file.
        /// </summary>
        /// <param name="file_name">The csv file containing element data.</param>
        private void LoadDataFromCSV(string file_name)
        {
            using (StreamReader file = new StreamReader(file_name))
            {
                string element = string.Empty;

                while ((element = file.ReadLine()) != null)
                {
                    string[] line_data = Regex.Split(element, @",");

                    int element_atomic_number = 0;
                    int.TryParse(line_data[0], out element_atomic_number);

                    double element_molar_mass = 0.0;
                    double.TryParse(line_data[3], out element_molar_mass);

                    int element_row_location = 0;
                    int.TryParse(line_data[4], out element_row_location);

                    int element_column_location = 0;
                    int.TryParse(line_data[5], out element_column_location);

                    ElementData.Add(new Element(element_atomic_number, line_data[1], line_data[2], element_molar_mass));
                }
            }
        }

        /// <summary>
        /// Finds an element by its atomic number.
        /// </summary>
        /// <param name="atomic_number">The atomic number of the element.</param>
        /// <returns>An Element with the specified atomic number.</returns>
        public Element FindElementByAtomicNumber(int atomic_number)
               => ElementData.Find(element => element.AtomicNumber == atomic_number);

        /// <summary>
        /// Finds an element by its name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <returns>An Element with the specified name.</returns>
        public Element FindElementByName(string name)
               => ElementData.Find(element => element.Name == name);

        /// <summary>
        /// Finds an element by its symbol.
        /// </summary>
        /// <param name="name">The symbol of the element.</param>
        /// <returns>An Element with the specified symbol.</returns>
        public Element FindElementBySymbol(string symbol)
               => ElementData.Find(element => element.Symbol == symbol);

        /// <summary>
        /// Finds an element by its molar mass.
        /// </summary>
        /// <param name="name">The molar mass of the element.</param>
        /// <returns>An Element with the specified molar mass.</returns>
        public Element FindElementByMolarMass(double molar_mass)
               => ElementData.Find(element => element.MolarMass == molar_mass);
    }
}
