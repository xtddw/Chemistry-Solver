using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Interfaces
{
    /// <summary>
    /// The interface that contains the event handlers for the periodic table controller.
    /// </summary>
    public interface IPeriodicTable
    {
        void ElementMouseOver(object sender, MouseEventArgs e);
    }
}
