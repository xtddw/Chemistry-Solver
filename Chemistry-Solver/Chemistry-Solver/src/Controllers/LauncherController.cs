using System;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    public partial class LauncherController : Form, Interfaces.ILauncher
    {
        /// <summary>
        /// The launcher model for the controller.
        /// </summary>
        private Models.LauncherModel model_;

        /// <summary>
        /// Creates a new launcher controller.
        /// </summary>
        public LauncherController()
        {
            model_ = new Models.LauncherModel(this);
            InitializeComponent();
        }

        /// <summary>
        /// Opens the equation balancer window.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void BalanceEquationsButtonClick(object sender, EventArgs e)
        {
            if (!model_.EquationBalancer.IsDisposed && !model_.EquationBalancer.Visible)
            {
                model_.EquationBalancer.Show();
            }
            else if (model_.EquationBalancer.IsDisposed)
            {
                model_.EquationBalancer = new EquationBalancerController();
                model_.EquationBalancer.Owner = this;
                model_.EquationBalancer.Show();
            }
        }

        /// <summary>
        /// Opens the combustion analysis window.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void CombustionAnalysisButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens the empirical formula derivation window.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void EmpiricalFormulaDerivationButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens the periodic table window.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void PeriodicTableButtonClick(object sender, EventArgs e)
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

        /// <summary>
        /// Opens the stoichiometry window.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void StoichiometryButtonClick(object sender, EventArgs e)
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

        /// <summary>
        /// Opens the unit conversion window.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void UnitConversionButtonClick(object sender, EventArgs e)
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
