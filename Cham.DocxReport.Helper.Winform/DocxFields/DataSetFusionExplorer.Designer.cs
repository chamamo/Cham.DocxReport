namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    partial class DataSetFusionExplorer
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
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.btnFermer = new System.Windows.Forms.Button();
            this.listView = new Cham.DocxReport.Helper.Winform.DocxFields.DataSetTreeView();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnFermer);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 435);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(330, 32);
            this.panel.TabIndex = 13;
            // 
            // btnFermer
            // 
            this.btnFermer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFermer.Location = new System.Drawing.Point(0, 0);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(330, 32);
            this.btnFermer.TabIndex = 0;
            this.btnFermer.Text = "btnFermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.ImageIndex = 0;
            this.listView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.SelectedImageIndex = 0;
            this.listView.Size = new System.Drawing.Size(330, 435);
            this.listView.TabIndex = 14;
            // 
            // DataSetFusionExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(330, 467);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataSetFusionExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DataSetFusionExplorer";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private DataSetTreeView listView;
        private System.Windows.Forms.Button btnFermer;
    }
}