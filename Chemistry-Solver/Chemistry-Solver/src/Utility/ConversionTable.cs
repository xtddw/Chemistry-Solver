using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSmith.ChemistrySolver.Utility;

namespace BSmith.ChemistrySolver.Utility
{
    /// <summary>
    /// Represents a conversion table in a .csv data file.
    /// </summary>
    public class ConversionTable
    {
        /// <summary>
        /// The table's unit conversion data.
        /// </summary>
        public DataFitting.Data.DataFile Table { get; set; } = new DataFitting.Data.DataFile();

        /// <summary>
        /// The type of unit conversion the values in the <see cref="ConversionTable"/> perform.
        /// </summary>
        public string ConversionType { get; } = null;

        /// <summary>
        /// Constructs an empty <see cref="ConversionTable"/>;
        /// </summary>
        /// <param name="conversionType">The type of unit conversion the table provides.</param>
        public ConversionTable(string conversionType)
        {
            ConversionType = conversionType;
        }

        /// <summary>
        /// Constructs a <see cref="ConversionTable"/> from a <see cref="DataFitting.Data.DataFile"/>.
        /// </summary>
        /// <param name="table">The conversion table data.</param>
        /// <param name="conversionType">The type of unit conversion the table provides.</param>
        public ConversionTable(DataFitting.Data.DataFile table, string conversionType)
        {
            Table = table;
            ConversionType = conversionType;
        }

        /// <summary>
        /// Constructs a <see cref="ConversionTable"/> from a <see cref="List{T}"/>.
        /// </summary>
        /// <param name="tableData">The table data in raw form.</param>
        /// <param name="conversionType">The type of unit conversion the table provides.</param>
        public ConversionTable(List<List<string>> tableData, string conversionType)
        {
            Table = new DataFitting.Data.DataFile(tableData);
            ConversionType = conversionType;
        }

        /// <summary>
        /// Changes the orientation of the table, so that rows become columns, and columns become rows.
        /// </summary>
        public ConversionTable Transpose()
        {
            var buffer = new List<List<string>>();

            foreach (var column in Table.Data[0])
            {
                buffer.Add(new List<string>(Table.Data.Count));
            }

            for (var row = 0; row < buffer.Count; ++row)
            {
                // The capacity of each element in buffer is the  number of columns in the row.
                for (var column = 0; column < buffer[0].Capacity; ++column)
                {
                    // Assign each cell value, horizontally, in buffer.
                    buffer[row].Add(Table.Data[column][row]);
                }
            }

            Table = new DataFitting.Data.DataFile(buffer);

            return this;
        }

        /// <summary>
        /// Creates a new <see cref="ConversionValue"/> in the format of:  X <paramref name="remainingUnit"/> per 1 <paramref name="canceledUnit"/> , where <paramref name="canceledUnit"/> is converted into <paramref name="remainingUnit"/>.
        /// </summary>
        /// <param name="remainingUnit">The output unit, or the unit that remains after being multiplied with the input <see cref="ConversionValue"/>.</param>
        /// <param name="canceledUnit">The unit that will cancel when multiplied with the input <see cref="ConversionValue"/>.</param>
        /// <returns>A <see cref="ConversionValue"/> that converts <paramref name="canceledUnit"/> into <paramref name="remainingUnit"/>.</returns>
        public ConversionValue GetConversionValue(string canceledUnit, string remainingUnit)
        {
            var remainingUnitRowIndex = Table.GetColumnData(ConversionType).IndexOf(remainingUnit);
            var canceledUnitRowIndex = Table.GetColumnData(ConversionType).IndexOf(canceledUnit);

            var cellData = string.Empty;
            var cellValue = 0d;

            // Check if the conversionValue coordinates access the lower half of the conversionTable, if so, swap coordinates and invert the value.
            if(canceledUnitRowIndex <= remainingUnitRowIndex)
            {
                cellData = Table.GetColumnData(canceledUnit).ElementAt(remainingUnitRowIndex).ToString();
                double.TryParse(cellData, out cellValue);
            }
            else
            {
                cellData = Table.GetColumnData(remainingUnit).ElementAt(canceledUnitRowIndex).ToString();
                double.TryParse(cellData, out cellValue);
                cellValue = 1 / cellValue;
            }

            return new ConversionValue(cellValue, new[] { remainingUnit }, new[] { canceledUnit }, ConversionType);
        }

        /// <summary>
        /// Checks for equality between this, and another <see cref="object"/>;
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to check equality with.</param>
        /// <returns>The equality between this an another object.</returns>
        public override bool Equals(object obj)
        {
            var equality = true;

            if (obj is ConversionTable)
            {
                var otherTable = obj as ConversionTable;

                if (Table.Data.Count == otherTable.Table.Data.Count &&
                    Table.Data[0].Count == otherTable.Table.Data[0].Count)
                {
                    for (var rowIndex = 0; rowIndex < Table.Data.Count; ++rowIndex)
                    {
                        for (var columnIndex = 0; columnIndex < Table.Data[0].Count; ++columnIndex)
                        {
                            if (Table.Data[rowIndex][columnIndex] != otherTable.Table.Data[rowIndex][columnIndex])
                            {
                                equality = false;
                            }
                        }
                    }
                }
            }

            return equality;
        }

        /// <summary>
        /// Checks for equality between this, and another <see cref="ConversionTable"/>;
        /// </summary>
        /// <param name="otherTable">The <see cref="ConversionTable"/> to check equality with.</param>
        /// <returns>The equality between this an another object.</returns>
        public bool Equals(ConversionTable otherTable)
        {
            var equality = true;

            if (Table.Data.Count == otherTable.Table.Data.Count &&
               Table.Data[0].Count == otherTable.Table.Data[0].Count)
            {
                for (var rowIndex = 0; rowIndex < Table.Data.Count; ++rowIndex)
                {
                    for (var columnIndex = 0; columnIndex < Table.Data[0].Count; ++columnIndex)
                    {
                        if (Table.Data[rowIndex][columnIndex] != otherTable.Table.Data[rowIndex][columnIndex])
                        {
                            equality = false;
                        }
                    }
                }
            }

            return equality;
        }
    }
}
