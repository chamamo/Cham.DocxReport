using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    class DataColumnMainTreeNode : DataColumnTreeNode
    {
        #region Constructor

        public DataColumnMainTreeNode(DataColumnFusion column)
            : base(column)
        {
            
        }

        #endregion

        #region Properties

        public override string StringField
        {
            get
            {
                return string.Format("{0}{2}.{3}{1}", DocxReportOptions.CurrentOptions.BeginToken, DocxReportOptions.CurrentOptions.EndToken, ((DataTableTreeNode)Parent).Text, Text);
            }
        }

        #endregion

        #region Methods

        public override ContextMenuStrip GetContextMenu()
        {
            DataColumnFusionContextMenu menu = base.GetContextMenu() as DataColumnFusionContextMenu;
            menu.EnabledMiseEnForme = false;
            return menu;
        }

        #endregion
    }
}
