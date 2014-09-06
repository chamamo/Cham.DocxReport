using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal class DataColumnFusionContextMenu : ContextMenuStrip
    {
        #region evt

        public EventHandler MiseEnformeClick;
        public EventHandler CopierClick;

        #endregion
        
        #region Fields

        ToolStripMenuItem miCopier = new ToolStripMenuItem(Resources.Copy, IconsResource.Copy);
        ToolStripMenuItem miMiseEnForme = new ToolStripMenuItem(Resources.Formatting, IconsResource.Configuration);

        #endregion

        #region Constructor

        public DataColumnFusionContextMenu()
        {
            miMiseEnForme.Click += new EventHandler(OnFormatting);
            miCopier.Click += new EventHandler(OnCopy);
            Items.Add(miMiseEnForme);
            Items.Add(miCopier);
        }

        #endregion

        #region Properties

        public bool EnabledMiseEnForme
        {
            set { miMiseEnForme.Enabled = value; }
        }

        #endregion

        #region Events

        private void OnFormatting(object sender, System.EventArgs e)
        {
            if (this.MiseEnformeClick != null) { MiseEnformeClick(this, e); }
        }

        private void OnCopy(object sender, System.EventArgs e)
        {
            if (this.CopierClick != null) { CopierClick(this, e); }
        }

        #endregion
    }
}
