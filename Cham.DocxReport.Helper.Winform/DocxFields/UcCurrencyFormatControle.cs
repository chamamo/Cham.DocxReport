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
    internal partial class UcCurrencyFormatControle : UcNumberFormatControle
    {
        #region Constructor

        protected UcCurrencyFormatControle()
        {
            InitializeComponent();
        }

        public UcCurrencyFormatControle(CurrencyFormat format)
            : base(format)
        {
            InitializeComponent();
            CurrencyFormat = format;            
        }

        #endregion

        #region Properties

        private CurrencyFormat CurrencyFormat
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
