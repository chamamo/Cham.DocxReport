using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using System.Data;

namespace Cham.DocxReport
{
    class CustomDocX
    {
        #region Champs

        private WordprocessingDocument m_WordprocessingDocument;

        #endregion

        #region Constructor

        protected CustomDocX()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définit le document Word (corp du document, footers, headers)
        /// </summary>
        public WordprocessingDocument WordprocessingDocument
        {            
            get { return m_WordprocessingDocument; }
            set
            {
                m_WordprocessingDocument = value;
                MainDoc = new MyXDocument(m_WordprocessingDocument.MainDocumentPart.GetXDocument().Root.Descendants(W.body).Single());

                //Charger les Headers
                Headers = new List<MyXDocument>();
                foreach (var h in m_WordprocessingDocument.MainDocumentPart.HeaderParts)
                {
                    Headers.Add(new MyXDocument(h.GetXDocument().Root));
                }
                //Charger les Footers
                Footers = new List<MyXDocument>();
                foreach (var f in m_WordprocessingDocument.MainDocumentPart.FooterParts)
                {
                    Footers.Add(new MyXDocument(f.GetXDocument().Root));
                }
            }
        }

        /// <summary>
        /// Obtient ou définit l'objet MyXDocument qui représente le corp du document
        /// </summary>
        public MyXDocument MainDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit la liste des headers
        /// </summary>
        public List<MyXDocument> Headers
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit la liste des footers
        /// </summary>
        public List<MyXDocument> Footers
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit la liste des champs de fusion présents dans le document
        /// </summary>
        public List<FieldParameter> FieldsParameters
        {
            get;
            private set;
        }

        /// <summary>
        /// Obtient ou définit le DataSet contenant le jeu de données
        /// </summary>
        public static DataSet DataSet
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Charger le document Docx
        /// </summary>
        /// <param name="FileName">le chemin du fichier docx</param>
        /// <returns>CustomDocX</returns>
        internal static CustomDocX Load(string FileName)
        {
            WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(FileName, true);
            return new CustomDocX() { WordprocessingDocument = wordprocessingDocument };
        }

        /// <summary>
        /// Rechercher les parametres du docx (main document + headers + footers)
        /// </summary>
        public void RetrieveFieldsParameters()
        {
            FieldsParameters = new List<FieldParameter>();
            //MainDoc.RetrieveFieldsParameters();
            FieldsParameters.AddRange(MainDoc.FieldsParameters);
            foreach (var h in Headers)
            {
                //h.RetrieveFieldsParameters();
                FieldsParameters.AddRange(h.FieldsParameters);
            }

            foreach (var f in Footers)
            {
                //f.RetrieveFieldsParameters();
                FieldsParameters.AddRange(f.FieldsParameters);
            }
        }        

        /// <summary>
        /// Sauvegarder le document docx
        /// </summary>
        internal void Save()
        {
            WordprocessingDocument.MainDocumentPart.SaveXDocument();
            foreach (var h in WordprocessingDocument.MainDocumentPart.HeaderParts)
            {
                h.SaveXDocument();
            }

            foreach (var f in WordprocessingDocument.MainDocumentPart.FooterParts)
            {
                f.SaveXDocument();
            }
        }

        /// <summary>
        /// Fermer le document
        /// </summary>
        internal void Close()
        {
            m_WordprocessingDocument.Close();
        }

        /// <summary>
        /// Traiter le document docx, remplacer les champs de fusion par leurs valeurs présentes dans le jeu de données
        /// </summary>
        public void Fill()
        {
            //DataSet = dataSet;

            MainDoc.Fill();
            foreach (var h in Headers)
            {
                h.Fill();
            }

            foreach (var f in Footers)
            {
                f.Fill();
            }

        }

        #endregion

    }
}
