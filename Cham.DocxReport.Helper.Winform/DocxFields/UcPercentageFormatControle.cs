using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class UcPercentageFormatControle : UcNumberFormatControle
    {
        #region Constructor

        public UcPercentageFormatControle()
        {
            InitializeComponent();
        }

        public UcPercentageFormatControle(PercentageFormat format)
            : base(format)
        {
            InitializeComponent();
            PercentageFormat = format;
        }

        #endregion

        #region Properties

        private PercentageFormat PercentageFormat
        {
            get;
            set;
        }

        #endregion

        #region Methods

        protected override void InitializeComponentCustom()
        {
            base.InitializeComponentCustom();

        }

        #endregion

    }
}
