using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe representant la ligne d'un tableau dans word
    /// </summary>
    internal class Row : Container
    {
        #region Champs

        private List<Cell> m_Cells;

        #endregion

        #region Constructor

        public Row(XElement rowElement, Container customContainerParent) :
            base(rowElement, customContainerParent)
        {

            BuildCells();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définit la liste des cellules de la ligne
        /// </summary>
        public List<Cell> Cells
        {
            get { return m_Cells; }
            set { m_Cells = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Construire la liste des cellules
        /// </summary>
        internal void BuildCells()
        {
            Cells = (from c in ContainerElement.Elements(W.tc)
                       where c.Parent.Name == ContainerElement.Name
                                select new Cell(c, this)).ToList();           
        }

        #endregion
    }
}
