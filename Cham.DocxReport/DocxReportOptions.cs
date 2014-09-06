using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cham.DocxReport
{

    public class DocxReportOptions
    {
        public DocxReportOptions()
        {
            
        }

        #region Properties

        private static DocxReportOptions m_currentOptions;
        public static DocxReportOptions CurrentOptions
        {
            set { m_currentOptions = value; }
            get { return m_currentOptions ?? (m_currentOptions = DefaultOptions); }
        }

        private Regex m_BoolRegex;
        internal Regex BoolRegex
        {
            get
            {
                if (m_BoolRegex == null)
                {
                    m_BoolRegex = new Regex(string.Format("{0}{1}(?<{2}>[\\w]+){1}(?<{3}>[\\w]+){1}(?<{4}>[.]*)",
                        BoolField, Regex.Escape(OptionSeparatorToken), FalseDisplayField, TrueDisplayField, NullDisplayField));
                }
                return m_BoolRegex;
            }
        }

        private Regex m_fieldParameterRegex;
        internal Regex FieldParameterRegex
        {
            get
            {
                if (m_fieldParameterRegex == null)
                {
                    m_fieldParameterRegex = new Regex(string.Format(@"{0}(?<{2}>[A-Z|a-z|0-9|_]{{1,}})\.{{1,}}(?<{3}>[a-zA-Z0-9_ ]{{1,}})" +
                                                                            "({4}(?<{5}>([^{1}]){{1,}})){{0,1}}{1}",
                                                            Regex.Escape(BeginToken), Regex.Escape(EndToken), TableNameField,
                                                            ColumnNameField, Regex.Escape(FormatToken), FormatField));
                }
                return m_fieldParameterRegex;
            }
        }

        private static DocxReportOptions m_defaultOptions;
        public static DocxReportOptions DefaultOptions
        {
            get
            {
                if (m_defaultOptions == null)
                {
                    m_defaultOptions = new DocxReportOptions()
                    {
                        BeginToken = "<",
                        EndToken=">",
                        FormatToken = "%",
                        OptionSeparatorToken = "|",
                        OptionSeparatorValueToken =":",
                        EmptyMasterTableToken = "Empty",
                        BoolField = "Bool",

                    };
                }
                return m_defaultOptions;
            }
        }
        


        public string BeginToken { get; set; }
        public string EndToken { get; set; }
        public string FormatToken { get; set; }
        public string OptionSeparatorToken { get; set; }
        public string OptionSeparatorValueToken { get; set; }
        public string EmptyMasterTableToken { get; set; }
        public string BoolField { get; set; }

        internal static string TableNameField = "TableName";
        internal static string ColumnNameField = "ColumnName";
        internal static string FormatField = "Format";
        internal static string FalseDisplayField = "FalseDisplay";
        internal static string TrueDisplayField  = "TrueDisplay";
        internal static string NullDisplayField = "NullDisplay";

        #endregion

    }
}
