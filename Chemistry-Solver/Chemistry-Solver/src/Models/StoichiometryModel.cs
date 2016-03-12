using BSmith.Chemistry;

namespace BSmith.ChemistrySolver.Models
{
    public class StoichiometryModel
    {
        private ChemicalEquation equation_;
        public ChemicalEquation Equation { get { return equation_; } set { equation_ = value; } }

        private Value input_value_;
        public Value InputValue { get { return input_value_; } set { input_value_ = value; } }

        private Value output_value_;
        public Value OutputValue { get { return output_value_; } set { output_value_ = value; } }

        public StoichiometryModel()
        {
            equation_ = new ChemicalEquation();
            input_value_ = new Value();
            output_value_ = new Value();
        }
    }
}
