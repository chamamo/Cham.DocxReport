using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{
    public class PercentageFormat : CurrencyFormat
    {
        // Methods
        public PercentageFormat():base()
        {
        }

        public override string Format(string stringFormat, object arg)
        {
            if ((arg == null) || (arg is DBNull))
            {
                return string.Empty;
            }


            return string.Format("{0:P" + DecimalDigits + "}", arg);
        }

        public override string GetStrFormat()
        {
            return "P" + DecimalDigits;
        }

        // Properties
        public override object Sample
        {
            get
            {
                return -1.2312;
            }
        }

        public override string Name
        {
            get
            {
                return Resources.Percent;
            }
        }
    }
}
