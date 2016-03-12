using BSmith.Chemistry;

namespace BSmith.ChemistrySolver.Models
{
    public class EquationBalancerModel
    {
        private ChemicalEquation equation_;
        public ChemicalEquation Equation { get { return equation_; } set { equation_ = value; } }

        public EquationBalancerModel()
        {
            equation_ = new ChemicalEquation();
        }
    }
}
