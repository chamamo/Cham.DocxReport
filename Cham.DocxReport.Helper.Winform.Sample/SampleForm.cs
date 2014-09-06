using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core;
using Cham.DocxReport.Helper.Winform.DocxFields;
using Cham.DocxReport.Helper.Winform.Sample.NorthwindDataSetTableAdapters;
using System.IO;
using System.Diagnostics;

namespace Cham.DocxReport.Helper.Winform.Sample
{
    public partial class SampleForm : Form
    {
        private NorthwindDataSet ds;
        public SampleForm()
        {
            InitializeComponent();

            ds = new NorthwindDataSet();

            var ordersAdapter = new OrdersTableAdapter();
            ordersAdapter.Fill(ds.Orders);

            var customrAdapter = new CustomersTableAdapter();
            customrAdapter.Fill(ds.Customers);
            
        }

        private DataSetFusionExplorer m_DataSetFusionExplorer;
        private void ShowDataSetFusionExplorer(string value)
        {
            System.Diagnostics.Process.Start(value);
            if (m_DataSetFusionExplorer == null)
            {
                m_DataSetFusionExplorer = new DataSetFusionExplorer(ds);
                m_DataSetFusionExplorer.FormClosed += new FormClosedEventHandler(formFusion_FormClosed);
                m_DataSetFusionExplorer.Show();
            }
        }

        private void formFusion_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_DataSetFusionExplorer = null;
        }

        //private void btnNewTemplate_Click(object sender, EventArgs e)
        //{
        //    string value = Core.Utils.GetDocxAssociatedProgram();
        //    if (!string.IsNullOrEmpty(value))
        //    {
        //        ShowDataSetFusionExplorer(value);
        //    }
        //}

        private void btnOpenTemplate_Click(object sender, EventArgs e)
        {
            ShowDataSetFusionExplorer("Sample.docx");
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var destination = string.Format("{0}{1}.docx", Path.GetTempPath(), Guid.NewGuid());
            Cham.DocxReport.Docx.Process(ds, "Sample.docx", destination);
            Process.Start(destination);
            Cursor = Cursors.Default;
        }        
    }
}
