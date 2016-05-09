using BSmith.Chemistry;
using BSmith.ChemistrySolver.Utility;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    /// <summary>
    /// The controller for the stoichiometry window.
    /// </summary>
    public partial class StoichiometryController : Form, Interfaces.IStoichiometry
    {
        /// <summary>
        /// The model for the controller.
        /// </summary>
        private Models.StoichiometryModel model_ = new Models.StoichiometryModel();

        private Stoichiometry stoichiometry_ = new Stoichiometry();

        /// <summary>
        /// Creates a new stoichiometry controller.
        /// </summary>
        public StoichiometryController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clears equation information from the window, effectively resetting it back to default values.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void ClearEquationInputButtonClick(object sender, EventArgs e)
        {
            stoichiometry_ = new Stoichiometry();
            model_.Equation.Reactants.Clear();
            model_.Equation.Products.Clear();

            tbox_equation_input.Clear();
            tbox_input_amount.Clear();
            tbox_output_amount.Clear();
            cbox_input_molecule.Items.Clear();
            cbox_output_molecule.Items.Clear();
        }

        /// <summary>
        /// Enters the user-specified equation into the application.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void EquationEnterButtonClick(object sender, EventArgs e)
        {
            model_.Equation = new ChemicalEquation(tbox_equation_input.Text);
            model_.Equation.Balance();

            if (model_.Equation.IsBalanced())
            {
                tbox_equation_input.Text = model_.Equation.ToString();

                var reactants = model_.Equation.Reactants.Select(reactant => $"{reactant.Item2}{reactant.Item1}").ToArray();
                var products = model_.Equation.Products.Select(product => $"{product.Item2}{product.Item1}").ToArray();

                cbox_input_molecule.Items.Clear();
                cbox_output_molecule.Items.Clear();

                cbox_input_molecule.Items.AddRange(reactants);
                cbox_input_molecule.Items.AddRange(products);
                cbox_input_molecule.SelectedIndex = 0;

                cbox_output_molecule.Items.AddRange(reactants);
                cbox_output_molecule.Items.AddRange(products);
                cbox_output_molecule.SelectedIndex = reactants.Length;

                stoichiometry_.CreateConversionTable(model_.Equation);

                // Focusing causes the text change in the input amount tbox to force a conversion.
                tbox_input_amount.Focus();
                tbox_input_amount.Text = 1.ToString();
            }
        }

        /// <summary>
        /// Calculates a stoichiometric conversion as the user types values in to the input molecule amount textbox.
        /// </summary>
        /// <param name="sender">The textbox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void InputAmountValueChanged(object sender, EventArgs e)
        {
            var inputValue = sender as TextBox;

            if (inputValue.Focused && stoichiometry_.UnitConverter.ConversionTable.Table.Data.Count > 0)
            {
                var value = 0d;
                double.TryParse(inputValue.Text, out value);

                var canceledUnit = (cbox_input_unit.SelectedItem.ToString().Equals("grams")) ? "mass" : cbox_input_unit.SelectedItem.ToString();
                var canceledMolecule = $"{cbox_input_molecule.SelectedItem} {canceledUnit}";
                var remainingUnit = (cbox_output_unit.SelectedItem.ToString().Equals("grams")) ? "mass" : cbox_output_unit.SelectedItem.ToString();
                var remainingMolecule = $"{cbox_output_molecule.SelectedItem} {remainingUnit}";

                stoichiometry_.UnitConverter.InputValue.Value = value;
                stoichiometry_.UnitConverter.ConversionRatio = stoichiometry_.UnitConverter.ConversionTable.GetConversionValue(canceledMolecule, remainingMolecule);

                tbox_output_amount.Text = stoichiometry_.UnitConverter.PerformConversion().Value.ToString();             
            }
        }

        /// <summary>
        /// Recalculates the stoichiometric conversion with the new input molecule selection.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void InputMoleculeSelectionChanged(object sender, EventArgs e)
        {
            var cbox = sender as ComboBox;

            if (stoichiometry_.UnitConverter.ConversionTable.Table.Data.Count > 0)
            {
                var canceledUnit =
               ((cbox_input_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
               "mass" : cbox_input_unit.SelectedItem?.ToString() ?? string.Empty;

                var canceledMolecule =
                   (!string.IsNullOrEmpty(canceledUnit)) ?
                   $"{cbox_input_molecule.SelectedItem} {canceledUnit}" : string.Empty;

                var remainingUnit =
                    ((cbox_output_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
                    "mass" : cbox_output_unit.SelectedItem?.ToString() ?? string.Empty;

                var remainingMolecule =
                   (!string.IsNullOrEmpty(remainingUnit)) ?
                   $"{cbox_output_molecule.SelectedItem} {remainingUnit}" : string.Empty;

                if (!string.IsNullOrEmpty(canceledMolecule) && !string.IsNullOrEmpty(remainingMolecule))
                {
                    stoichiometry_.UnitConverter.InputValue.LowerUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Add(canceledMolecule);

                    var inputValue = 0d;
                    double.TryParse(tbox_input_amount.Text, out inputValue);
                    stoichiometry_.UnitConverter.InputValue.Value = inputValue;

                    stoichiometry_.UnitConverter.ConversionRatio = stoichiometry_.UnitConverter.ConversionTable.GetConversionValue(canceledMolecule, remainingMolecule);

                    tbox_output_amount.Text = stoichiometry_.UnitConverter.PerformConversion().Value.ToString();
                }
            }       
        }

        /// <summary>
        /// Recalculates the stoichiometric conversion with the new input unit selection.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void InputUnitSelectionChanged(object sender, EventArgs e)
        {
            var cbox = sender as ComboBox;

            if (stoichiometry_.UnitConverter.ConversionTable.Table.Data.Count != 0)
            {
                var canceledUnit =
               ((cbox_input_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
               "mass" : cbox_input_unit.SelectedItem?.ToString() ?? string.Empty;

                var canceledMolecule =
                   (!string.IsNullOrEmpty(canceledUnit)) ?
                   $"{cbox_input_molecule.SelectedItem} {canceledUnit}" : string.Empty;

                var remainingUnit =
                    ((cbox_output_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
                    "mass" : cbox_output_unit.SelectedItem?.ToString() ?? string.Empty;

                var remainingMolecule =
                   (!string.IsNullOrEmpty(remainingUnit)) ?
                   $"{cbox_output_molecule.SelectedItem} {remainingUnit}" : string.Empty;

                if (!string.IsNullOrEmpty(canceledMolecule) && !string.IsNullOrEmpty(remainingMolecule))
                {
                    stoichiometry_.UnitConverter.InputValue.LowerUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Add(canceledMolecule);

                    var inputValue = 0d;
                    double.TryParse(tbox_input_amount.Text, out inputValue);
                    stoichiometry_.UnitConverter.InputValue.Value = inputValue;

                    stoichiometry_.UnitConverter.ConversionRatio = stoichiometry_.UnitConverter.ConversionTable.GetConversionValue(canceledMolecule, remainingMolecule);

                    tbox_output_amount.Text = stoichiometry_.UnitConverter.PerformConversion().Value.ToString();
                }
            }
        }

        /// <summary>
        /// Calculates a stoichiometric conversion as the user types values in to the output molecule amount textbox.
        /// </summary>
        /// <param name="sender">The textbox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void OutputAmountValueChanged(object sender, EventArgs e)
        {
            var inputValue = sender as TextBox;

            if (inputValue.Focused && stoichiometry_.UnitConverter.ConversionTable.Table.Data.Count > 0)
            {
                var value = 0d;
                double.TryParse(inputValue.Text, out value);

                var canceledUnit = (cbox_output_unit.SelectedItem.ToString().Equals("grams")) ? "mass" : cbox_output_unit.SelectedItem.ToString();
                var canceledMolecule = $"{cbox_output_molecule.SelectedItem} {canceledUnit}";
                var remainingUnit = (cbox_input_unit.SelectedItem.ToString().Equals("grams")) ? "mass" : cbox_input_unit.SelectedItem.ToString();
                var remainingMolecule = $"{cbox_input_molecule.SelectedItem} {remainingUnit}";

                stoichiometry_.UnitConverter.InputValue.Value = value;
                stoichiometry_.UnitConverter.ConversionRatio = stoichiometry_.UnitConverter.ConversionTable.GetConversionValue(canceledMolecule, remainingMolecule);

                stoichiometry_.UnitConverter.InputValue = stoichiometry_.UnitConverter.PerformConversion();
                tbox_input_amount.Text = stoichiometry_.UnitConverter.InputValue.Value.ToString();
            }
        }

        /// <summary>
        /// Recalculates the stoichiometric conversion with the new output unit selection.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void OutputMoleculeSelectionChanged(object sender, EventArgs e)
        {
            if (stoichiometry_.UnitConverter.ConversionTable.Table.Data.Count != 0)
            {
                var canceledUnit =
               ((cbox_input_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
               "mass" : cbox_input_unit.SelectedItem?.ToString() ?? string.Empty;

                var canceledMolecule =
                   (!string.IsNullOrEmpty(canceledUnit)) ?
                   $"{cbox_input_molecule.SelectedItem} {canceledUnit}" : string.Empty;

                var remainingUnit =
                    ((cbox_output_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
                    "mass" : cbox_output_unit.SelectedItem?.ToString() ?? string.Empty;

                var remainingMolecule =
                   (!string.IsNullOrEmpty(remainingUnit)) ?
                   $"{cbox_output_molecule.SelectedItem} {remainingUnit}" : string.Empty;

                if (!string.IsNullOrEmpty(canceledMolecule) && !string.IsNullOrEmpty(remainingMolecule))
                {
                    stoichiometry_.UnitConverter.InputValue.LowerUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Add(canceledMolecule);

                    var inputValue = 0d;
                    double.TryParse(tbox_input_amount.Text, out inputValue);
                    stoichiometry_.UnitConverter.InputValue.Value = inputValue;

                    stoichiometry_.UnitConverter.ConversionRatio = stoichiometry_.UnitConverter.ConversionTable.GetConversionValue(canceledMolecule, remainingMolecule);

                    tbox_output_amount.Text = stoichiometry_.UnitConverter.PerformConversion().Value.ToString();
                }
            }
        }

        /// <summary>
        /// Recalculates the stoichiometric conversion with the new output unit selection.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void OutputUnitSelectionChanged(object sender, EventArgs e)
        {
            if (stoichiometry_.UnitConverter.ConversionTable.Table.Data.Count != 0)
            {
                var canceledUnit =
               ((cbox_input_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
               "mass" : cbox_input_unit.SelectedItem?.ToString() ?? string.Empty;

                var canceledMolecule =
                   (!string.IsNullOrEmpty(canceledUnit)) ?
                   $"{cbox_input_molecule.SelectedItem} {canceledUnit}" : string.Empty;

                var remainingUnit =
                    ((cbox_output_unit.SelectedItem?.ToString() ?? string.Empty).Equals("grams")) ?
                    "mass" : cbox_output_unit.SelectedItem?.ToString() ?? string.Empty;

                var remainingMolecule =
                   (!string.IsNullOrEmpty(remainingUnit)) ?
                   $"{cbox_output_molecule.SelectedItem} {remainingUnit}" : string.Empty;

                if (!string.IsNullOrEmpty(canceledMolecule) && !string.IsNullOrEmpty(remainingMolecule))
                {
                    stoichiometry_.UnitConverter.InputValue.LowerUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Clear();
                    stoichiometry_.UnitConverter.InputValue.UpperUnits.Add(canceledMolecule);

                    var inputValue = 0d;
                    double.TryParse(tbox_input_amount.Text, out inputValue);
                    stoichiometry_.UnitConverter.InputValue.Value = inputValue;

                    stoichiometry_.UnitConverter.ConversionRatio = stoichiometry_.UnitConverter.ConversionTable.GetConversionValue(canceledMolecule, remainingMolecule);

                    tbox_output_amount.Text = stoichiometry_.UnitConverter.PerformConversion().Value.ToString();
                }
            }
        }

        /// <summary>
        /// Sets default values for both of the unit comboboxes.
        /// </summary>
        /// <param name="sender">The form that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void StoichiometryFormLoad(object sender, EventArgs e)
        {
            cbox_input_unit.SelectedIndex = 0;
            cbox_output_unit.SelectedIndex = 0;
        }
    }
}