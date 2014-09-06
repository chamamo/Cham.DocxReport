using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe conenant les namespaces OpenXml Element
    /// </summary>
    public static class W
    {
        public static XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
        public static XName body = w + "body";//L'element Body, point d'entrée d'une XElement MainDoc      
        public static XName p = w + "p";//Paragraphe
        public static XName pPr = w + "pPr";//Propriétés du paragraphe
        public static XName r = w + "r";//Run
        public static XName rPr = w + "rPr";//Propriétés du Run
        public static XName t = w + "t";//Texte
        public static XName instrText = w + "instrText"; //MERGEFIELD 
        public static XName br = w + "br";//Saut de ligne
        public static XName tbl = w + "tbl";//Tableau 
        public static XName tr = w + "tr";//Ligne dans un tableau
        public static XName tc = w + "tc"; //Cellule
        //public static XName style = w + "style";
        public static XName type = w + "type";
        public static XName drawing = w + "drawing";
        //public static XName styleId = w + "styleId";
        //public static XName name = w + "name";
        //public static XName val = w + "val";
        //public static XName basedOn = w + "basedOn";        
        //public static XName ins = w + "ins";
        // "default" is not a valid identifier, so must use _default
        //public static XName _default = w + "default";
        //public static XName pStyle = w + "pStyle";        
        public static XName del = w + "del";
        public static XName moveFrom = w + "moveFrom";
    }
}
