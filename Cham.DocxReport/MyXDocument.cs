using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using System.Data;
using System.Collections;

namespace Cham.DocxReport
{
    class MyXDocument : Container
    {
        #region Constructor

        protected MyXDocument(XElement containerElement, bool newPage):base(containerElement,null, newPage)
        {
        }

        internal MyXDocument(XElement containerElement)
            : base(containerElement, null)
        {
        }

        #endregion

        #region Methods        

        /// <summary>
        /// Peupler le document avec les données du dataSet
        /// </summary>
        public void Fill()
        {
            if (MainDataTableName == null || !CustomDocX.DataSet.Tables.Contains(MainDataTableName))
            {
                base.Fill(null);
            }
            else if (CustomDocX.DataSet.Tables[MainDataTableName].Rows.Count == 1)
            {
                base.Fill(CustomDocX.DataSet.Tables[MainDataTableName].Rows[0]);
            }
            else
            {
                Container docxBackup;
                List<XElement> list = new List<XElement>();
                for (int i = 0; i < CustomDocX.DataSet.Tables[MainDataTableName].Rows.Count; i++)
                {
                    docxBackup = new MyXDocument(new XElement(ContainerElement), i != 0);
                    docxBackup.Fill(CustomDocX.DataSet.Tables[MainDataTableName].Rows[i]);
                    list.AddRange(from d in docxBackup.ContainerElement.Descendants()
                                  where d.Parent == docxBackup.ContainerElement
                                  select d);
                }

                //Suuprmier la premiere entrée
                this.ContainerElement.Descendants().Remove();
                //Ajouter la collection au conteneur
                ContainerElement.Add(list.ToArray());
            }
        }

        #endregion
    }
}
