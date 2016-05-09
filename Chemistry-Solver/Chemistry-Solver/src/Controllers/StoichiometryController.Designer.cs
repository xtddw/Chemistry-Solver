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
            this.btn_equation_enter = new System.Windows.Forms.Button();
            this.btn_input_clear = new System.Windows.Forms.Button();
            this.lbl_equation_input = new System.Windows.Forms.Label();
            this.tbox_equation_input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_output_unit = new System.Windows.Forms.ComboBox();
            this.tbox_output_amount = new System.Windows.Forms.TextBox();
            this.cbox_output_molecule = new System.Windows.Forms.ComboBox();
            this.cbox_input_unit = new System.Windows.Forms.ComboBox();
            this.tbox_input_amount = new System.Windows.Forms.TextBox();
            this.cbox_input_molecule = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbox_equation_input.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox_equation_input
            // 
            this.gbox_equation_input.Controls.Add(this.btn_equation_enter);
            this.gbox_equation_input.Controls.Add(this.btn_input_clear);
            this.gbox_equation_input.Controls.Add(this.lbl_equation_input);
            this.gbox_equation_input.Controls.Add(this.tbox_equation_input);
            this.gbox_equation_input.Location = new System.Drawing.Point(12, 12);
            this.gbox_equation_input.Name = "gbox_equation_input";
            this.gbox_equation_input.Size = new System.Drawing.Size(483, 53);
            this.gbox_equation_input.TabIndex = 0;
            this.gbox_equation_input.TabStop = false;
            this.gbox_equation_input.Text = "Select Equation";
            // 
            // btn_equation_enter
            // 
            this.btn_equation_enter.Location = new System.Drawing.Point(371, 17);
            this.btn_equation_enter.Name = "btn_equation_enter";
            this.btn_equation_enter.Size = new System.Drawing.Size(50, 23);
            this.btn_equation_enter.TabIndex = 2;
            this.btn_equation_enter.Text = "Enter";
            this.btn_equation_enter.UseVisualStyleBackColor = true;
            this.btn_equation_enter.Click += new System.EventHandler(this.EquationEnterButtonClick);
            // 
            // btn_input_clear
            // 
            this.btn_input_clear.Location = new System.Drawing.Point(427, 17);
            this.btn_input_clear.Name = "btn_input_clear";
            this.btn_input_clear.Size = new System.Drawing.Size(50, 23);
            this.btn_input_clear.TabIndex = 1;
            this.btn_input_clear.Text = "Clear";
            this.btn_input_clear.UseVisualStyleBackColor = true;
            this.btn_input_clear.Click += new System.EventHandler(this.ClearEquationInputButtonClick);
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
            this.tbox_equation_input.Size = new System.Drawing.Size(301, 20);
            this.tbox_equation_input.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "=";
            // 
            // cbox_output_unit
            // 
            this.cbox_output_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_output_unit.FormattingEnabled = true;
            this.cbox_output_unit.Items.AddRange(new object[] {
            "grams",
            "moles",
            "particles"});
            this.cbox_output_unit.Location = new System.Drawing.Point(396, 61);
            this.cbox_output_unit.Name = "cbox_output_unit";
            this.cbox_output_unit.Size = new System.Drawing.Size(63, 21);
            this.cbox_output_unit.TabIndex = 26;
            this.cbox_output_unit.SelectedIndexChanged += new System.EventHandler(this.OutputUnitSelectionChanged);
            // 
            // tbox_output_amount
            // 
            this.tbox_output_amount.Location = new System.Drawing.Point(269, 61);
            this.tbox_output_amount.Name = "tbox_output_amount";
            this.tbox_output_amount.Size = new System.Drawing.Size(121, 20);
            this.tbox_output_amount.TabIndex = 25;
            this.tbox_output_amount.TextChanged += new System.EventHandler(this.OutputAmountValueChanged);
            // 
            // cbox_output_molecule
            // 
            this.cbox_output_molecule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_output_molecule.FormattingEnabled = true;
            this.cbox_output_molecule.Items.AddRange(new object[] {
            "2H2",
            "O2",
            "2H2O"});
            this.cbox_output_molecule.Location = new System.Drawing.Point(269, 34);
            this.cbox_output_molecule.Name = "cbox_output_molecule";
            this.cbox_output_molecule.Size = new System.Drawing.Size(190, 21);
            this.cbox_output_molecule.TabIndex = 24;
            this.cbox_output_molecule.SelectedIndexChanged += new System.EventHandler(this.OutputMoleculeSelectionChanged);
            // 
            // cbox_input_unit
            // 
            this.cbox_input_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_input_unit.FormattingEnabled = true;
            this.cbox_input_unit.Items.AddRange(new object[] {
            "grams",
            "moles",
            "particles"});
            this.cbox_input_unit.Location = new System.Drawing.Point(150, 61);
            this.cbox_input_unit.Name = "cbox_input_unit";
            this.cbox_input_unit.Size = new System.Drawing.Size(63, 21);
            this.cbox_input_unit.TabIndex = 23;
            this.cbox_input_unit.SelectedIndexChanged += new System.EventHandler(this.InputUnitSelectionChanged);
            // 
            // tbox_input_amount
            // 
            this.tbox_input_amount.Location = new System.Drawing.Point(23, 61);
            this.tbox_input_amount.Name = "tbox_input_amount";
            this.tbox_input_amount.Size = new System.Drawing.Size(121, 20);
            this.tbox_input_amount.TabIndex = 22;
            this.tbox_input_amount.TextChanged += new System.EventHandler(this.InputAmountValueChanged);
            // 
            // cbox_input_molecule
            // 
            this.cbox_input_molecule.BackColor = System.Drawing.Color.White;
            this.cbox_input_molecule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_input_molecule.FormattingEnabled = true;
            this.cbox_input_molecule.Items.AddRange(new object[] {
            "2H2",
            "O2",
            "2H2O"});
            this.cbox_input_molecule.Location = new System.Drawing.Point(23, 34);
            this.cbox_input_molecule.Name = "cbox_input_molecule";
            this.cbox_input_molecule.Size = new System.Drawing.Size(190, 21);
            this.cbox_input_molecule.TabIndex = 21;
            this.cbox_input_molecule.SelectedIndexChanged += new System.EventHandler(this.InputMoleculeSelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_input_molecule);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbox_input_amount);
            this.groupBox1.Controls.Add(this.cbox_output_unit);
            this.groupBox1.Controls.Add(this.cbox_input_unit);
            this.groupBox1.Controls.Add(this.tbox_output_amount);
            this.groupBox1.Controls.Add(this.cbox_output_molecule);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 104);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stoichiometric Conversion";
            // 
            // StoichiometryController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 186);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbox_equation_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StoichiometryController";
            this.Text = "Stoichiometry";
            this.Load += new System.EventHandler(this.StoichiometryFormLoad);
            this.gbox_equation_input.ResumeLayout(false);
            this.gbox_equation_input.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_equation_input;
        private System.Windows.Forms.Button btn_input_clear;
        private System.Windows.Forms.Label lbl_equation_input;
        private System.Windows.Forms.TextBox tbox_equation_input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_output_unit;
        private System.Windows.Forms.TextBox tbox_output_amount;
        private System.Windows.Forms.ComboBox cbox_output_molecule;
        private System.Windows.Forms.ComboBox cbox_input_unit;
        private System.Windows.Forms.TextBox tbox_input_amount;
        private System.Windows.Forms.ComboBox cbox_input_molecule;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_equation_enter;
    }
}