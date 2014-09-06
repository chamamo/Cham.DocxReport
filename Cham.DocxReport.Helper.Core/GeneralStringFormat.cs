using System;
using System.Collections.Generic;
using System.Text;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Core
{
    public class GeneralStringFormat : StringFormat
    {
        #region Constructor

        public GeneralStringFormat()
        {
            StrFormat = string.Empty;
        }

        #endregion

        #region Properties

        public override object Sample
        {
            get { return Resources.SampleText; }
        }

        public override string Name
        {
            get { return Resources.General; }
        }

        #endregion

        #region Methods

        #endregion
    }
}
