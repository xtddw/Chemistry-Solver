namespace BSmith.ChemistrySolver.Models
{
    /// <summary>
    /// The model for the launcher form in the application.
    /// </summary>
    public class LauncherModel
    {
        /// <summary>
        /// The equation balancer controller.
        /// </summary>
        public Controllers.EquationBalancerController EquationBalancer { get; set; }

        /// <summary>
        /// The periodic table controller.
        /// </summary>
        public Controllers.PeriodicTableController PeriodicTable { get; set; }

        /// <summary>
        /// The stoichiometry controller.
        /// </summary>
        public Controllers.StoichiometryController Stoichiometry { get; set; }

        /// <summary>
        /// The unit conversion controller.
        /// </summary>
        public Controllers.UnitConversionController UnitConversion { get; set; }

        /// <summary>
        /// Creates a new model, and assigns the controllers to the launcher.
        /// </summary>
        /// <param name="launcher"></param>
        public LauncherModel(Controllers.LauncherController launcher)
        {
            EquationBalancer = new Controllers.EquationBalancerController();
            EquationBalancer.Owner = launcher;

            PeriodicTable = new Controllers.PeriodicTableController();
            PeriodicTable.Owner = launcher;

            Stoichiometry = new Controllers.StoichiometryController();
            Stoichiometry.Owner = launcher;

            UnitConversion = new Controllers.UnitConversionController();
            UnitConversion.Owner = launcher;
        }
    }
}
