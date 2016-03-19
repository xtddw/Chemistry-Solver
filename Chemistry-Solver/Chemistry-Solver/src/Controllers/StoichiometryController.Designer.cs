namespace BSmith.ChemistrySolver.Controllers
{
    partial class StoichiometryController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbox_equation_input = new System.Windows.Forms.GroupBox();
            this.btn_input_clear = new System.Windows.Forms.Button();
            this.gbox_output = new System.Windows.Forms.GroupBox();
            this.tlp_products = new System.Windows.Forms.TableLayoutPanel();
            this.cbox_output_unit = new System.Windows.Forms.ComboBox();
            this.lbl_output_units = new System.Windows.Forms.Label();
            this.lbox_output = new System.Windows.Forms.ListBox();
            this.btn_input_enter = new System.Windows.Forms.Button();
            this.gbox_input = new System.Windows.Forms.GroupBox();
            this.tlp_reactants = new System.Windows.Forms.TableLayoutPanel();
            this.cbox_intput_unit = new System.Windows.Forms.ComboBox();
            this.lbl_input_amount = new System.Windows.Forms.Label();
            this.tbox_input_amount = new System.Windows.Forms.TextBox();
            this.lbox_input = new System.Windows.Forms.ListBox();
            this.lbl_equation_input = new System.Windows.Forms.Label();
            this.tbox_equation_input = new System.Windows.Forms.TextBox();
            this.btn_calculate_result = new System.Windows.Forms.Button();
            this.rtbox_result = new System.Windows.Forms.RichTextBox();
            this.gbox_equation_input.SuspendLayout();
            this.gbox_output.SuspendLayout();
            this.tlp_products.SuspendLayout();
            this.gbox_input.SuspendLayout();
            this.tlp_reactants.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox_equation_input
            // 
            this.gbox_equation_input.Controls.Add(this.btn_input_clear);
            this.gbox_equation_input.Controls.Add(this.gbox_output);
            this.gbox_equation_input.Controls.Add(this.btn_input_enter);
            this.gbox_equation_input.Controls.Add(this.gbox_input);
            this.gbox_equation_input.Controls.Add(this.lbl_equation_input);
            this.gbox_equation_input.Controls.Add(this.tbox_equation_input);
            this.gbox_equation_input.Location = new System.Drawing.Point(12, 12);
            this.gbox_equation_input.Name = "gbox_equation_input";
            this.gbox_equation_input.Size = new System.Drawing.Size(483, 233);
            this.gbox_equation_input.TabIndex = 0;
            this.gbox_equation_input.TabStop = false;
            this.gbox_equation_input.Text = "Input";
            // 
            // btn_input_clear
            // 
            this.btn_input_clear.Location = new System.Drawing.Point(368, 19);
            this.btn_input_clear.Name = "btn_input_clear";
            this.btn_input_clear.Size = new System.Drawing.Size(50, 23);
            this.btn_input_clear.TabIndex = 1;
            this.btn_input_clear.Text = "Clear";
            this.btn_input_clear.UseVisualStyleBackColor = true;
            this.btn_input_clear.Click += new System.EventHandler(this.ClearInputButtonClick);
            // 
            // gbox_output
            // 
            this.gbox_output.Controls.Add(this.tlp_products);
            this.gbox_output.Controls.Add(this.lbox_output);
            this.gbox_output.Location = new System.Drawing.Point(258, 60);
            this.gbox_output.Name = "gbox_output";
            this.gbox_output.Size = new System.Drawing.Size(219, 167);
            this.gbox_output.TabIndex = 3;
            this.gbox_output.TabStop = false;
            this.gbox_output.Text = "Output Molecule";
            // 
            // tlp_products
            // 
            this.tlp_products.ColumnCount = 3;
            this.tlp_products.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlp_products.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_products.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_products.Controls.Add(this.cbox_output_unit, 2, 0);
            this.tlp_products.Controls.Add(this.lbl_output_units, 0, 0);
            this.tlp_products.Location = new System.Drawing.Point(9, 133);
            this.tlp_products.Name = "tlp_products";
            this.tlp_products.RowCount = 1;
            this.tlp_products.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_products.Size = new System.Drawing.Size(200, 28);
            this.tlp_products.TabIndex = 14;
            // 
            // cbox_output_unit
            // 
            this.cbox_output_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_output_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_output_unit.FormattingEnabled = true;
            this.cbox_output_unit.Items.AddRange(new object[] {
            "grams",
            "moles",
            "particles"});
            this.cbox_output_unit.Location = new System.Drawing.Point(129, 3);
            this.cbox_output_unit.Name = "cbox_output_unit";
            this.cbox_output_unit.Size = new System.Drawing.Size(68, 21);
            this.cbox_output_unit.TabIndex = 8;
            this.cbox_output_unit.SelectedIndexChanged += new System.EventHandler(this.OutputUnitSelectionChanged);
            // 
            // lbl_output_units
            // 
            this.lbl_output_units.AutoSize = true;
            this.lbl_output_units.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_output_units.Location = new System.Drawing.Point(3, 0);
            this.lbl_output_units.Name = "lbl_output_units";
            this.lbl_output_units.Size = new System.Drawing.Size(46, 28);
            this.lbl_output_units.TabIndex = 9;
            this.lbl_output_units.Text = "Units:";
            this.lbl_output_units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbox_output
            // 
            this.lbox_output.FormattingEnabled = true;
            this.lbox_output.Location = new System.Drawing.Point(9, 19);
            this.lbox_output.Name = "lbox_output";
            this.lbox_output.Size = new System.Drawing.Size(200, 108);
            this.lbox_output.TabIndex = 1;
            this.lbox_output.SelectedIndexChanged += new System.EventHandler(this.OutputMoleculeSelectionChanged);
            // 
            // btn_input_enter
            // 
            this.btn_input_enter.Location = new System.Drawing.Point(424, 19);
            this.btn_input_enter.Name = "btn_input_enter";
            this.btn_input_enter.Size = new System.Drawing.Size(50, 23);
            this.btn_input_enter.TabIndex = 2;
            this.btn_input_enter.Text = "Enter";
            this.btn_input_enter.UseVisualStyleBackColor = true;
            this.btn_input_enter.Click += new System.EventHandler(this.EnterInputButtonClick);
            // 
            // gbox_input
            // 
            this.gbox_input.Controls.Add(this.tlp_reactants);
            this.gbox_input.Controls.Add(this.lbox_input);
            this.gbox_input.Location = new System.Drawing.Point(6, 60);
            this.gbox_input.Name = "gbox_input";
            this.gbox_input.Size = new System.Drawing.Size(217, 167);
            this.gbox_input.TabIndex = 2;
            this.gbox_input.TabStop = false;
            this.gbox_input.Text = "Input Molecule";
            // 
            // tlp_reactants
            // 
            this.tlp_reactants.ColumnCount = 3;
            this.tlp_reactants.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlp_reactants.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_reactants.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_reactants.Controls.Add(this.cbox_intput_unit, 2, 0);
            this.tlp_reactants.Controls.Add(this.lbl_input_amount, 0, 0);
            this.tlp_reactants.Controls.Add(this.tbox_input_amount, 1, 0);
            this.tlp_reactants.Location = new System.Drawing.Point(9, 133);
            this.tlp_reactants.Name = "tlp_reactants";
            this.tlp_reactants.RowCount = 1;
            this.tlp_reactants.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_reactants.Size = new System.Drawing.Size(200, 28);
            this.tlp_reactants.TabIndex = 13;
            // 
            // cbox_intput_unit
            // 
            this.cbox_intput_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbox_intput_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_intput_unit.FormattingEnabled = true;
            this.cbox_intput_unit.Items.AddRange(new object[] {
            "grams",
            "moles",
            "particles"});
            this.cbox_intput_unit.Location = new System.Drawing.Point(129, 3);
            this.cbox_intput_unit.Name = "cbox_intput_unit";
            this.cbox_intput_unit.Size = new System.Drawing.Size(68, 21);
            this.cbox_intput_unit.TabIndex = 6;
            this.cbox_intput_unit.SelectedIndexChanged += new System.EventHandler(this.InputUnitSelectionChanged);
            // 
            // lbl_input_amount
            // 
            this.lbl_input_amount.AutoSize = true;
            this.lbl_input_amount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_input_amount.Location = new System.Drawing.Point(3, 0);
            this.lbl_input_amount.Name = "lbl_input_amount";
            this.lbl_input_amount.Size = new System.Drawing.Size(46, 28);
            this.lbl_input_amount.TabIndex = 9;
            this.lbl_input_amount.Text = "Amount:";
            this.lbl_input_amount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_input_amount
            // 
            this.tbox_input_amount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbox_input_amount.Location = new System.Drawing.Point(55, 3);
            this.tbox_input_amount.Name = "tbox_input_amount";
            this.tbox_input_amount.Size = new System.Drawing.Size(68, 20);
            this.tbox_input_amount.TabIndex = 5;
            this.tbox_input_amount.TextChanged += new System.EventHandler(this.InputAmountValueChanged);
            // 
            // lbox_input
            // 
            this.lbox_input.FormattingEnabled = true;
            this.lbox_input.Location = new System.Drawing.Point(9, 19);
            this.lbox_input.Name = "lbox_input";
            this.lbox_input.Size = new System.Drawing.Size(200, 108);
            this.lbox_input.TabIndex = 1;
            this.lbox_input.SelectedIndexChanged += new System.EventHandler(this.InputMoleculeSelectionChanged);
            // 
            // lbl_equation_input
            // 
            this.lbl_equation_input.AutoSize = true;
            this.lbl_equation_input.Location = new System.Drawing.Point(6, 22);
            this.lbl_equation_input.Name = "lbl_equation_input";
            this.lbl_equation_input.Size = new System.Drawing.Size(52, 13);
            this.lbl_equation_input.TabIndex = 1;
            this.lbl_equation_input.Text = "Equation:";
            // 
            // tbox_equation_input
            // 
            this.tbox_equation_input.Location = new System.Drawing.Point(64, 19);
            this.tbox_equation_input.Name = "tbox_equation_input";
            this.tbox_equation_input.Size = new System.Drawing.Size(298, 20);
            this.tbox_equation_input.TabIndex = 0;
            // 
            // btn_calculate_result
            // 
            this.btn_calculate_result.Location = new System.Drawing.Point(214, 251);
            this.btn_calculate_result.Name = "btn_calculate_result";
            this.btn_calculate_result.Size = new System.Drawing.Size(75, 23);
            this.btn_calculate_result.TabIndex = 7;
            this.btn_calculate_result.Text = "Calculate";
            this.btn_calculate_result.UseVisualStyleBackColor = true;
            this.btn_calculate_result.Click += new System.EventHandler(this.CalculateResultButtonClick);
            // 
            // rtbox_result
            // 
            this.rtbox_result.BackColor = System.Drawing.SystemColors.Control;
            this.rtbox_result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbox_result.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbox_result.Location = new System.Drawing.Point(10, 292);
            this.rtbox_result.Name = "rtbox_result";
            this.rtbox_result.ReadOnly = true;
            this.rtbox_result.Size = new System.Drawing.Size(483, 32);
            this.rtbox_result.TabIndex = 9;
            this.rtbox_result.Text = "";
            // 
            // StoichiometryController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 350);
            this.Controls.Add(this.btn_calculate_result);
            this.Controls.Add(this.rtbox_result);
            this.Controls.Add(this.gbox_equation_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StoichiometryController";
            this.Text = "Stoichiometry";
            this.gbox_equation_input.ResumeLayout(false);
            this.gbox_equation_input.PerformLayout();
            this.gbox_output.ResumeLayout(false);
            this.tlp_products.ResumeLayout(false);
            this.tlp_products.PerformLayout();
            this.gbox_input.ResumeLayout(false);
            this.tlp_reactants.ResumeLayout(false);
            this.tlp_reactants.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_equation_input;
        private System.Windows.Forms.Button btn_input_clear;
        private System.Windows.Forms.Button btn_input_enter;
        private System.Windows.Forms.Label lbl_equation_input;
        private System.Windows.Forms.TextBox tbox_equation_input;
        private System.Windows.Forms.ListBox lbox_input;
        private System.Windows.Forms.GroupBox gbox_input;
        private System.Windows.Forms.Label lbl_input_amount;
        private System.Windows.Forms.ComboBox cbox_intput_unit;
        private System.Windows.Forms.TextBox tbox_input_amount;
        private System.Windows.Forms.GroupBox gbox_output;
        private System.Windows.Forms.ListBox lbox_output;
        private System.Windows.Forms.RichTextBox rtbox_result;
        private System.Windows.Forms.TableLayoutPanel tlp_reactants;
        private System.Windows.Forms.TableLayoutPanel tlp_products;
        private System.Windows.Forms.ComboBox cbox_output_unit;
        private System.Windows.Forms.Label lbl_output_units;
        private System.Windows.Forms.Button btn_calculate_result;
    }
}