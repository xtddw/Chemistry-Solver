using BSmith.Chemistry;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
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
        private Models.StoichiometryModel model_;

        /// <summary>
        /// Creates a new stoichiometry controller.
        /// </summary>
        public StoichiometryController()
        {
            InitializeComponent();
            model_ = new Models.StoichiometryModel();
        }

        private void SetAmountText(string amount)
        {
            rtbox_result.SelectionFont = new Font("Calibri", 14);
            rtbox_result.SelectionColor = Color.MediumPurple;

            var amt = 0.0;
            double.TryParse(amount, out amt);

            rtbox_result.SelectedText = System.Math.Round(amt, 4).ToString();
        }

        private void SetSubscriptText(string subscript)
        {
            rtbox_result.SelectionFont = new Font("Calibri", 9);
            rtbox_result.SelectionCharOffset = -5;

            var subscript_value = 0;
            int.TryParse(subscript, out subscript_value);
            rtbox_result.SelectedText = (subscript_value != 1) ? subscript : string.Empty;
        }

        private void SetNormalText(string text)
        {
            rtbox_result.SelectionFont = new Font("Calibri", 14);
            rtbox_result.SelectionColor = Color.Black;
            rtbox_result.SelectionCharOffset = 0;
            rtbox_result.SelectedText = text;
        }

        private void SetMoleculeText(ParticleQuantityPair<Molecule, int> molecule)
        {
            for (var i = 0; i < molecule.Particle.Elements.Count; ++i)
            {
                SetNormalText(molecule.Particle.Elements[i].Particle.Symbol);
                SetSubscriptText(molecule.Particle.Elements[i].Quantity.ToString());
            }
        }

        /// <summary>
        /// Performs the stoichiometry to calculate the desired output.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void CalculateResultButtonClick(object sender, EventArgs e)
        {
            rtbox_result.SelectionAlignment = HorizontalAlignment.Center;
            rtbox_result.Clear();

            var stoich = new Stoichiometry();
            model_.OutputValue = stoich.CalculateOutput(model_.InputValue, model_.OutputValue);

            SetAmountText(model_.InputValue.Amount.ToString());
            SetNormalText(" ");
            SetNormalText(model_.InputValue.Units);
            SetNormalText(" of ");
            SetMoleculeText(model_.InputValue.Substance);
            SetNormalText(" = ");
            SetAmountText(model_.OutputValue.Amount.ToString());
            SetNormalText(" ");
            SetNormalText(model_.OutputValue.Units);
            SetNormalText(" of ");
            SetMoleculeText(model_.OutputValue.Substance);
        }

        /// <summary>
        /// Clears the form of user input.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void ClearInputButtonClick(object sender, EventArgs e)
        {
            //Clear Input
            model_.Equation = new ChemicalEquation();
            model_.OutputValue = new Value();
            model_.InputValue = new Value();
            tbox_equation_input.Clear();

            //Clear Reactants / Products
            lbox_output.Items.Clear();
            lbox_input.Items.Clear();
            tbox_input_amount.Clear();
            cbox_output_unit.SelectedItem = null;
            cbox_intput_unit.SelectedItem = null;

            //Clear results
            rtbox_result.Clear();
        }

        /// <summary>
        /// Loads user input into the form so it can be used for calculations.
        /// </summary>
        /// <param name="sender">The button that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void EnterInputButtonClick(object sender, EventArgs e)
        {
            model_.Equation = ChemicalEquation.InterpretEquation(tbox_equation_input.Text);
            model_.InputValue = new Value();
            model_.OutputValue = new Value();

            lbox_output.Items.Clear();
            lbox_input.Items.Clear();
            rtbox_result.Clear();
            tbox_input_amount.Clear();
            cbox_output_unit.SelectedItem = null;
            cbox_intput_unit.SelectedItem = null;

            if (model_.Equation.Reactants.Count != 0 && model_.Equation.Products.Count != 0)
            {
                if (!model_.Equation.IsBalanced())
                {
                    model_.Equation.Balance();
                }

                //populate input and output listboxes
                foreach(ParticleQuantityPair<Molecule, int> molecule in model_.Equation.Reactants)
                {
                    lbox_input.Items.Add(molecule.ToString());
                    lbox_output.Items.Add(molecule.ToString());
                }

                foreach (ParticleQuantityPair<Molecule, int> molecule in model_.Equation.Products)
                {
                    lbox_input.Items.Add(molecule.ToString());
                    lbox_output.Items.Add(molecule.ToString());
                }
            }
        }

        /// <summary>
        /// Updates the model's input variable with new quantity information.
        /// </summary>
        /// <param name="sender">The textbox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void InputAmountValueChanged(object sender, EventArgs e)
        {
            var amount = 0.0;
            double.TryParse(((TextBox)sender).Text, out amount);
            model_.InputValue.Amount = amount;
        }

        /// <summary>
        /// Updates the model's input variable with new substance information.
        /// </summary>
        /// <param name="sender">The list box that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void InputMoleculeSelectionChanged(object sender, EventArgs e)
        {
            var coefficient = Regex.Matches(lbox_input.Text, @"(\d{1,})[A-Z]{1}[a-z]{0,2}");
            var amount = 0;
            int.TryParse(coefficient[0].Groups[1].Value, out amount);

            var molecule = ChemicalEquation.CreateMolecule(lbox_input.Text);
            model_.InputValue.Substance = new ParticleQuantityPair<Molecule, int>(molecule, amount);
        }

        /// <summary>
        /// Updates the model's input variable with new unit information.
        /// </summary>
        /// <param name="sender">The combobox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void InputUnitSelectionChanged(object sender, EventArgs e)
        {
            if (cbox_intput_unit.SelectedItem != null)
            {
                model_.InputValue.Units = cbox_intput_unit.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// Updates the model's output variable with new substance information.
        /// </summary>
        /// <param name="sender">The listbox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void OutputMoleculeSelectionChanged(object sender, EventArgs e)
        {
            var coefficient = Regex.Matches(lbox_output.Text, @"(\d{1,})[A-Z]{1}[a-z]{0,2}");
            var amount = 0;
            int.TryParse(coefficient[0].Groups[1].Value, out amount);

            var molecule = ChemicalEquation.CreateMolecule(lbox_output.Text);
            model_.OutputValue.Substance = new ParticleQuantityPair<Molecule, int>(molecule, amount);
        }

        /// <summary>
        /// Updates the model's output variable with new unit information.
        /// </summary>
        /// <param name="sender">The listbox that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void OutputUnitSelectionChanged(object sender, EventArgs e)
        {
            if(cbox_output_unit.SelectedItem != null)
            {
                model_.OutputValue.Units = cbox_output_unit.SelectedItem.ToString();
            }
        }
    }
}