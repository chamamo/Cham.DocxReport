using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class UcTimeFormatControle : UcDateFormatControle
    {
        #region Constructor

        protected UcTimeFormatControle()
        {
            InitializeComponent();
        }

        public UcTimeFormatControle(TimeFormat format)
            : base(format)
        {
            InitializeComponent();
            TimeFormat = format;            
        }

        #endregion

        #region Properties

        private TimeFormat TimeFormat
        {
            get;
            set;
        }
       
        #endregion

        #region Methods

        private void InitializeComponentCustom()
        {
        }

        protected override void BuildFormats()
        {
            Formats = new List<string>();
            Formats.Add("HH:mm");
            Formats.Add("HH:mm:ss");
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponentCustom();
        }

        #endregion

    }
}
