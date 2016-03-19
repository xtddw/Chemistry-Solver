using System;

namespace BSmith.ChemistrySolver.Interfaces
{
    /// <summary>
    /// The interface containing the launcher controller's event handlers.
    /// </summary>
    public interface ILauncher
    {
        void BalanceEquationsButtonClick(object sender, EventArgs e);
        void CombustionAnalysisButtonClick(object sender, EventArgs e);
        void EmpiricalFormulaDerivationButtonClick(object sender, EventArgs e);
        void PeriodicTableButtonClick(object sender, EventArgs e);
        void StoichiometryButtonClick(object sender, EventArgs e);
        void UnitConversionButtonClick(object sender, EventArgs e);
    }
}
