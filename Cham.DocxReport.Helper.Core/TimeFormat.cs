using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{

    public class TimeFormat : DateFormat
    {
        private static string defaultFormat = "hh:mm";
        // Methods
        public TimeFormat()
            : this(defaultFormat)
        {
        }

        public TimeFormat(string strFormat)
        {
            this.StrFormat = strFormat;
        }        

        public override string Name
        {
            get
            {
                return Resources.Hour;
            }
        }

    }
}
