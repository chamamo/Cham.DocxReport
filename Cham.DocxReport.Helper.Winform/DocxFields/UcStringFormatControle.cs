using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class UcStringFormatControle : UserControl
    {
        #region Fields

        public EventHandler UpdateSample;

        #endregion

        #region Constructor

        protected UcStringFormatControle()
        {
            InitializeComponent();
        }

        public UcStringFormatControle(StringFormat format)
        {
            InitializeComponent();
            StrFormat = format;            
        }

        #endregion

        #region Properties

        public StringFormat StrFormat
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        private void InitializeComponentCustom()
        {
            
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponentCustom();
        }

        protected void InvokeUpdateSample()
        {
            if (UpdateSample != null)
            {
                UpdateSample(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
