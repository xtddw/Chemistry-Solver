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
        public ChemicalEquation Equation { get; set; } = new ChemicalEquation();

        /// <summary>
        /// Creates a new stoichiometry model.
        /// </summary>
        public StoichiometryModel()
        {
            ChemicalEquation.PTable = new PeriodicTable("..\\..\\data\\ElementData.csv");
        }
    }
}
