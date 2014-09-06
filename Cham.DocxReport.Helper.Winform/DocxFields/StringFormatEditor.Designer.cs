namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    partial class StringFormatEditor
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbFormats = new System.Windows.Forms.GroupBox();
            this.lbFormats = new System.Windows.Forms.ListBox();
            this.gbExemple = new System.Windows.Forms.GroupBox();
            this.lblExemple = new System.Windows.Forms.Label();
            this.gbProprietes = new System.Windows.Forms.GroupBox();
            this.panel.SuspendLayout();
            this.gbFormats.SuspendLayout();
            this.gbExemple.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnOK);
            this.panel.Controls.Add(this.btnCancel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 282);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(391, 49);
            this.panel.TabIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(221, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(302, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbFormats
            // 
            this.gbFormats.Controls.Add(this.lbFormats);
            this.gbFormats.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbFormats.Location = new System.Drawing.Point(0, 0);
            this.gbFormats.Name = "gbFormats";
            this.gbFormats.Size = new System.Drawing.Size(118, 282);
            this.gbFormats.TabIndex = 13;
            this.gbFormats.TabStop = false;
            this.gbFormats.Text = "gbFormats";
            // 
            // lbFormats
            // 
            this.lbFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFormats.FormattingEnabled = true;
            this.lbFormats.Location = new System.Drawing.Point(3, 16);
            this.lbFormats.Name = "lbFormats";
            this.lbFormats.Size = new System.Drawing.Size(112, 251);
            this.lbFormats.TabIndex = 0;
            this.lbFormats.SelectedIndexChanged += new System.EventHandler(this.lbFormats_SelectedIndexChanged);
            // 
            // gbExemple
            // 
            this.gbExemple.Controls.Add(this.lblExemple);
            this.gbExemple.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbExemple.Location = new System.Drawing.Point(118, 0);
            this.gbExemple.Name = "gbExemple";
            this.gbExemple.Size = new System.Drawing.Size(273, 52);
            this.gbExemple.TabIndex = 14;
            this.gbExemple.TabStop = false;
            this.gbExemple.Text = "gbExemple";
            // 
            // lblExemple
            // 
            this.lblExemple.AutoSize = true;
            this.lblExemple.Location = new System.Drawing.Point(28, 23);
            this.lblExemple.Name = "lblExemple";
            this.lblExemple.Size = new System.Drawing.Size(57, 13);
            this.lblExemple.TabIndex = 0;
            this.lblExemple.Text = "lblExemple";
            // 
            // gbProprietes
            // 
            this.gbProprietes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProprietes.Location = new System.Drawing.Point(118, 52);
            this.gbProprietes.Name = "gbProprietes";
            this.gbProprietes.Size = new System.Drawing.Size(273, 230);
            this.gbProprietes.TabIndex = 15;
            this.gbProprietes.TabStop = false;
            this.gbProprietes.Text = "gbProprietes";
            // 
            // StringFormatEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 331);
            this.Controls.Add(this.gbProprietes);
            this.Controls.Add(this.gbExemple);
            this.Controls.Add(this.gbFormats);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StringFormatEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StringFormatEditor";
            this.panel.ResumeLayout(false);
            this.gbFormats.ResumeLayout(false);
            this.gbExemple.ResumeLayout(false);
            this.gbExemple.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbFormats;
        private System.Windows.Forms.GroupBox gbExemple;
        private System.Windows.Forms.GroupBox gbProprietes;
        private System.Windows.Forms.Label lblExemple;
        private System.Windows.Forms.ListBox lbFormats;
    }
}