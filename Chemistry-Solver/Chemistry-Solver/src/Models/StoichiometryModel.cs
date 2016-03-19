using BSmith.Chemistry;

namespace BSmith.ChemistrySolver.Models
{
    /// <summary>
    /// The model of the stoichiometry controller.
    /// </summary>
    public class StoichiometryModel
    {
        /// <summary>
        /// The chemical equation used in the stoichiometry controller to supply molecules for dimensional analysis.
        /// </summary>
        public ChemicalEquation Equation { get; set; }

        /// <summary>
        /// The input value used when performing <see cref="Stoichiometry"/>. It represents the value that you want to convert to the desired output.
        /// </summary>
        public Value InputValue { get; set; }

        /// <summary>
        /// The converted value, after performing <see cref="Stoichiometry"/>, in the desired units.
        /// </summary>
        public Value OutputValue { get; set; }

        /// <summary>
        /// Creates a new stoichiometry model.
        /// </summary>
        public StoichiometryModel()
        {
            Equation = new ChemicalEquation();
            InputValue = new Value();
            OutputValue = new Value();
        }
    }
}
