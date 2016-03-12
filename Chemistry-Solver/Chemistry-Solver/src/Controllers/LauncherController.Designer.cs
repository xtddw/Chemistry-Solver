namespace BSmith.ChemistrySolver.Controllers
{
    partial class LauncherController
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
            this.btnEquationBalancer = new System.Windows.Forms.Button();
            this.btnCombustionAnalysis = new System.Windows.Forms.Button();
            this.btnStoichiometry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEmpirical = new System.Windows.Forms.Button();
            this.btnPeriodicTable = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUnitConversion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEquationBalancer
            // 
            this.btnEquationBalancer.Location = new System.Drawing.Point(6, 16);
            this.btnEquationBalancer.Name = "btnEquationBalancer";
            this.btnEquationBalancer.Size = new System.Drawing.Size(80, 80);
            this.btnEquationBalancer.TabIndex = 0;
            this.btnEquationBalancer.Text = "Balance Equations";
            this.btnEquationBalancer.UseVisualStyleBackColor = true;
            this.btnEquationBalancer.Click += new System.EventHandler(this.btnEquationBalancer_Click);
            // 
            // btnCombustionAnalysis
            // 
            this.btnCombustionAnalysis.Enabled = false;
            this.btnCombustionAnalysis.Location = new System.Drawing.Point(92, 16);
            this.btnCombustionAnalysis.Name = "btnCombustionAnalysis";
            this.btnCombustionAnalysis.Size = new System.Drawing.Size(80, 80);
            this.btnCombustionAnalysis.TabIndex = 2;
            this.btnCombustionAnalysis.Text = "Combustion Analysis";
            this.btnCombustionAnalysis.UseVisualStyleBackColor = true;
            // 
            // btnStoichiometry
            // 
            this.btnStoichiometry.Location = new System.Drawing.Point(178, 16);
            this.btnStoichiometry.Name = "btnStoichiometry";
            this.btnStoichiometry.Size = new System.Drawing.Size(80, 80);
            this.btnStoichiometry.TabIndex = 3;
            this.btnStoichiometry.Text = "Stoichiometry";
            this.btnStoichiometry.UseVisualStyleBackColor = true;
            this.btnStoichiometry.Click += new System.EventHandler(this.btnStoichiometry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEmpirical);
            this.groupBox1.Controls.Add(this.btnPeriodicTable);
            this.groupBox1.Controls.Add(this.btnEquationBalancer);
            this.groupBox1.Controls.Add(this.btnStoichiometry);
            this.groupBox1.Controls.Add(this.btnCombustionAnalysis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 108);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chemistry";
            // 
            // btnEmpirical
            // 
            this.btnEmpirical.Enabled = false;
            this.btnEmpirical.Location = new System.Drawing.Point(350, 16);
            this.btnEmpirical.Name = "btnEmpirical";
            this.btnEmpirical.Size = new System.Drawing.Size(80, 80);
            this.btnEmpirical.TabIndex = 5;
            this.btnEmpirical.Text = "Empirical Formula Derivation";
            this.btnEmpirical.UseVisualStyleBackColor = true;
            // 
            // btnPeriodicTable
            // 
            this.btnPeriodicTable.Location = new System.Drawing.Point(264, 16);
            this.btnPeriodicTable.Name = "btnPeriodicTable";
            this.btnPeriodicTable.Size = new System.Drawing.Size(80, 80);
            this.btnPeriodicTable.TabIndex = 4;
            this.btnPeriodicTable.Text = "Periodic Table";
            this.btnPeriodicTable.UseVisualStyleBackColor = true;
            this.btnPeriodicTable.Click += new System.EventHandler(this.btnPeriodicTable_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUnitConversion);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 108);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // btnUnitConversion
            // 
            this.btnUnitConversion.Enabled = false;
            this.btnUnitConversion.Location = new System.Drawing.Point(6, 19);
            this.btnUnitConversion.Name = "btnUnitConversion";
            this.btnUnitConversion.Size = new System.Drawing.Size(80, 80);
            this.btnUnitConversion.TabIndex = 1;
            this.btnUnitConversion.Text = "Unit Conversion";
            this.btnUnitConversion.UseVisualStyleBackColor = true;
            // 
            // LauncherController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 245);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LauncherController";
            this.Text = "Chemistry Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEquationBalancer;
        private System.Windows.Forms.Button btnCombustionAnalysis;
        private System.Windows.Forms.Button btnStoichiometry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEmpirical;
        private System.Windows.Forms.Button btnPeriodicTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUnitConversion;
    }
}

