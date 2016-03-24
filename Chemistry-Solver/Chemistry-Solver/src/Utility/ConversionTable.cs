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
        public ConversionTable() {}

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
        /// Creates a new <see cref="ConversionValue"/> in the direction of <paramref name="canceledUnit"/> to <paramref name="remainingUnit"/>.
        /// </summary>
        /// <param name="remainingUnit">The output unit, or the unit that remains after being multiplied with the input <see cref="ConversionValue"/>.</param>
        /// <param name="canceledUnit">The unit that will cancel when multiplied with the input <see cref="ConversionValue"/>.</param>
        /// <returns></returns>
        public ConversionValue GetConversionValue(string remainingUnit, string canceledUnit)
        {
            var initialUnitRowIndex = Table.GetColumnData(ConversionType).IndexOf(remainingUnit);
            var resultUnitRowIndex = Table.GetColumnData(ConversionType).IndexOf(canceledUnit);

            var cellData = string.Empty;
            var cellValue = 0d;

            // Check if the conversionValue coordinates access the lower half of the conversionTable, if so, swap coordinates and invert the value.
            if(initialUnitRowIndex > resultUnitRowIndex)
            {
                cellData = Table.GetColumnData(remainingUnit).ElementAt(resultUnitRowIndex).ToString();
                double.TryParse(cellData, out cellValue);
                cellValue = 1 / cellValue;
            }
            else
            {
                cellData = Table.GetColumnData(canceledUnit).ElementAt(initialUnitRowIndex).ToString();
                double.TryParse(cellData, out cellValue);
            }

            return new ConversionValue(cellValue, new[] { remainingUnit }, new[] { canceledUnit }, ConversionType);
        }
    }
}
