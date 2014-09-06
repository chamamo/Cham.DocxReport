using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Packaging;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cham.DocxReport
{
    /// <summary>
    /// Seul point d'entrée depuis l'éxterieur à la DLL
    /// </summary>
    public class Docx
    {
        #region Properties

        /// <summary>
        /// Obtient ou définit le fichiier temporaire
        /// </summary>
        //private static string FileNameDestination
        //{
        //    get;
        //    set;
        //}         

        #endregion

        #region Methods

        /// <summary>
        /// Charger le fichier docx
        /// </summary>
        /// <param name="fileName"></param>
        private static void LoadFromDocx(string fileName, string fileDestination)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName);
            File.Copy(fileName, fileDestination, true);         
        }

        public static void Process(DataSet dataSet, string fileName, string fileDestination)
        {
            Process(dataSet, fileName, fileDestination, DocxReportOptions.CurrentOptions);
        }

        public static void Process(DataSet dataSet, string fileName, string fileDestination, DocxReportOptions options)
        {
            Fonctions.DocxReportOptions = options;
            ProcessInternal(dataSet, fileName, fileDestination);
        }

        /// <summary>
        /// Traiter le document docx
        /// </summary>
        /// <param name="dataSet">DataSet contenant le jeu de données</param>
        /// <param name="fileName">le chemin du fichier docx</param>
        private static void ProcessInternal(DataSet dataSet, string fileName, string fileDestination)
        {
            LoadFromDocx(fileName, fileDestination);
            CustomDocX.DataSet = dataSet;
            CustomDocX docx = CustomDocX.Load(fileDestination);
            docx.Fill();
            docx.Save();
            docx.Close();
        }

        #endregion
    }    
}
