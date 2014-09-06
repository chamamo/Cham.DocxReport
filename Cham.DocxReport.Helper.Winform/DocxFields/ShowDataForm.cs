using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class ShowDataForm : Form
    {
        #region Constructor

        protected ShowDataForm()
        {
            InitializeComponent();
        }

        public ShowDataForm(DataTable table) : this()
        {
            InitializeComponentCustom(table);
        }

        #endregion

        #region Methods

        private void InitializeComponentCustom(DataTable table)
        {
            Text = string.Format("{0} - {1}", table.TableName, Resources.ShowData);
            dgData.AllowUserToAddRows = false;
            dgData.ReadOnly = true;
            dgData.DataSource = table;
            dgData.AutoGenerateColumns = true;
        }

        #endregion
    }
}
