namespace Cham.DocxReport.Helper.Winform.Sample
{
    partial class SampleForm
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
            this.btnOpenTemplate = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenTemplate
            // 
            this.btnOpenTemplate.Location = new System.Drawing.Point(12, 50);
            this.btnOpenTemplate.Name = "btnOpenTemplate";
            this.btnOpenTemplate.Size = new System.Drawing.Size(202, 32);
            this.btnOpenTemplate.TabIndex = 1;
            this.btnOpenTemplate.Text = "Open template";
            this.btnOpenTemplate.UseVisualStyleBackColor = true;
            this.btnOpenTemplate.Click += new System.EventHandler(this.btnOpenTemplate_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 88);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(202, 32);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run template";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 168);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnOpenTemplate);
            this.Name = "SampleForm";
            this.Text = "Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenTemplate;
        private System.Windows.Forms.Button btnRun;
    }
}

