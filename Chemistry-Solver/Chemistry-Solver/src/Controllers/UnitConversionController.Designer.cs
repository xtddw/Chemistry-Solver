namespace BSmith.ChemistrySolver.Controllers
{
    partial class UnitConversionController
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
            this.cbox_InputUnit = new System.Windows.Forms.ComboBox();
            this.cbox_OutputUnit = new System.Windows.Forms.ComboBox();
            this.tbox_InputAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_OutputAmount = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbox_ConversionType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox_InputUnit
            // 
            this.cbox_InputUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_InputUnit.FormattingEnabled = true;
            this.cbox_InputUnit.Location = new System.Drawing.Point(79, 5);
            this.cbox_InputUnit.Name = "cbox_InputUnit";
            this.cbox_InputUnit.Size = new System.Drawing.Size(100, 21);
            this.cbox_InputUnit.TabIndex = 1;
            this.cbox_InputUnit.SelectedIndexChanged += new System.EventHandler(this.InputUnitSelectedIndexChanged);
            // 
            // cbox_OutputUnit
            // 
            this.cbox_OutputUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_OutputUnit.FormattingEnabled = true;
            this.cbox_OutputUnit.Location = new System.Drawing.Point(80, 7);
            this.cbox_OutputUnit.Name = "cbox_OutputUnit";
            this.cbox_OutputUnit.Size = new System.Drawing.Size(100, 21);
            this.cbox_OutputUnit.TabIndex = 2;
            this.cbox_OutputUnit.SelectedIndexChanged += new System.EventHandler(this.OutputUnitSelectedIndexChanged);
            // 
            // tbox_InputAmount
            // 
            this.tbox_InputAmount.Location = new System.Drawing.Point(3, 5);
            this.tbox_InputAmount.Name = "tbox_InputAmount";
            this.tbox_InputAmount.Size = new System.Drawing.Size(70, 20);
            this.tbox_InputAmount.TabIndex = 3;
            this.tbox_InputAmount.TextChanged += new System.EventHandler(this.InputAmountTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "=";
            // 
            // tbox_OutputAmount
            // 
            this.tbox_OutputAmount.Location = new System.Drawing.Point(3, 7);
            this.tbox_OutputAmount.Name = "tbox_OutputAmount";
            this.tbox_OutputAmount.Size = new System.Drawing.Size(70, 20);
            this.tbox_OutputAmount.TabIndex = 5;
            this.tbox_OutputAmount.TextChanged += new System.EventHandler(this.OutputAmountTextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 39);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbox_OutputUnit);
            this.panel3.Controls.Add(this.tbox_OutputAmount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(234, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 33);
            this.panel3.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(192, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(36, 33);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbox_InputUnit);
            this.panel2.Controls.Add(this.tbox_InputAmount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 33);
            this.panel2.TabIndex = 8;
            // 
            // cbox_ConversionType
            // 
            this.cbox_ConversionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ConversionType.FormattingEnabled = true;
            this.cbox_ConversionType.Location = new System.Drawing.Point(12, 12);
            this.cbox_ConversionType.Name = "cbox_ConversionType";
            this.cbox_ConversionType.Size = new System.Drawing.Size(420, 21);
            this.cbox_ConversionType.TabIndex = 0;
            this.cbox_ConversionType.SelectedIndexChanged += new System.EventHandler(this.ConversionTypeSelectedIndexChanged);
            // 
            // UnitConversionController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 82);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cbox_ConversionType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UnitConversionController";
            this.Text = "Unit Converter";
            this.Load += new System.EventHandler(this.UnitControllerFormLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbox_InputUnit;
        private System.Windows.Forms.ComboBox cbox_OutputUnit;
        private System.Windows.Forms.TextBox tbox_InputAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_OutputAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbox_ConversionType;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}