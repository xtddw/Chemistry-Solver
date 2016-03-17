using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    /// <summary>
    /// The controller for the periodic table window.
    /// </summary>
    public partial class PeriodicTableController : Form, Interfaces.IPeriodicTable
    {
        /// <summary>
        /// The model for the controller.
        /// </summary>
        private Models.PeriodicTableModel model_;

        /// <summary>
        /// Creates a new periodic table controller.
        /// </summary>
        public PeriodicTableController()
        {          
            InitializeComponent();
            model_ = new Models.PeriodicTableModel();
        }

        /// <summary>
        /// Loads the element information into the large element preview upon mouseover.
        /// </summary>
        /// <param name="sender">The tablelayoutpanel that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void ElementMouseOver(object sender, MouseEventArgs e)
        {
            var element = sender as TableLayoutPanel;

            var atomic_number_display = tlPElementDisplay.GetControlFromPosition(0, 0) as Label;
            var symbol_display = tlPElementDisplay.GetControlFromPosition(0, 1) as Label;
            var name_display = tlPElementDisplay.GetControlFromPosition(0, 2) as Label;
            var molecular_weight_display = tlPElementDisplay.GetControlFromPosition(0, 3) as Label;

            var atomic_number_element = element.GetControlFromPosition(0, 0) as Label;
            var symbol_element = element.GetControlFromPosition(0, 1) as Label;
            var name_element = element.GetControlFromPosition(0, 2) as Label;
            var molecular_weight_element = element.GetControlFromPosition(0, 3) as Label;

            atomic_number_display.Text = atomic_number_element.Text;
            symbol_display.Text = symbol_element.Text;
            name_display.Text = name_element.Text;
            molecular_weight_display.Text = molecular_weight_element.Text;
            tlPElementDisplay.BackColor = element.BackColor;
        }
    }
}
