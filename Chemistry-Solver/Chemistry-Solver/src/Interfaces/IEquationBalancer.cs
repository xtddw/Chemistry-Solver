using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSmith.ChemistrySolver.Interfaces
{
    /// <summary>
    /// Interface that contains the event handlers for the equation balancer controller.
    /// </summary>
    public interface IEquationBalancer
    {
        void BalanceButtonClick(object sender, EventArgs e);
        void ClearEquationButtonClick(object sender, EventArgs e);
        void ElementLabelClick(object sender, EventArgs e);
        void SeparatorLabelClick(object sender, EventArgs e);
    }
}
