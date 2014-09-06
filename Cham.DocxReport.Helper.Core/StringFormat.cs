using System;
using System.Collections.Generic;
using System.Text;

namespace Cham.DocxReport.Helper.Core
{
    public abstract class StringFormat : ICloneable
    {
        #region Constructor

        public StringFormat()
        {
            StrFormat = string.Empty;
        }

        #endregion

        #region Properties

        public virtual string StrFormat
        {
            get;
            set;
        }

        public abstract string Name
        {
            get;
        }

        public abstract object Sample { get; }

        #endregion

        #region Methods

        public virtual string Format(object arg)
        {
            return this.Format(this.StrFormat, arg);
        }

        public virtual string Format(string format, object arg)
        {
            try
            {
                if ((arg == null) || (arg is DBNull))
                {
                    return string.Empty;
                }
                if ((this.StrFormat == null) || (this.StrFormat.Length == 0))
                {
                    return arg.ToString();
                }
                bool flag = false;
                if (arg is TimeSpan)
                {
                    TimeSpan span = (TimeSpan)arg;
                    DateTime today = DateTime.Today;
                    if (span.Ticks < 0L)
                    {
                        span = span.Negate();
                        flag = true;
                    }
                    today = new DateTime(today.Year, today.Month, today.Day, span.Hours, span.Minutes, span.Seconds);
                    arg = today;
                }
                return string.Format("{0}{1:" + format + "}", flag ? "-" : "", arg);
            }
            catch
            {
                return ((arg == null) ? string.Empty : arg.ToString());
            }
        }

        public virtual string GetStrFormat()
        {
            return StrFormat;
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region ICloneable Membres

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }

        #endregion
    }
}
