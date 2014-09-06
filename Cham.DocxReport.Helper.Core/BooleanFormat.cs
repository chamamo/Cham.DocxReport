using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{
    public class BooleanFormat : StringFormat
    {
        #region Fields

        private bitsBooleanFormat bits;

        #endregion

        #region Constructor

        public BooleanFormat()
            : this(Resources.No, Resources.Yes, " ")
        {
        }

        public BooleanFormat(string falseDisplay, string trueDisplay, string nullDisplay)
        {
            this.FalseDisplay = falseDisplay;
            this.TrueDisplay = trueDisplay;
            this.NullDisplay = nullDisplay;
        }

        #endregion

        #region Prorperties

        public string FalseDisplay
        {
            get
            {
                if (this.bits == null)
                {
                    return Resources.No;
                }
                return this.bits.falseDisplay;
            }
            set
            {
                if ((value != Resources.No) || (this.bits != null))
                {
                    if (this.bits != null)
                    {
                        this.bits.falseDisplay = value;
                    }
                    else
                    {
                        this.bits = new bitsBooleanFormat(value, this.TrueDisplay, this.NullDisplay);
                    }
                }
            }
        }

        public string TrueDisplay
        {
            get
            {
                if (this.bits == null)
                {
                    return Resources.Yes;
                }
                return this.bits.trueDisplay;
            }
            set
            {
                if ((value != Resources.Yes) || (this.bits != null))
                {
                    if (this.bits != null)
                    {
                        this.bits.trueDisplay = value;
                    }
                    else
                    {
                        this.bits = new bitsBooleanFormat(this.FalseDisplay, value, this.NullDisplay);
                    }
                }
            }
        }

        public string NullDisplay
        {
            get
            {
                if (this.bits == null)
                {
                    return " ";
                }
                return this.bits.nullDisplay;
            }
            set
            {
                if ((value != " ") || (this.bits != null))
                {
                    if (this.bits != null)
                    {
                        this.bits.nullDisplay = value;
                    }
                    else
                    {
                        this.bits = new bitsBooleanFormat(this.FalseDisplay, this.TrueDisplay, value);
                    }
                }
            }
        }

        public override object Sample
        {
            get
            {
                return false;
            }
        }

        public override string Name
        {
            get
            {
                return Resources.Boolean;
            }
        }

        #endregion

        #region Methods

        public override string Format(string stringFormat, object arg)
        {
            if ((arg != null) && !(arg is DBNull))
            {
                string str = arg.ToString();
                if (str == "True")
                {
                    return this.TrueDisplay;
                }
                if (str == "False")
                {
                    return this.FalseDisplay;
                }
            }
            return this.NullDisplay;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string GetStrFormat()
        {
            return string.Format("{0}{1}{2}{1}{3}{1}{4}", DocxReportOptions.CurrentOptions.BoolField, DocxReportOptions.CurrentOptions.OptionSeparatorToken, FalseDisplay, TrueDisplay, NullDisplay);
        }

        #endregion

        private class bitsBooleanFormat
        {
            // Fields
            public string falseDisplay;
            public string nullDisplay;
            public string trueDisplay;

            // Methods
            public bitsBooleanFormat(string falseDisplay, string trueDisplay, string nullDisplay)
            {
                this.falseDisplay = falseDisplay;
                this.trueDisplay = trueDisplay;
                this.nullDisplay = nullDisplay;
            }
        }
    }
}
