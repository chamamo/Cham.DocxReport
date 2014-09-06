using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Cham.DocxReport.Helper.Core
{
    public class Utils
    {
        public static string GetDocxAssociatedProgram()
        {
            object strExtValue;
            try
            {
                var fileExtension = ".docx";


                RegistryKey objExtReg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\UserChoice\" + fileExtension);
                strExtValue = (objExtReg == null ? null : objExtReg.GetValue("progid"));

                if (strExtValue == null)
                {
                    objExtReg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + fileExtension);
                    strExtValue = (objExtReg == null ? null : objExtReg.GetValue("progid"));
                    if (strExtValue == null)
                    {
                        objExtReg = Registry.ClassesRoot.OpenSubKey(fileExtension);
                        strExtValue = objExtReg.GetValue("");
                    }
                }

                if (strExtValue != null)
                {
                    RegistryKey objAppReg = Registry.ClassesRoot.OpenSubKey(strExtValue + @"\shell\open\command");
                    string[] splitArray = objAppReg.GetValue(null).ToString().Split(new string[] { "\"" }, StringSplitOptions.None);
                    if (splitArray[0].Length > 0)
                    {
                        return splitArray[0].Replace("%1", "");
                    }
                    else
                    {
                        return splitArray[1].Replace("%1", "");
                    }
                }
            }
            catch
            {

            }
            return "";

        }
    }
}
