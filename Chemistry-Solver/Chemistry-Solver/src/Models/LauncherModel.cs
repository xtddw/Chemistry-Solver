namespace BSmith.ChemistrySolver.Models
{
    public class LauncherModel
    {
        private Controllers.EquationBalancerController equation_balancer_form_;
        public Controllers.EquationBalancerController EquationBalancer { get { return equation_balancer_form_; } set { equation_balancer_form_ = value; } }

        private Controllers.PeriodicTableController periodic_table_form_;
        public Controllers.PeriodicTableController PeriodicTable { get { return periodic_table_form_; } set { periodic_table_form_ = value; } }

        private Controllers.StoichiometryController stoichiometry_form_;
        public Controllers.StoichiometryController Stoichiometry { get { return stoichiometry_form_; } set { stoichiometry_form_ = value; } }

        private Controllers.UnitConversionController unit_converter_form_;
        public Controllers.UnitConversionController UnitConversion { get { return unit_converter_form_; } set { unit_converter_form_ = value; } }

        public LauncherModel(Controllers.LauncherController launcher)
        {
            equation_balancer_form_ = new Controllers.EquationBalancerController();
            equation_balancer_form_.Owner = launcher;

            periodic_table_form_ = new Controllers.PeriodicTableController();
            periodic_table_form_.Owner = launcher;

            stoichiometry_form_ = new Controllers.StoichiometryController();
            stoichiometry_form_.Owner = launcher;

            unit_converter_form_ = new Controllers.UnitConversionController();
            unit_converter_form_.Owner = launcher;
        }
    }
}
