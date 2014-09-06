using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    class DataColumnTreeNode : TreeNode
    {
        #region Fields

        private StringFormat m_StringFormat;
        private DataColumnFusionContextMenu m_ContextMenu = new DataColumnFusionContextMenu();

        #endregion

        #region Constructor

        public DataColumnTreeNode(DataColumnFusion column)
            : base(column.Name)
        {
            Tag = column;
            ImageIndex = (int)eIcon.Column;
            SelectedImageIndex = this.ImageIndex;

            this.m_ContextMenu.MiseEnformeClick += new System.EventHandler(this.Format);
            this.m_ContextMenu.CopierClick += new System.EventHandler(this.Copy);
        }

        #endregion

        #region Properties

        private DataColumnFusion DataColumnFusion
        {
            get { return (DataColumnFusion)Tag; }
        }

        public virtual string StringField
        {
            get
            {
                string format = StringFormat.GetStrFormat();
                return string.Format("{0}{2}.{3}{4}{1}",
                    DocxReportOptions.CurrentOptions.BeginToken, DocxReportOptions.CurrentOptions.EndToken, ((DataTableTreeNode)Parent).Text, Text, string.IsNullOrEmpty(format) ? "" : DocxReportOptions.CurrentOptions.FormatToken + format);
            }
        }

        public StringFormat StringFormat
        {
            get
            {
                if (m_StringFormat == null)
                {
                    BuildStringFormat();
                }
                return m_StringFormat;
            }
            set { m_StringFormat = value; }
        }

        #endregion

        #region Methods

        private void BuildStringFormat()
        {
            //Type t = ;
            string type = DataColumnFusion.Column.DataType.Name;

            switch (type)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                    StringFormat = new IntegerFormat();
                    break;
                case "Decimal":
                case "Single":
                case "Double":
                    StringFormat = new NumberFormat();
                    break;
                case "DateTime":
                    StringFormat = new DateFormat();
                    break;
                case "Boolean":
                    StringFormat = new BooleanFormat();
                    break;
                default:
                    StringFormat = new GeneralStringFormat();
                    break;
            }
        }

        public virtual ContextMenuStrip GetContextMenu()
        {
            this.TreeView.SelectedNode = this;
            return m_ContextMenu;
        }

        #endregion

        #region Events

        public void Format(object sender, System.EventArgs e)
        {
            using (var form = new StringFormatEditor(StringFormat))
            {
                form.TopMost = true;
                if (DialogResult.OK == form.ShowDialog())
                {
                    StringFormat = form.StringFormat;
                }
            }
        }

        private void Copy(object sender, System.EventArgs e)
        {
            Clipboard.SetText(StringField);
        }

        #endregion
    }
}
