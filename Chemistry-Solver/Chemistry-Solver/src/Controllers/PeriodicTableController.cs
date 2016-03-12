using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    public partial class PeriodicTableController : Form
    {
        private Models.PeriodicTableModel model_;

        public PeriodicTableController()
        {          
            InitializeComponent();
            model_ = new Models.PeriodicTableModel();
        }

        private void element_MouseOver(object sender, MouseEventArgs e)
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

        private void element_Click(object sender, MouseEventArgs e)
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
