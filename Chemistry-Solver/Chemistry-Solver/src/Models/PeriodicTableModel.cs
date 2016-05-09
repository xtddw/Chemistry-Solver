using BSmith.Chemistry;

namespace BSmith.ChemistrySolver.Models
{
    /// <summary>
    /// The model for the periodic table controller.
    /// </summary>
    public class PeriodicTableModel
    {
        /// <summary>
        /// The periodic table.
        /// </summary>
        public PeriodicTable Table { get; } = new PeriodicTable("..\\..\\data\\ElementData.csv");

        /// <summary>
        /// Creates a new periodic table model.
        /// </summary>
        public PeriodicTableModel() { }
    }
}

