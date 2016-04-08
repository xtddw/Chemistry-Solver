using System;

namespace BSmith.ChemistrySolver.Interfaces
{
    /// <summary>
    /// The interface that contains the UnitConverter's event handlers.
    /// </summary>
    public interface IUnitConversion
    {
        void ConversionTypeSelectedIndexChanged(object sender, EventArgs e);
        void InputAmountTextChanged(object sender, EventArgs e);
        void InputUnitSelectedIndexChanged(object sender, EventArgs e);
        void OutputAmountTextChanged(object sender, EventArgs e);
        void OutputUnitSelectedIndexChanged(object sender, EventArgs e);
        void UnitControllerFormLoad(object sender, EventArgs e);
    }
}
