using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections;

namespace Cham.DocxReport
{
    internal static class Fonctions
    {
        public static DocxReportOptions DocxReportOptions;
        /// <summary>
        /// Récupérer la longueur du Run
        /// </summary>
        /// <param name="e">l'élément XML</param>
        /// <returns>longueur du Run</returns>
        internal static int GetRunLength(XElement e)
        {
            return
                (
                from k in e

                .Descendants()
                where k.Name == W.t || k.Name == W.instrText
                select k
                )
                .Select(t => (string)t)

                .StringConcatenate()

                .Length;
        }

        /// <summary>
        /// Récupérer le text du Run
        /// </summary>
        /// <param name="e">l'élement XML</param>
        /// <returns>concaténation des texts contenus dans le Run</returns>
        internal static string GetRunString(XElement e)
        {
            return e

                .Descendants(W.t)

                .Select(t => (string)t)

                .StringConcatenate();
        }

        /// <summary>
        /// Générer un fichier temporaire
        /// </summary>
        /// <param name="ext">extension</param>
        /// <returns>chemin du fichier</returns>
        internal static string GetTempFilePath(string ext)
        {
            return Path.GetTempPath() + Guid.NewGuid() + "." + ext;
        }
              
    }
}
