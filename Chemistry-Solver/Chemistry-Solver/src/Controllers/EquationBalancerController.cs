using BSmith.Chemistry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    /// <summary>
    /// The form for the Equation Balancer application.
    /// </summary>
    public partial class EquationBalancerController : Form, Interfaces.IEquationBalancer, Interfaces.IEquationBalancerHelper
    {
        /// <summary>
        /// The model for the equation balancer.
        /// </summary>
        Models.EquationBalancerModel model_;

        /// <summary>
        /// Creates a new equation balancer controller.
        /// </summary>
        public EquationBalancerController()
        {
            model_ = new Models.EquationBalancerModel();
            InitializeComponent();
        }

        /// <summary>
        /// The Event Handler used by the "balance" button in the input section. Balances the equation supplied in the input text box, then displays it in the output rich text box.
        /// </summary>
        /// <param name="sender">The form component that sent the event.</param>
        /// <param name="e">The arguments associated with an onClick event.</param>
        public void BalanceButtonClick(object sender, EventArgs e)
        {
            rtxt_equation_display.Clear();
            model_.Equation = new ChemicalEquation(SimplifyEquationFormat(txt_equation_input.Text));

            if (model_.Equation.Reactants.Count > 0 && model_.Equation.Products.Count > 0)
            {
                model_.Equation.Balance();
            }

            rtxt_equation_display.SelectionAlignment = HorizontalAlignment.Center;

            for (int reactants_index = 0; reactants_index < model_.Equation.Reactants.Count; ++reactants_index)
            {
                SetMoleculeTextFormat(model_.Equation.Reactants[reactants_index]);
                SetDefaultTextFormat((reactants_index < model_.Equation.Reactants.Count - 1) ? " + " : string.Empty);
            }

            if (model_.Equation.Products.Count != 0)
            {
                SetDefaultTextFormat(" --> ");
            }

            for (int products_index = 0; products_index < model_.Equation.Products.Count; ++products_index)
            {
                SetMoleculeTextFormat(model_.Equation.Products[products_index]);
                SetDefaultTextFormat((products_index < model_.Equation.Products.Count - 1) ? " + " : string.Empty);
            }
        }

        /// <summary>
        /// The Event Handler used by the clear button in the input section of the form. Clears the display, the input text box, and the chemical equation in the model.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClearEquationButtonClick(object sender, EventArgs e)
        {
            model_.Equation = new ChemicalEquation();
            txt_equation_input.Clear();
            rtxt_equation_display.Clear();
        }

        /// <summary>
        /// The Event handler used by labels in the periodic table. It adds the element, correctly formatted, into the input text box.
        /// </summary>
        /// <param name="sender">The form component that sent the event.</param>
        /// <param name="e">The arguments associated with an onClick event.</param>
        public void ElementLabelClick(object sender, EventArgs e)
        {
            var element_label = sender as Label;
            var equation_input = txt_equation_input.Text + "1" + element_label.Text + "_(1)";

            txt_equation_input.Text = SimplifyEquationFormat(equation_input);
            txt_equation_input.Select(txt_equation_input.Text.Length, 0); // Set cursor at end of text box.
        }

        /// <summary>
        /// The event handler used by separators, '+' and '-->', in the equation balancer. It adds the separator to the equation text format.
        /// </summary>
        /// <param name="sender">The label that sent the event.</param>
        /// <param name="e">The event's arguments.</param>
        public void SeparatorLabelClick(object sender, EventArgs e)
        {
            var separator = sender as Label;
            txt_equation_input.SelectedText = " " + separator.Text + " ";
        }

        /// <summary>
        /// Condenses the molcules in the list <paramref name="molecules"/> so that only one of each appear, with multiple copies of the same element
        /// being indicated by an increased subscript in that element.
        /// </summary>
        /// <param name="molecules"></param>
        public void CondenseMolecules(List<Tuple<Molecule, int>> molecules)
        {
            for (var i = 0; i < molecules.Count; ++i)
            {
                var molecule = molecules[i].Item1.ToString();
                var elements = Regex.Matches(molecule, @"[A-Z]{1}[a-z]{0,2}");
                var subscripts = Regex.Matches(molecule, @"\b\d{1,}\b");
                var condensedFormat = "1";

                // Iterate over the elements in the molecule
                for (var j = 0; j < elements.Count; ++j)
                {
                    var elementSubscripts = Regex.Matches(molecule, elements[j].Value + @"_\(\d{1,}\)");
                    var subscript_sum = 0;

                    foreach (Match subscript in elementSubscripts)
                    {
                        var subscript_string = Regex.Match(subscript.Value, @"\d{1,}");
                        var subscriptValue = 0;
                        int.TryParse(subscript_string.Value, out subscriptValue);

                        subscript_sum += subscriptValue;
                    }

                    condensedFormat += (!Regex.IsMatch(condensedFormat, elements[j].Value)) ? $"{elements[j].Value}_({subscript_sum})" : string.Empty;

                }

                molecules[i] = Tuple.Create(ChemicalEquation.CreateMolecule(condensedFormat), molecules[i].Item2);
            }
        }

        /// <summary>
        /// Simplifies an equation entered into the equation input text box.
        /// </summary>
        /// <param name="equation">The equation to be simplified.</param>
        /// <returns>A simplfied equation as a string.</returns>
        public string SimplifyEquationFormat(string equation)
        {
            var chemical_equation = new ChemicalEquation(equation);

            CondenseMolecules(chemical_equation.Reactants);
            CondenseMolecules(chemical_equation.Products);

            return chemical_equation.ToString();
        }

        /// <summary>
        /// Formats the coefficient in front of a molecule so it can be displayed properly in the equation balancer output.
        /// </summary>
        /// <param name="coefficient">The number to format into coefficent text.</param>
        public void SetCoefficientTextFormat(string coefficient)
        {
            rtxt_equation_display.SelectionColor = ColorTranslator.FromHtml("#801DF8");
            rtxt_equation_display.SelectedText = coefficient;
        }

        /// <summary>
        /// Formats text that doesn't need special handling.
        /// </summary>
        /// <param name="text">The text to format normally.</param>
        public void SetDefaultTextFormat(string text)
        {
            rtxt_equation_display.SelectionFont = new Font("Calibri", 18, FontStyle.Bold);
            rtxt_equation_display.SelectionColor = Color.Black;
            rtxt_equation_display.SelectionCharOffset = 0;
            rtxt_equation_display.SelectedText = text;
        }

        /// <summary>
        /// Formats a text associated with a molecule so it can be displayed properly in the equation balancer output.
        /// </summary>
        /// <param name="molecule">The molecule to format.</param>
        public void SetMoleculeTextFormat(Tuple<Molecule, int> molecule)
        {
            this.SetCoefficientTextFormat(molecule.Item2.ToString());

            for (var i = 0; i < molecule.Item1.Elements.Count; ++i)
            {
                SetDefaultTextFormat(molecule.Item1.Elements[i].Item1.Symbol);
                SetSubscriptTextFormat(molecule.Item1.Elements[i].Item2.ToString());
            }
        }

        /// <summary>
        /// Formats the subscript associated with an element so it can be displayed properly in the equation balancer output.
        /// </summary>
        /// <param name="subscript">The number to format into superscript text.</param>
        public void SetSubscriptTextFormat(string subscript)
        {
            rtxt_equation_display.SelectionFont = new Font("Calibri", 13, FontStyle.Bold);
            rtxt_equation_display.SelectionCharOffset = -5;

            var subscript_value = 0;
            int.TryParse(subscript, out subscript_value);
            rtxt_equation_display.SelectedText = (subscript_value != 1) ? subscript : string.Empty;
        }
    }
}