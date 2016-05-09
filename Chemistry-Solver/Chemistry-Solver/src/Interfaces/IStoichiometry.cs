using System;

namespace BSmith.ChemistrySolver.Interfaces
{
    /// <summary>
    /// The interface containing the event handlers for the stoichiometry controller.
    /// </summary>
    public interface IStoichiometry
    {
        void ClearEquationInputButtonClick(object sender, EventArgs e);
        void EquationEnterButtonClick(object sender, EventArgs e);
        void InputAmountValueChanged(object sender, EventArgs e);
        void InputMoleculeSelectionChanged(object sender, EventArgs e);
        void InputUnitSelectionChanged(object sender, EventArgs e);
        void OutputAmountValueChanged(object sender, EventArgs e);
        void OutputMoleculeSelectionChanged(object sender, EventArgs e);
        void OutputUnitSelectionChanged(object sender, EventArgs e);
        void StoichiometryFormLoad(object sender, EventArgs e);
    }
}
