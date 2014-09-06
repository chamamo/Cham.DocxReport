using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{
    public class NumberFormat : StringFormat
    {
        
        #region Constructor

        public NumberFormat()
        {
            this.DecimalDigits = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalDigits;
        }

        #endregion

        #region Properties

        public int DecimalDigits
        {
            get;
            set;
        }

        public override object Sample
        {
            get
            {
                return -1234.123456789;
            }
        }

        public override string Name
        {
            get
            {
                return Resources.Number;
            }
        }

        #endregion

        #region Methods

        public override string Format(string stringFormat, object arg)
        {
            if ((arg == null) || (arg is DBNull))
            {
                return string.Empty;
            }

            return string.Format("{0:N" + DecimalDigits + "}", arg);
        }

        public override string GetStrFormat()
        {
            return "N" + DecimalDigits;
        }

        public override object Clone()
        {
            NumberFormat format = base.Clone() as NumberFormat;
            return format;
        }

        #endregion

    }
}

