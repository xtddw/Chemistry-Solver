using BSmith.Chemistry;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    /// <summary>
    /// The form for the Equation Balancer application.
    /// </summary>
    public partial class EquationBalancerController : Form
    {
        /// <summary>
        /// All the information needed to balance equations is stored in the instance of the EquationBalancerModel.
        /// </summary>
        Models.EquationBalancerModel model_;

        /// <summary>
        /// Creates a new EquationBalancerController.
        /// </summary>
        public EquationBalancerController()
        {
            model_ = new Models.EquationBalancerModel();
            InitializeComponent();
        }

        /// <summary>
        /// Formats the subscript associated with an element so it can be displayed properly in the Equation Balancer output.
        /// </summary>
        /// <param name="subscript">The subscript to format.</param>
        private void SetSubscriptText(string subscript)
        {        
            rtxt_equation_display.SelectionFont = new Font("Calibri", 13, FontStyle.Bold);
            rtxt_equation_display.SelectionCharOffset = -5;

            var subscript_value = 0;
            int.TryParse(subscript, out subscript_value);
            rtxt_equation_display.SelectedText = (subscript_value != 1) ? subscript : string.Empty;
        }

        /// <summary>
        /// Formats the coefficient infront of a molecule so it can be displayed properly in the Equation Balancer output.
        /// </summary>
        /// <param name="coefficient"></param>
        private void SetCoefficientText(string coefficient)
        {
            rtxt_equation_display.SelectionColor = ColorTranslator.FromHtml("#801DF8");
            rtxt_equation_display.SelectedText = coefficient;
        }

        /// <summary>
        /// Formats a text associated with a molecule so it can be displayed properly in the Equation Balancer output. Uses SetSubscriptText() and SetCoefficientText().
        /// </summary>
        /// <param name="molecule">The molecule to format.</param>
        private void SetMoleculeText(ParticleQuantityPair<Molecule, int> molecule)
        {
            SetCoefficientText(molecule.Quantity.ToString());

            for (var i = 0; i < molecule.Particle.Elements.Count; ++i)
            {
                SetNormalText(molecule.Particle.Elements[i].Particle.Symbol);
                SetSubscriptText(molecule.Particle.Elements[i].Quantity.ToString());
            }

        }

        /// <summary>
        /// Formats text that doesn't need special handling, such as a coefficient or a subscript.
        /// </summary>
        /// <param name="text">The text to format normally.</param>
        private void SetNormalText(string text)
        {
            rtxt_equation_display.SelectionFont = new Font("Calibri", 18, FontStyle.Bold);
            rtxt_equation_display.SelectionColor = Color.Black;
            rtxt_equation_display.SelectionCharOffset = 0;
            rtxt_equation_display.SelectedText = text;
        }

        /// <summary>
        /// Simplifies an equation entered into the equation input text box.
        /// </summary>
        /// <param name="equation">The equation to be simplified.</param>
        /// <returns>A simplfied equation as a string.</returns>
        private string SimplifyEquation(string equation)
        {
            var chemical_equation = ChemicalEquation.InterpretEquation(equation);
           
            // Condense reactants
            if (chemical_equation.Reactants.Count > 0)
            {
                for (var i = 0; i < chemical_equation.Reactants.Count; ++i)
                {
                    var molecule = chemical_equation.Reactants[i].Particle.ToString();
                    var elements = Regex.Matches(molecule, @"[A-Z]{1}[a-z]{0,2}");
                    var subscripts = Regex.Matches(molecule, @"\b\d{1,}\b");
                    var condensed = "1";

                    // Iterate over elements in reactant
                    for (var j = 0; j < elements.Count; ++j)
                    {
                        var matches = Regex.Matches(molecule, elements[j].Value + @"_\(\d{1,}\)");
                        var subscript_sum = 0;

                        foreach(Match match in matches)
                        {
                            var subscript_string = Regex.Match(match.Value, @"\d{1,}");
                            var subscript = 0;
                            int.TryParse(subscript_string.Value, out subscript);

                            subscript_sum += subscript;
                        }

                        condensed += (!Regex.IsMatch(condensed, elements[j].Value)) ? elements[j].Value + "_(" + subscript_sum + ")" : string.Empty;
                        
                    }

                    chemical_equation.Reactants[i].Particle = ChemicalEquation.CreateMolecule(condensed);
                }
            }

            if (chemical_equation.Products.Count > 0)
            {
                for (var i = 0; i < chemical_equation.Products.Count; ++i)
                {
                    var molecule = chemical_equation.Products[i].Particle.ToString();
                    var elements = Regex.Matches(molecule, @"[A-Z]{1}[a-z]{0,2}");
                    var subscripts = Regex.Matches(molecule, @"\b\d{1,}\b");
                    var condensed = "1";

                    // Iterate over elements in product
                    for (var j = 0; j < elements.Count; ++j)
                    {
                        var matches = Regex.Matches(molecule, elements[j].Value + @"_\(\d{1,}\)");
                        var subscript_sum = 0;

                        foreach (Match match in matches)
                        {
                            var subscript_string = Regex.Match(match.Value, @"\d{1,}");
                            var subscript = 0;
                            int.TryParse(subscript_string.Value, out subscript);

                            subscript_sum += subscript;
                        }

                        condensed += (!Regex.IsMatch(condensed, elements[j].Value)) ? elements[j].Value + "_(" + subscript_sum + ")" : string.Empty;

                    }

                    chemical_equation.Products[i].Particle = ChemicalEquation.CreateMolecule(condensed);
                }
            }

            return chemical_equation.ToString();
        }

        /// <summary>
        /// The Event handler used by labels in the periodic table. It adds the element, correctly formatted, into the input text box.
        /// </summary>
        /// <param name="sender">The form component that sent the event.</param>
        /// <param name="e">The arguments associated with an onClick event.</param>
        private void lbl_Element_Click(object sender, EventArgs e)
        {
            var element_label = sender as Label;
            var equation_input = txt_equation_input.Text + "1" + element_label.Text + "_(1)";

            txt_equation_input.Text = SimplifyEquation(equation_input);
            txt_equation_input.Select(txt_equation_input.Text.Length, 0); // Set cursor at end of text box.
        }

        private void lbl_Separator_Click(object sender, EventArgs e)
        {
            var separator = sender as Label;
            txt_equation_input.SelectedText = " " + separator.Text + " ";
        }

        /// <summary>
        /// The Event Handler used by the "balance" button in the input section. Balances the equation supplied in the input text box, then displays it in the output rich text box.
        /// </summary>
        /// <param name="sender">The form component that sent the event.</param>
        /// <param name="e">The arguments associated with an onClick event.</param>
        private void btn_balance_Click(object sender, EventArgs e)
        {
            rtxt_equation_display.Clear();
            model_.Equation = ChemicalEquation.InterpretEquation(SimplifyEquation(txt_equation_input.Text));

            if (model_.Equation.Reactants.Count > 0 && model_.Equation.Products.Count > 0 /* model_.Equation.IsValid() */)
            {
                model_.Equation.Balance();
            }

            rtxt_equation_display.SelectionAlignment = HorizontalAlignment.Center;

            for (int reactants_index = 0; reactants_index < model_.Equation.Reactants.Count; ++reactants_index)
            {
                SetMoleculeText(model_.Equation.Reactants[reactants_index]);
                SetNormalText((reactants_index < model_.Equation.Reactants.Count - 1) ? " + " : string.Empty);
            }

            if (model_.Equation.Products.Count != 0)
            {
                SetNormalText(" --> ");
            }

            for (int products_index = 0; products_index < model_.Equation.Products.Count; ++products_index)
            {
                SetMoleculeText(model_.Equation.Products[products_index]);
                SetNormalText((products_index < model_.Equation.Products.Count - 1) ? " + " : string.Empty);
            }
        }

        /// <summary>
        /// The Event Handler used by the clear button in the input section of the form. Clears the display, the input text box, and the chemical equation in the model.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            model_.Equation = new ChemicalEquation();
            txt_equation_input.Clear();
            rtxt_equation_display.Clear();
        }
    }
}