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
        private List<Element> element_data_;
        public List<Element> ElementData { get { return element_data_; } private set { element_data_ = value; } }

        /// <summary>
        /// Constructs a new PeriodicTable.
        /// </summary>
        public PeriodicTable() 
        {
            element_data_ = new List<Element>();
        }

        /// <summary>
        /// Loads element data from the specified file.
        /// </summary>
        /// <param name="file_name">The csv file containing element data.</param>
        public void LoadData(string file_name)
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

                    element_data_.Add(new Element(element_atomic_number, line_data[1], line_data[2], element_molar_mass, new System.Drawing.Point(element_row_location, element_column_location)));
                }
            }
        }

        /// <summary>
        /// Finds an element by its atomic number.
        /// </summary>
        /// <param name="atomic_number">The atomic number of the element.</param>
        /// <returns>An Element with the specified atomic number.</returns>
        public Element FindElementByAtomicNumber(int atomic_number)
        {
            Element result = new Element(0, string.Empty, string.Empty, 0.0, new System.Drawing.Point());

            result = element_data_.Find(element => element.AtomicNumber == atomic_number);

            return result;
        }

        /// <summary>
        /// Finds an element by its name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <returns>An Element with the specified name.</returns>
        public Element FindElementByName(string name)
        {
            Element result = new Element(0, string.Empty, string.Empty, 0.0, new System.Drawing.Point());

            result = element_data_.Find(element => element.Name == name);

            return result;
        }

        /// <summary>
        /// Finds an element by its symbol.
        /// </summary>
        /// <param name="name">The symbol of the element.</param>
        /// <returns>An Element with the specified symbol.</returns>
        public Element FindElementBySymbol(string symbol)
        {
            Element result = new Element(0, string.Empty, string.Empty, 0.0, new System.Drawing.Point());

            result = element_data_.Find(element => element.Symbol == symbol);

            return result;
        }

        /// <summary>
        /// Finds an element by its molar mass.
        /// </summary>
        /// <param name="name">The molar mass of the element.</param>
        /// <returns>An Element with the specified molar mass.</returns>
        public Element FindElementByMolarMass(double molar_mass)
        {
            Element result = new Element(0, string.Empty, string.Empty, 0.0, new System.Drawing.Point());

            result = element_data_.Find(element => element.MolarMass == molar_mass);

            return result;
        }
    }
}
