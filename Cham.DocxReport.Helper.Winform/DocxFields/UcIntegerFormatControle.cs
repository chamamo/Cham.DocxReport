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
    internal partial class UcIntegerFormatControle : UcStringFormatControle
    {
        protected UcIntegerFormatControle()
        {
            InitializeComponent();
        }

        public UcIntegerFormatControle(IntegerFormat format)
            : base(format)
        {
            InitializeComponent();
        }
    }
}
