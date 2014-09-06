using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core.Properties;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class UcNumberFormatControle : UcStringFormatControle
    {
        #region Constructor

        public UcNumberFormatControle()
        {
            InitializeComponent();
        }

        public UcNumberFormatControle(NumberFormat format)
            : base(format)
        {
            InitializeComponent();
            NumberFormat = format;
        }

        #endregion

        #region Properties

        private NumberFormat NumberFormat
        {
            get;
            set;
        }

        #endregion

        #region Methods

        protected virtual void InitializeComponentCustom()
        {
            lblDecimalDigits.Text = Resources.NumberOfDecimalPlaces;
            nsDecimalDigits.Value = NumberFormat.DecimalDigits;
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponentCustom();
        }

        private void nsDecimalDigits_ValueChanged(object sender, EventArgs e)
        {            
                NumberFormat.DecimalDigits = (int)nsDecimalDigits.Value;
                base.InvokeUpdateSample();
        }

        #endregion
    }
}
