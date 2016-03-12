using System;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    public partial class LauncherController : Form
    {
        Models.LauncherModel model_;

        public LauncherController()
        {
            model_ = new Models.LauncherModel(this);
            InitializeComponent();
        }

        private void btnEquationBalancer_Click(object sender, EventArgs e)
        {
            if (!model_.EquationBalancer.IsDisposed && !model_.EquationBalancer.Visible)
            {
                model_.EquationBalancer.Show();  
            }
            else if(model_.EquationBalancer.IsDisposed)
            {
                model_.EquationBalancer = new EquationBalancerController();
                model_.EquationBalancer.Owner = this;
                model_.EquationBalancer.Show();
            }
        }

        private void btnPeriodicTable_Click(object sender, EventArgs e)
        {
            if (!model_.PeriodicTable.IsDisposed && !model_.PeriodicTable.Visible)
            {
                model_.PeriodicTable.Show();
            }
            else if (model_.PeriodicTable.IsDisposed)
            {
                model_.PeriodicTable = new PeriodicTableController();
                model_.PeriodicTable.Owner = this;
                model_.PeriodicTable.Show();
            }
        }

        private void btnStoichiometry_Click(object sender, EventArgs e)
        {
            if (!model_.Stoichiometry.IsDisposed && !model_.Stoichiometry.Visible)
            {
                model_.Stoichiometry.Show();
            }
            else if (model_.Stoichiometry.IsDisposed)
            {
                model_.Stoichiometry = new StoichiometryController();
                model_.Stoichiometry.Owner = this;
                model_.Stoichiometry.Show();
            }
        }

        private void btnUnitConversion_Click(object sender, EventArgs e)
        {
            if (!model_.UnitConversion.IsDisposed && !model_.UnitConversion.Visible)
            {
                model_.UnitConversion.Show();
            }
            else if (model_.UnitConversion.IsDisposed)
            {
                model_.UnitConversion = new UnitConversionController();
                model_.UnitConversion.Owner = this;
                model_.UnitConversion.Show();
            }
        }
    }
}
