using BSmith.Chemistry;

namespace BSmith.ChemistrySolver.Models
{
    public class PeriodicTableModel
    {
        private PeriodicTable periodic_table_;
        public PeriodicTable PTable { get { return periodic_table_; } private set { periodic_table_ = value; } }

        public PeriodicTableModel()
        {
            periodic_table_ = new PeriodicTable();
            periodic_table_.LoadData("..\\..\\data\\ElementData.csv");
        }
    }
}

