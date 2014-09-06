using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Office.CustomUI;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe représente un tableau dans word
    /// </summary>
    class Table : Container
    {
        #region Constructor

        public Table(XElement tableElement, Container customContainerParent) :
            base(tableElement, customContainerParent)
        {
            BuildRows();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définit la liste des lignes du tableau
        /// </summary>
        public List<Row> Rows
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Construire la liste des lignes du tableau
        /// </summary>
        private void BuildRows()
        {
            Rows = (from r in ContainerElement.Elements(W.tr)
                    where r.Parent == ContainerElement
                    select new Row(r, this)).ToList();
        }

        /// <summary>
        /// Remplir la table avec les données correspendante
        /// </summary>
        /// <param name="dataRow"></param>
        public override void Fill(DataRow dataRow)
        {
            base.Fill(dataRow);

            foreach (var r in Rows)
            {
                if (r.FieldsParameters.Count > 0)
                {
                    generateRows(r, dataRow);
                }
                else
                {
                    r.ContainerElement.Remove();
                    var emptyRow = new Row(new XElement(r.ContainerElement), this);
                    var tr = new XElement(W.tr, emptyRow.ContainerElement.Elements());
                    ContainerElement.Add(tr);
                }
            }
        }

        /// <summary>
        /// Dupliquer la ligne du tableau si elle contient des champs de fusion autant de fois que de lignes dans le DataTable correspondante
        /// </summary>
        /// <param name="row"></param>
        private void generateRows(Row row, DataRow dataRow)
        {
            //Récuper la relation avec le conteneur parent
            var rel =
                (from DataRelation r in CustomDocX.DataSet.Relations
                 where MainDataTableName != null &&
                    MainDataTableName.Equals(r.ChildTable.TableName, StringComparison.CurrentCultureIgnoreCase) &&
                    r.ParentTable.TableName.Equals(CustomContainerParent.MainDataTableName, StringComparison.CurrentCultureIgnoreCase)
                 select r).FirstOrDefault();

            DataRow[] rows = null;
            if (rel != null)
            {
                rows = dataRow.GetChildRows(rel);
            }
            else if (MainDataTableName.Equals(CustomContainerParent.MainDataTableName, StringComparison.CurrentCultureIgnoreCase))
            {
                rows = new DataRow[] { dataRow };
            }
            else
            {
                //S'il n'y a pas de relation on prend toutes les lignes du DataTable
                rows = CustomDocX.DataSet.Tables[MainDataTableName].Select();
            }


            if (rows == null)
            {
                //Si aucune ligne trouver, supprimer la ligne du tableau
                row.ContainerElement.Remove();
            }
            else
            {
                int index = 0;
                while (index < rows.Length)
                {
                    Row newRow = new Row(new XElement(row.ContainerElement), this);

                    foreach (Cell cell in newRow.Cells)
                    {
                        cell.Fill(rows[index]);
                    }
                    var tr = new XElement(W.tr, newRow.ContainerElement.Elements());
                    ContainerElement.Add(tr);
                    index++;
                }
                row.ContainerElement.Remove();
            }
        }

        #endregion
    }
}
