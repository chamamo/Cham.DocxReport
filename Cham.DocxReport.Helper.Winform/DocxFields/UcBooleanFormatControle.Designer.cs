namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    partial class UcBooleanFormatControle
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFalse = new System.Windows.Forms.GroupBox();
            this.cbFalseDisplay = new System.Windows.Forms.ComboBox();
            this.lblFalseDisplay = new System.Windows.Forms.Label();
            this.gbTrue = new System.Windows.Forms.GroupBox();
            this.cbTrueDisplay = new System.Windows.Forms.ComboBox();
            this.lblTrueDisplay = new System.Windows.Forms.Label();
            this.gbFalse.SuspendLayout();
            this.gbTrue.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFalse
            // 
            this.gbFalse.Controls.Add(this.cbFalseDisplay);
            this.gbFalse.Controls.Add(this.lblFalseDisplay);
            this.gbFalse.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFalse.Location = new System.Drawing.Point(0, 0);
            this.gbFalse.Name = "gbFalse";
            this.gbFalse.Size = new System.Drawing.Size(231, 50);
            this.gbFalse.TabIndex = 0;
            this.gbFalse.TabStop = false;
            this.gbFalse.Text = "gbFalse";
            // 
            // cbFalseDisplay
            // 
            this.cbFalseDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFalseDisplay.FormattingEnabled = true;
            this.cbFalseDisplay.Location = new System.Drawing.Point(128, 19);
            this.cbFalseDisplay.Name = "cbFalseDisplay";
            this.cbFalseDisplay.Size = new System.Drawing.Size(93, 21);
            this.cbFalseDisplay.TabIndex = 126;
            this.cbFalseDisplay.SelectedIndexChanged += new System.EventHandler(this.cbFalseValue_SelectedIndexChanged);
            // 
            // lblFalseDisplay
            // 
            this.lblFalseDisplay.Location = new System.Drawing.Point(11, 18);
            this.lblFalseDisplay.Name = "lblFalseDisplay";
            this.lblFalseDisplay.Size = new System.Drawing.Size(111, 20);
            this.lblFalseDisplay.TabIndex = 125;
            this.lblFalseDisplay.Text = "lblFalseDisplay";
            this.lblFalseDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbTrue
            // 
            this.gbTrue.Controls.Add(this.cbTrueDisplay);
            this.gbTrue.Controls.Add(this.lblTrueDisplay);
            this.gbTrue.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTrue.Location = new System.Drawing.Point(0, 50);
            this.gbTrue.Name = "gbTrue";
            this.gbTrue.Size = new System.Drawing.Size(231, 52);
            this.gbTrue.TabIndex = 1;
            this.gbTrue.TabStop = false;
            this.gbTrue.Text = "gbTrue";
            // 
            // cbTrueDisplay
            // 
            this.cbTrueDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrueDisplay.FormattingEnabled = true;
            this.cbTrueDisplay.Location = new System.Drawing.Point(128, 19);
            this.cbTrueDisplay.Name = "cbTrueDisplay";
            this.cbTrueDisplay.Size = new System.Drawing.Size(93, 21);
            this.cbTrueDisplay.TabIndex = 126;
            this.cbTrueDisplay.SelectedIndexChanged += new System.EventHandler(this.cbFalseValue_SelectedIndexChanged);
            this.cbTrueDisplay.Enter += new System.EventHandler(this.cbFalseValue_SelectedIndexChanged);
            // 
            // lblTrueDisplay
            // 
            this.lblTrueDisplay.Location = new System.Drawing.Point(11, 18);
            this.lblTrueDisplay.Name = "lblTrueDisplay";
            this.lblTrueDisplay.Size = new System.Drawing.Size(111, 20);
            this.lblTrueDisplay.TabIndex = 125;
            this.lblTrueDisplay.Text = "lblTrueDisplay";
            this.lblTrueDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UcBooleanFormatControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbTrue);
            this.Controls.Add(this.gbFalse);
            this.Name = "UcBooleanFormatControle";
            this.Size = new System.Drawing.Size(231, 107);
            this.gbFalse.ResumeLayout(false);
            this.gbTrue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFalse;
        private System.Windows.Forms.ComboBox cbFalseDisplay;
        private System.Windows.Forms.Label lblFalseDisplay;
        private System.Windows.Forms.GroupBox gbTrue;
        private System.Windows.Forms.ComboBox cbTrueDisplay;
        private System.Windows.Forms.Label lblTrueDisplay;
    }
}
