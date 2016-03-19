using System;

namespace BSmith.ChemistrySolver.Interfaces
{
    /// <summary>
    /// The interface containing the event handlers for the stoichiometry controller.
    /// </summary>
    public interface IStoichiometry
    {
        void CalculateResultButtonClick(object sender, EventArgs e);
        void ClearInputButtonClick(object sender, EventArgs e);
        void EnterInputButtonClick(object sender, EventArgs e);
        void InputAmountValueChanged(object sender, EventArgs e);
        void InputMoleculeSelectionChanged(object sender, EventArgs e);
        void InputUnitSelectionChanged(object sender, EventArgs e);
        void OutputMoleculeSelectionChanged(object sender, EventArgs e);
        void OutputUnitSelectionChanged(object sender, EventArgs e);
    }
}
