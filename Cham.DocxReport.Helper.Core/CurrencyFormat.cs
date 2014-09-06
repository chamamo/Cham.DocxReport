using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{
    public class CurrencyFormat : NumberFormat
    {
        public CurrencyFormat():base()
        {   
        }

        public override string Format(string stringFormat, object arg)
        {
            if ((arg == null) || (arg is DBNull))
            {
                return string.Empty;
            }
            
            return string.Format("{0:C"+DecimalDigits+"}", new object[] { arg });
        }

        public override string GetStrFormat()
        {
            return "C" + DecimalDigits;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object Sample
        {
            get
            {
                return -1234.12345679;
            }
        }

        public override string Name
        {
            get
            {
                return Resources.Currency;
            }
        }
    }
}
