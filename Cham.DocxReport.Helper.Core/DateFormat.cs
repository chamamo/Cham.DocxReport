using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{
    public class DateFormat : StringFormat
    {
        // Fields
        private string nullDisplay;

        // Methods
        public DateFormat()
            : this("d", " ")
        {
        }

        public DateFormat(string stringFormat, string nullDisplay)
        {
            this.nullDisplay = " ";
            this.StrFormat = stringFormat;
            this.nullDisplay = nullDisplay;
        }

        public override string Format(string stringFormat, object arg)
        {
            if ((arg == null) || (arg is DBNull))
            {
                return string.Empty;
            }
            if ((this.StrFormat != null) && (this.StrFormat.Length != 0))
            {
                return string.Format("{0:" + stringFormat + "}", arg);
            }
            return arg.ToString();
        }

        public override object Sample
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override string Name
        {
            get
            {
                return Resources.Date;
            }
        }
    }
}
