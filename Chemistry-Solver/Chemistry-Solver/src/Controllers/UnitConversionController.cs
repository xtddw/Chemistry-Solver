using BSmith.ChemistrySolver.Interfaces;
using BSmith.ChemistrySolver.Utility;
using System;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    public partial class UnitConversionController : Form, IUnitConversion
    {
        private Models.UnitConversionModel model_;

        public UnitConversionController()
        {
            InitializeComponent();
            model_ = new Models.UnitConversionModel();
        }

        public void ConversionTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            var cbox = sender as ComboBox;

            if (!string.IsNullOrEmpty(cbox.SelectedItem?.ToString()))
            {
                model_.UnitConversion.ConversionTable = model_.UnitConversion.GetConversionTable(cbox.SelectedItem.ToString());

                cbox_InputUnit.Items.Clear();
                cbox_InputUnit.Items.AddRange(model_.UnitConversion.ConversionTable.Table.GetColumnData(model_.UnitConversion.ConversionTable.ConversionType).ToArray());
                cbox_InputUnit.SelectedIndex = 0;

                cbox_OutputUnit.Items.Clear();
                cbox_OutputUnit.Items.AddRange(model_.UnitConversion.ConversionTable.Table.GetColumnData(model_.UnitConversion.ConversionTable.ConversionType).ToArray());
                cbox_OutputUnit.SelectedIndex = 1;
            }
        }

        public void InputAmountTextChanged(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;

            if (tbox.Focused)
            {
                var inputValue = 0d;
                double.TryParse(tbox.Text, out inputValue);

                model_.UnitConversion.InputValue.Value = inputValue;

                var canceledUnit = cbox_InputUnit.SelectedItem?.ToString() ?? string.Empty;
                var remainingUnit = cbox_OutputUnit.SelectedItem?.ToString() ?? string.Empty;

                model_.UnitConversion.ConversionRatio = model_.UnitConversion.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);

                tbox_OutputAmount.Text = (model_.UnitConversion.InputValue * model_.UnitConversion.ConversionRatio).Value.ToString();
            }
        }

        public void InputUnitSelectedIndexChanged(object sender, EventArgs e)
        {
            var cbox = sender as ComboBox;

            if (model_.UnitConversion.InputValue.Equals(null))
            {
                model_.UnitConversion.InputValue = new ConversionValue();
            }

            model_.UnitConversion.InputValue.UpperUnits.Clear();
            model_.UnitConversion.InputValue.UpperUnits.Add(cbox.SelectedItem?.ToString() ?? string.Empty);

            var inputValue = 0d;
            double.TryParse(tbox_InputAmount.Text, out inputValue);

            model_.UnitConversion.InputValue.Value = inputValue;
        }

        public void OutputAmountTextChanged(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;

            if (tbox.Focused)
            {
                var inputValue = 0d;
                double.TryParse(tbox.Text, out inputValue);

                model_.UnitConversion.InputValue.Value = inputValue;

                var canceledUnit = cbox_OutputUnit.SelectedItem?.ToString() ?? string.Empty;
                var remainingUnit = cbox_InputUnit.SelectedItem?.ToString() ?? string.Empty;

                model_.UnitConversion.ConversionRatio = model_.UnitConversion.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);

                tbox_InputAmount.Text = (model_.UnitConversion.InputValue * model_.UnitConversion.ConversionRatio).Value.ToString();
            }
        }

        public void OutputUnitSelectedIndexChanged(object sender, EventArgs e)
        {
            var cbox = sender as ComboBox;
            var canceledUnit = model_.UnitConversion.InputValue.UpperUnits[0];
            var remainingUnit = cbox.SelectedItem?.ToString() ?? string.Empty;

            model_.UnitConversion.ConversionRatio = model_.UnitConversion.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);
        }

        public void UnitControllerFormLoad(object sender, EventArgs e)
        {
            model_.UnitConversion.LoadConversionTablesFromCSV("..\\..\\data\\UnitConversion.csv");

            foreach(var table in model_.UnitConversion.TableData)
            {
                cbox_ConversionType.Items.Add(table.ConversionType);
            }

            cbox_ConversionType.Sorted = true;
            cbox_ConversionType.SelectedIndex = 0;
        }
    }
}
