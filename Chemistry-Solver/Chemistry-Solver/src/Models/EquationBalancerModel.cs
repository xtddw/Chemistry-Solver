using BSmith.Chemistry;

namespace BSmith.ChemistrySolver.Models
{
    /// <summary>
    /// The model for the equation balancer.
    /// </summary>
    public class EquationBalancerModel
    {
        /// <summary>
        /// The chemical equation interpreted from user input, and is what's balanced.
        /// </summary>
        public ChemicalEquation Equation { get; set; } = new ChemicalEquation();

        /// <summary>
        /// Creates a new equation balancer model.
        /// </summary>
        public EquationBalancerModel()
        {
            ChemicalEquation.PTable = new PeriodicTable("..\\..\\data\\ElementData.csv");
        }
    }
}
