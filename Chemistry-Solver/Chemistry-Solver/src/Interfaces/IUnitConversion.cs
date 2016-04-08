using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSmith.ChemistrySolver.Interfaces
{
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
