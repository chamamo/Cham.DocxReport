namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    partial class UcNumberFormatControle
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
            this.nsDecimalDigits = new System.Windows.Forms.NumericUpDown();
            this.lblDecimalDigits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nsDecimalDigits)).BeginInit();
            this.SuspendLayout();
            // 
            // nsDecimalDigits
            // 
            this.nsDecimalDigits.Location = new System.Drawing.Point(196, 13);
            this.nsDecimalDigits.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nsDecimalDigits.Name = "nsDecimalDigits";
            this.nsDecimalDigits.Size = new System.Drawing.Size(48, 20);
            this.nsDecimalDigits.TabIndex = 2;
            this.nsDecimalDigits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nsDecimalDigits.ValueChanged += new System.EventHandler(this.nsDecimalDigits_ValueChanged);
            // 
            // lblDecimalDigits
            // 
            this.lblDecimalDigits.Location = new System.Drawing.Point(3, 13);
            this.lblDecimalDigits.Name = "lblDecimalDigits";
            this.lblDecimalDigits.Size = new System.Drawing.Size(187, 20);
            this.lblDecimalDigits.TabIndex = 118;
            this.lblDecimalDigits.Text = "lblDecimalDigits";
            this.lblDecimalDigits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UcNumberFormatControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.nsDecimalDigits);
            this.Controls.Add(this.lblDecimalDigits);
            this.Name = "UcNumberFormatControle";
            this.Size = new System.Drawing.Size(254, 77);
            ((System.ComponentModel.ISupportInitialize)(this.nsDecimalDigits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.NumericUpDown nsDecimalDigits;
        private System.Windows.Forms.Label lblDecimalDigits;       
    }
}
