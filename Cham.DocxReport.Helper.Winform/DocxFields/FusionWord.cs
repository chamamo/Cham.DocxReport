using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal class FusionWord
    {
        #region Methods statiques

        internal static void Process(DataSet dataSetForFusion, string fileName, string fileDestination)
        {
            Cham.DocxReport.Docx.Process(dataSetForFusion, fileName, fileDestination);            
        }

        internal static void Show(string fileName)
        {
            ShowOrPrint(fileName, null, true, false);
        }

        internal static void Print(string fileName, string printerName = null)
        {
            ShowOrPrint(fileName, printerName, false, true);
        }

        private static void ShowOrPrint(string fileName, string printerName, bool show, bool print)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fileName);
            psi.UseShellExecute = true;
            if (print)
            {
                if (String.IsNullOrEmpty(printerName))
                {
                    psi.Verb = "print";
                }
                else
                {
                    psi.Verb = "printto";
                    psi.Arguments = "\"" + printerName + "\"";
                }
            }
            psi.WindowStyle = show ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
            System.Diagnostics.Process.Start(psi);
        }

        #endregion
    }
}
