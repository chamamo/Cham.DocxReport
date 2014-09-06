using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal class DataTableFusionContextMenu : ContextMenuStrip
    {
        #region evt

        public EventHandler ShowDataClick;

        #endregion
        
        #region Fields

        ToolStripMenuItem miShowData = new ToolStripMenuItem(Resources.ShowData, null /*Images.Icon.Icons.ActualSizeHS*/);

        #endregion

        #region Constructor

        public DataTableFusionContextMenu()
        {
            miShowData.Click += new EventHandler(OnShowData);

            Items.Add(miShowData);
        }

        #endregion

        #region Properties

        #endregion

        #region Events

        private void OnShowData(object sender, System.EventArgs e)
        {
            if (this.ShowDataClick != null) { ShowDataClick(this, e); }
        }

        #endregion
    }
}
