using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSmith.DataFitting.Data
{
    /// <summary>
    /// Stores information from a .csv file in table format.
    /// </summary>
    public class DataFile
    {
        public List<List<string>> Data { get; }

        /// <summary>
        /// Creates an empty datafile that stores .csv file information.
        /// </summary>
        public DataFile()
        {
            Data = new List<List<string>>();
        }

        /// <summary>
        /// Creates a new data file with the provided .csv file information.
        /// </summary>
        /// <param name="data">Imported .csv file information.</param>
        public DataFile(List<List<string>> data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the data for the specified column.
        /// </summary>
        /// <param name="header_text">The column's header text.</param>
        /// <returns></returns>
        public List<string> GetColumnData(string header_text)
        {
            var column_valid = Data.SelectMany(col => col).Contains(header_text);

            if (column_valid)
            {
                return GetWholeColumn(header_text).Where((value, index) => index != 0).ToList();
            }
            else
                return null;          
        }

        /// <summary>
        /// Gets the entire column from the data file, including the column header.
        /// </summary>
        /// <param name="header_text">The column's header text.</param>
        /// <returns>The entire column including it's header cell.</returns>
        public List<string> GetWholeColumn(string header_text)
        {
            var column_valid = Data.SelectMany(col => col).Contains(header_text);

            if (column_valid)
            {
                return Data.Find(col => col[0].Equals(header_text));
            }
            else
                return null;
        }

        /// <summary>
        /// Adds a new column to the data file.
        /// </summary>
        /// <param name="header_text">The header text of the column.</param>
        public void AddColumn(string header_text)
        {
            var column = GetWholeColumn(header_text);

            if (column == null)
            {
                Data.Add(new List<string> { header_text });
            }
        }

        /// <summary>
        /// Removes the column from the data file.
        /// </summary>
        /// <param name="header_text">The header text of the column.</param>
        public void RemoveColumn(string header_text)
        {
            // List.Remove does not return an exception if it's argument is null. It can't find null, and returns.
            Data.Remove(Data.Find(col => col[0].Equals(header_text)));
        }

        /// <summary>
        /// Edits the value in the specified column, at the given index.
        /// </summary>
        /// <param name="header_text">The header text of the column.</param>
        /// <param name="index">The rowIndex of the value, as it appears in the dgv.</param>
        /// <param name="value">The value to replace the existing value with.</param>
        public void EditValue(string header_text, int index, string value)
        {
            var column = GetWholeColumn(header_text);

            if (column != null)
            {
                if (column.Count > index)
                {
                    // The index provided doesn't take into account the column headers in the dgv, and so it's
                    // behind by one since the datafile does take into account the column header.
                    column[index + 1] = value;
                }
            }
        }

        /// <summary>
        /// Adds a new value to the specified column.
        /// </summary>
        /// <param name="header_text">The header text of the column.</param>
        /// <param name="value">The value to add to the column.</param>
        public void AddValue(string header_text, string value)
        {
            var column = GetWholeColumn(header_text);

            if (column != null)
            {
                column.Add(value);
            }
        }

        /// <summary>
        /// Removes the value, at the given index, from the specified column.
        /// </summary>
        /// <param name="header_text">The header text of the column.</param>
        /// <param name="index">The index of the value to remove, as it is in the data grid view.</param>
        public void RemoveValue(string header_text, int index)
        {
            // needs to be the whole column because it returns a reference to the list<string> in the data file.
            var column = GetWholeColumn(header_text);

            if (column != null)
            {
                // The header text of the column is the first entry, so don't count that.
                if (column.Count - 1 > index)
                {
                    // The index provided doesn't take into account the column headers in the dgv, and so it's
                    // behind by one since the datafile does take into account the column header.
                    column.RemoveAt(index + 1);
                }
            }
        }
    }
}
