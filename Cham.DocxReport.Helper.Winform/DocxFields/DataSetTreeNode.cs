using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    class DataSetTreeNode : TreeNode
    {
        #region Constructor

        public DataSetTreeNode(DataSetFusion ds)
            : base(ds.Name)
        {
            Tag = ds;
            ImageIndex = (int)eIcon.Database;
            SelectedImageIndex = this.ImageIndex;
            BuildChildNodes();
            Expand();
        }

        #endregion

        #region Properties

        private DataSetFusion DataSetFusion
        {
            get { return (DataSetFusion)Tag; }
        }

        #endregion

        #region Methods

        private void BuildChildNodes()
        {
            this.Nodes.Clear();
            IEnumerator ie = DataSetFusion.DataTablesFusion.GetEnumerator();
            while (ie.MoveNext())
            {
                this.Nodes.Add(new DataTableTreeNode((DataTableFusion)ie.Current));
            }
        }

        #endregion
    }
}
