using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal class DataSetTreeView : TreeView
    {
        #region Constructor

        public DataSetTreeView()
        {
            this.ImageList = Icons.ImageList;
        }

        #endregion

        #region Methods

        public void BuildChildNodes(DataSet ds)
        {
            this.Nodes.Clear();
            this.Nodes.Add(new DataSetTreeNode(new DataSetFusion(ds)));
        }

        #endregion

        #region Events

        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeNode node = this.GetNodeAt(e.X, e.Y);
            if ((node != null) && (node is DataColumnTreeNode || node is DataTableTreeNode) && e.Button==MouseButtons.Right)
            {
                this.SelectedNode = node;
                this.ContextMenuStrip = node is DataTableTreeNode? ((DataTableTreeNode)node).GetContextMenu() : ((DataColumnTreeNode)node).GetContextMenu();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            TreeNode node = this.SelectedNode;
            if ((node != null) && (node is DataColumnTreeNode))
            {
                ((DataColumnTreeNode)node).Format(this, e);
            }
            base.OnMouseDoubleClick(e);
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            TreeNode node = e.Item as TreeNode;
            if ((node != null) && (node is DataColumnTreeNode))
            {
                this.DoDragDrop(((DataColumnTreeNode)node).StringField, DragDropEffects.Copy);
            }
            base.OnItemDrag(e);
        }        

        #endregion
    }
}
