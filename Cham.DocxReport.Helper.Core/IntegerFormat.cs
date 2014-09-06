using System;
using System.Collections.Generic;
using System.Text;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{
    public class IntegerFormat : NumberFormat
    {
        #region Constructor

        public IntegerFormat()
        {
            this.DecimalDigits = 0;
        }

        #endregion

        #region Properties

        public override object Sample
        {
            get
            {
                return -1234567;
            }
        }

        public override string Name
        {
            get
            {
                return Resources.Integer;
            }
        }

        #endregion

        #region Methods

        public override object Clone()
        {
            return base.Clone() as IntegerFormat;
        }

        #endregion
    }

}
