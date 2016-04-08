using BSmith.ChemistrySolver.Interfaces;
using BSmith.ChemistrySolver.Utility;
using System;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    /// <summary>
    /// The controller for the Unit Converter tool.
    /// </summary>
    public partial class UnitConversionController : Form, IUnitConversion
    {
        /// <summary>
        /// The model that contains the data for the tool.
        /// </summary>
        private Models.UnitConversionModel model_;

        /// <summary>
        /// Constructs a new <see cref="UnitConversionController"/>.
        /// </summary>
        public UnitConversionController()
        {
            model_ = new Models.UnitConversionModel();
            InitializeComponent();
        }

        /// <summary>
        /// The event handler for when the unit conversion type is changed.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
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

                // Focusing causes the application force a unit conversion with the value in the input text box.
                tbox_InputAmount.Focus();
                tbox_InputAmount.Text = 1.ToString();
                cbox.Focus();
            }
        }

        /// <summary>
        /// The event handler that performs unit conversion every time the input amount is changed, and has focus.
        /// </summary>
        /// <param name="sender">The textbox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
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

                tbox_OutputAmount.Text = model_.UnitConversion.PerformConversion().Value.ToString();
            }
        }

        /// <summary>
        /// The event handler for when the input unit is changed.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void InputUnitSelectedIndexChanged(object sender, EventArgs e)
        {
            var cbox = sender as ComboBox;

            model_.UnitConversion.InputValue.LowerUnits.Clear();
            model_.UnitConversion.InputValue.UpperUnits.Clear();
            model_.UnitConversion.InputValue.UpperUnits.Add(cbox_InputUnit.Text.ToString());

            var inputValue = 0d;
            double.TryParse(tbox_InputAmount.Text, out inputValue);
            model_.UnitConversion.InputValue.Value = inputValue;

            var canceledUnit = cbox_InputUnit.SelectedItem?.ToString() ?? string.Empty;
            var remainingUnit = cbox_OutputUnit.SelectedItem?.ToString() ?? string.Empty;
            model_.UnitConversion.ConversionRatio = model_.UnitConversion.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);

            tbox_OutputAmount.Text = model_.UnitConversion.PerformConversion().Value.ToString();
        }

        /// <summary>
        /// The event handler that performs unit conversion every time the output amount is changed, when it has focus.
        /// </summary>
        /// <param name="sender">The textbox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
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

                model_.UnitConversion.InputValue = model_.UnitConversion.PerformConversion();
                tbox_InputAmount.Text = model_.UnitConversion.InputValue.Value.ToString();
            }
        }

        /// <summary>
        /// The event handler for when the output unit is changed.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void OutputUnitSelectedIndexChanged(object sender, EventArgs e)
        {
            var cbox = sender as ComboBox;
            var canceledUnit = model_.UnitConversion.InputValue.UpperUnits[0];
            var remainingUnit = cbox.SelectedItem?.ToString() ?? string.Empty;

            model_.UnitConversion.ConversionRatio = model_.UnitConversion.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);
            tbox_OutputAmount.Text = model_.UnitConversion.PerformConversion().Value.ToString();
        }

        /// <summary>
        /// The event handler that loads conversion tables from the hard drive and sets initial values into the input and output text boxes.
        /// </summary>
        /// <param name="sender">The form that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void UnitControllerFormLoad(object sender, EventArgs e)
        {
            model_.UnitConversion.LoadConversionTablesFromCSV("..\\..\\data\\UnitConversion.csv");

            foreach(var table in model_.UnitConversion.TableData)
            {
                cbox_ConversionType.Items.Add(table.ConversionType);
            }

            // Changing the selected index of the conversionType sets the input amount to 1.
            cbox_ConversionType.Sorted = true;
            cbox_ConversionType.SelectedIndex = 0;

            var canceledUnit = cbox_InputUnit.SelectedItem?.ToString() ?? string.Empty;
            var remainingUnit = cbox_OutputUnit.SelectedItem?.ToString() ?? string.Empty;

            model_.UnitConversion.ConversionRatio = model_.UnitConversion.ConversionTable.GetConversionValue(canceledUnit, remainingUnit);
            model_.UnitConversion.InputValue.UpperUnits.Clear();
            model_.UnitConversion.InputValue.UpperUnits.Add(canceledUnit);

            var inputValue = 0d;
            double.TryParse(tbox_InputAmount.Text, out inputValue);
            model_.UnitConversion.InputValue.Value = inputValue;

            tbox_OutputAmount.Text = model_.UnitConversion.PerformConversion().Value.ToString();
        }
    }
}
