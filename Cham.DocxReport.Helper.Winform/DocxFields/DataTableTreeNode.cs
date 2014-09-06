using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    class DataTableTreeNode : TreeNode
    {
        #region Fields

        private DataTableFusionContextMenu m_ContextMenu = new DataTableFusionContextMenu();

        #endregion

        #region Constructor

        public DataTableTreeNode(DataTableFusion table)
            : base(table.Name)
        {
            Tag = table;
            ImageIndex = (int)eIcon.Maintenance;
            SelectedImageIndex = this.ImageIndex;
            this.m_ContextMenu.ShowDataClick += new System.EventHandler(this.ShowDataClick);
            BuildChildNodes();
        }

        #endregion

        #region Properties

        private DataTableFusion DataTableFusion
        {
            get { return (DataTableFusion)Tag; }
        }

        #endregion

        #region Methods

        private void BuildChildNodes()
        {
            this.Nodes.Clear();
            IEnumerator ie = DataTableFusion.DataColumnsFusion.GetEnumerator();
            while (ie.MoveNext())
            {
                Nodes.Add(new DataColumnTreeNode((DataColumnFusion)ie.Current));
            }

            Nodes.Add(new DataColumnMainTreeNode(new DataColumnFusion(new DataColumn(DocxReportOptions.CurrentOptions.EmptyMasterTableToken))));
        }

        public virtual ContextMenuStrip GetContextMenu()
        {
            this.TreeView.SelectedNode = this;
            return m_ContextMenu;
        }

        #endregion

        #region Events

        public void ShowDataClick(object sender, EventArgs e)
        {
                ShowDataForm form = new ShowDataForm(DataTableFusion.DataTable);
                form.Show();
        }

        #endregion
    }
}
