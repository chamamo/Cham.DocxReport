using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using System.Reflection;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO.Packaging;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe contenant les méthodes d'extension
    /// </summary>
    static class LocalExtensions
    {
        /// <summary>
        /// Récupérer les Parts d'un XDocument
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public static XDocument GetXDocument(this OpenXmlPart part)
        {
            XDocument xdoc = part.Annotation<XDocument>();
            if (xdoc != null)
                return xdoc;
            using (StreamReader streamReader = new StreamReader(part.GetStream()))
            {
                xdoc = XDocument.Load(XmlReader.Create(streamReader));
            }
            part.AddAnnotation(xdoc);
            return xdoc;
        }

        /// <summary>
        /// Sauvegarder le Part
        /// </summary>
        /// <param name="part"></param>
        public static void SaveXDocument(this OpenXmlPart part)
        {
            XDocument xdoc = part.Annotation<XDocument>();
            if (xdoc != null)
            {
                using (XmlWriter xw =
                  XmlWriter.Create(part.GetStream(FileMode.Create, FileAccess.Write)))
                    xdoc.WriteTo(xw);
            }
        }

        /// <summary>
        /// Concatener les texts
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StringConcatenate(this IEnumerable<string> source)
        {

            StringBuilder sb = new StringBuilder();

            foreach (string s in source)

                sb.Append(s);

            return sb.ToString();

        }       
    }
}
