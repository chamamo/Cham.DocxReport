using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe representant la cellule d'un tableau dans word
    /// </summary>
    internal class Cell : Container
    {
        #region Constructor

        /// <summary>
        /// Constructeur de la class
        /// </summary>
        /// <param name="cellElement">l'element xml</param>
        /// <param name="customContainerParent">le conteneur parent</param>
        public Cell(XElement cellElement, Container customContainerParent)
            : base(cellElement, customContainerParent)
        {
        }

        #endregion
    }
}
