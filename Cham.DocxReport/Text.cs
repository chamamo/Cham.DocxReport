using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Cham.DocxReport
{
    [Serializable]
    public class Text
    {
        #region Properties

        /// <summary>
        /// Obtient ou définit l'element XML du text
        /// </summary>
        public XElement TextElement { get; set; }
        /// <summary>
        /// Obtient ou définit la longeur du text
        /// </summary>
        public int TextLength { get; set; }
        /// <summary>
        /// Obtient ou définit l'indexe du texte
        /// </summary>
        public int TextLocation { get; set; }
        /// <summary>
        /// Obtient ou définit le run parent
        /// </summary>
        public Run RunParent { get; set; }
        /// <summary>
        /// Obtient ou définit l'endroit du texte
        /// </summary>
        public string Value
        {
            get
            {
                return TextElement.Value;
            }
            set
            {
                TextElement.Value = value;
            }
        }
        /// <summary>
        /// Obtient ou définit l'index du text dans le run
        /// </summary>
        public int Index { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Concatenation
        /// </summary>
        /// <param name="str">chaine à ajouter</param>
        public void Append(string str)
        {
            TextElement.Value += str;
            UpdateLength(str.Length);
        }

        /// <summary>
        /// Mettre à jour la longueur du texte
        /// </summary>
        /// <param name="delta"></param>
        private int UpdateLength(int delta)
        {
            TextLength += delta;
            RunParent.RunLength += delta;
            if (RunParent.RunLength == 0)
            {
                RunParent.RunElement.Remove();
            }
            return delta;
        }

        /// <summary>
        /// Remplacer une chaine par une autre
        /// </summary>
        /// <param name="oldStr">ancienne chaine</param>
        /// <param name="newStr">nouvelle chaine</param>
        public int Replace(string oldStr, string newStr)
        {
            Value = Value.Replace(oldStr, newStr);
            return UpdateLength(newStr.Length - oldStr.Length);
        }

        #endregion
    }
}
