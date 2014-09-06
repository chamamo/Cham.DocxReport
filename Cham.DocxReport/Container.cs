using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe représente un conteneur dans un document word (ça peut etre un document, tableau, ligne, cellue..)
    /// </summary>
    class Container
    {
        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="containerElement">l'élément XML du conteneur</param>
        /// <param name="customContainerParent">La classe parente qu icontient cette classe</param>
        /// <param name="newPageBefore">mettre le conteneur dans une nouvelle page, si l'utilisateur choisi d'imprimer sous form de fiche</param>
        protected Container(XElement containerElement, Container customContainerParent, bool newPageBefore)
            : this(containerElement, customContainerParent)
        {
            if (newPageBefore)
            {
                AddNewPageBefore();
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="containerElement"l'élément XML du conteneur></param>
        /// <param name="customContainerParent">La classe parente qu icontient cette classe</param>
        public Container(XElement containerElement, Container customContainerParent)
        {
            ContainerElement = containerElement;
            CustomContainerParent = customContainerParent;
            FieldsParameters = new List<FieldParameter>();
            BuildParagraphs();
            BuildTables();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définit la liste des paragraphes du conteneur
        /// </summary>
        public List<Paragraph> Paragraphs
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit la liste des tableaux
        /// </summary>
        public List<Table> Tables
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit l'element XML
        /// </summary>
        public XElement ContainerElement
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit la liste des champs de fusion
        /// </summary>
        public List<FieldParameter> FieldsParameters
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit le conteneur parent
        /// </summary>
        public Container CustomContainerParent
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit le nom du DataTable
        /// </summary>
        public string MainDataTableName
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Construire les paragraphes
        /// </summary>
        protected void BuildParagraphs()
        {
            Paragraphs =
               (from p in ContainerElement.Descendants(W.p)
                where p.Parent == ContainerElement
                select new Paragraph(p, this)
                    ).ToList();

        }

        /// <summary>
        /// Construire les tableaux
        /// </summary>
        protected void BuildTables()
        {
            Tables =
                (from t in ContainerElement.Descendants(W.tbl)
                 where t.Parent == ContainerElement
                 select new Table(t, this)
                ).ToList();
        }

        /// <summary>
        /// Ajouter un champs de fusion
        /// </summary>
        /// <param name="field"></param>
        /// <param name="paragraph"></param>
        internal virtual void AddFieldParameters(FieldParameter field, XElement paragraph)
        {
            if (field.ColumnName.Equals(Fonctions.DocxReportOptions.EmptyMasterTableToken, StringComparison.CurrentCultureIgnoreCase))
            {
                MainDataTableName = field.TableName;
                FieldsParameters.Add(field);
            }
            //Si c'est le premier champs de fusion trouvé, la table maitre du conteneur et la table du champs de fusion
            else if (FieldsParameters.Count == 0 || (FieldsParameters.Count > 0 && MainDataTableName.Equals(field.TableName, StringComparison.CurrentCultureIgnoreCase)))
            {
                if (FieldsParameters.Count == 0)
                {
                    MainDataTableName = field.TableName;
                }
                FieldsParameters.Add(field);
            }
            else
            {

                //Récuper la relation avec le conteneur parent
                var rel = GetDataRelation(MainDataTableName, field.TableName);
                if (rel != null)
                {
                    field.DataRelation = rel;
                    FieldsParameters.Add(field);
                }
                else
                {

                    throw new Exception(string.Format("Les colonnes ne proviennent pas de la meme table \n paragraphe: {0}.", paragraph.Value));
                }
            }

            if (!(this is Table || this is MyXDocument))
            {
                if (CustomContainerParent != null) CustomContainerParent.AddFieldParameters(field, paragraph);
            }
        }

        public static DataRelation GetDataRelation(string mainDataTableName, string fieldTableName)
        {
            if (string.IsNullOrEmpty(mainDataTableName)) return null;
            var rel =
                    (from DataRelation r in CustomDocX.DataSet.Relations
                     where
                     r.ParentTable.TableName.Equals(fieldTableName, StringComparison.CurrentCultureIgnoreCase) &&
                        r.ChildTable.TableName.Equals(mainDataTableName, StringComparison.CurrentCultureIgnoreCase)
                     select r).FirstOrDefault();

            if (rel == null)
            {
                rel = (from DataRelation r in CustomDocX.DataSet.Relations
                       where
                            r.ParentTable.TableName.Equals(mainDataTableName, StringComparison.CurrentCultureIgnoreCase) &&
                            r.ChildTable.TableName.Equals(fieldTableName, StringComparison.CurrentCultureIgnoreCase)
                       select r).FirstOrDefault();
            }
            return rel;
        }

        /// <summary>
        /// Remplacer les champs de fusion par les données
        /// </summary>
        /// <param name="dataRow">le dataRow qu contient les données</param>
        public virtual void Fill(DataRow dataRow)
        {
            foreach (var p in Paragraphs)
            {
                p.Fill(dataRow);
            }

            foreach (var t in Tables)
            {
                t.Fill(dataRow);
            }
        }

        /// <summary>
        /// Ajouter un saut de page
        /// </summary>
        private void AddNewPageBefore()
        {
            ContainerElement.AddFirst(new XElement(
                    W.p,
                    new XElement(W.r,
                        new XElement(W.br,
                            new XAttribute(W.type, "page")))));
        }

        #endregion
    }
}
