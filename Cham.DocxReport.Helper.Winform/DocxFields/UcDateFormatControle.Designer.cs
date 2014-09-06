namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    partial class UcDateFormatControle
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
            this.lbFormats = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbFormats
            // 
            this.lbFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFormats.FormattingEnabled = true;
            this.lbFormats.Location = new System.Drawing.Point(0, 0);
            this.lbFormats.Name = "lbFormats";
            this.lbFormats.Size = new System.Drawing.Size(270, 173);
            this.lbFormats.TabIndex = 0;
            this.lbFormats.SelectedIndexChanged += new System.EventHandler(this.lbFormats_SelectedIndexChanged);
            // 
            // UcDateFormatControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbFormats);
            this.Name = "UcDateFormatControle";
            this.Size = new System.Drawing.Size(270, 180);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ListBox lbFormats;

    }
}
