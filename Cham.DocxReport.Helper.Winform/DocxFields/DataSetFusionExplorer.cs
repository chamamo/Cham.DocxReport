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
    public partial class DataSetFusionExplorer : Form
    {
        #region Constructor

        protected DataSetFusionExplorer()
        {
            InitializeComponent();
        }

        public DataSetFusionExplorer(DataSet ds)
        {
            InitializeComponent();
            InitializeComponentCustom(ds);
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        private void InitializeComponentCustom(DataSet ds)
        {
            Text = Resources.Structure;
            listView.BuildChildNodes(ds);
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - Width, 0);
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            TopMost = true;
            btnFermer.Text = Resources.Close;
        }

        #endregion

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
