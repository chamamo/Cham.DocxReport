using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data;
using DocumentFormat.OpenXml;

namespace Cham.DocxReport
{
    /// <summary>
    /// Classe représente un paragraphe dans le document word
    /// </summary>
    internal class Paragraph
    {
        #region Champs

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="paragraphElement">l'élement XML du paragraphe</param>
        /// <param name="customContainerParent">classe Container parente</param>
        public Paragraph(XElement paragraphElement, Container customContainerParent)
        {
            ParagraphElement = paragraphElement;
            CustomContainerParent = customContainerParent;
            RetrieveFieldsParameters();
            StandardizeFieldsParameters();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définit l'élement XML du paragraph
        /// </summary>
        public XElement ParagraphElement { get; set; }

        /// <summary>
        /// Obtient ou définit le conteneur parent
        /// </summary>
        Container CustomContainerParent
        {
            get;
            set;
        }

        /// <summary>
        /// Obtient ou définit la liste des Runs
        /// </summary>
        public List<Run> Runs
        {
            get;
            private set;
        }

        /// <summary>
        /// Obtient ou définit la liste des champs de fusion
        /// </summary>
        public List<FieldParameter> FieldsParameters
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Construire les Runs
        /// </summary>
        private void BuildRuns()
        {
            var runElements = ParagraphElement

                .Descendants(W.r)

                .Where(e => e.Parent.Name != W.del && e.Parent.Name != W.moveFrom &&

                    e.Descendants().Any());

            int i = 0;
            int location = 0;
            var customRuns = runElements

                .Select(r =>
                {
                    var run = new Run
                    {
                        RunElement = r,

                        RunLength = Fonctions.GetRunLength(r),

                        RunLocation = location,

                        Index = i++

                    };
                    location += run.RunLength;
                    return run;
                }).ToList();

            Runs = customRuns;
        }

        /// <summary>
        /// Récupérer les champs de fusion du paragraph
        /// </summary>
        private void RetrieveFieldsParameters()
        {
            FieldsParameters = new List<FieldParameter>();
            Regex regEx = Fonctions.DocxReportOptions.FieldParameterRegex;
            XElement pElement = new XElement(ParagraphElement);
            List<XElement> elementsToRemove = new List<XElement>();
            foreach (var e in pElement.Descendants(W.drawing))
            {
                elementsToRemove.Add(e);
            }
            foreach (XElement e in elementsToRemove)
            {
                e.Remove();
            }
            MatchCollection matches = regEx.Matches(pElement.Value);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                FieldParameter field = new FieldParameter()
                {
                    FieldLocation = match.Index,
                    ColumnName = match.Groups[DocxReportOptions.ColumnNameField].Value,
                    TableName = match.Groups[DocxReportOptions.TableNameField].Value,
                    Format = match.Groups[DocxReportOptions.FormatField].Value,
                    ParentContainer = CustomContainerParent,
                    Text = match.ToString()
                };

                FieldsParameters.Add(field);
                CustomContainerParent.AddFieldParameters(field, ParagraphElement);
            }
        }

        /// <summary>
        /// Uniformiser les champs de fusion (police, gras, souligné, italique...)
        /// </summary>
        private void StandardizeFieldsParameters()
        {
            BuildRuns();
            foreach (FieldParameter field in FieldsParameters)
            {
                var runStard = GetRun(field.FieldLocation);
                var runEnd = GetRun(field.FieldLocation + field.Text.Length - 1);
                if (runStard.RunLocation < runEnd.RunLocation)
                {

                    var runsBetween = (
                        from run in Runs
                        where run.RunLocation > runStard.RunLocation && run.RunLocation <= runEnd.RunLocation
                        select run);

                    StringBuilder sb = new StringBuilder();
                    foreach (var run in runsBetween)
                    {
                        sb.Append(Fonctions.GetRunString(run.RunElement));
                        run.RunElement.Remove();
                    }
                    if (sb.Length > 0)
                    {
                        if (runStard.Texts.Count == 0)
                        {
                            runStard.Texts.Add(new Text() { TextElement = new XElement(W.t), RunParent = runStard });
                        }
                        runStard.Texts[runStard.Texts.Count - 1].Append(sb.ToString());
                    }
                    BuildRuns();
                }
            }
        }

        /// <summary>
        /// Obtenir un Run en fonction d'un indexe
        /// </summary>
        /// <param name="location">l'indexe</param>
        /// <returns>Run</returns>
        private Run GetRun(int location)
        {
            return (
                    from run in Runs
                    where run.RunLocation <= location && run.RunLocation + run.RunLength - 1 >= location
                    select run).Single();
        }

        /// <summary>
        /// Obtenir un Text en fonction d'un indexe
        /// </summary>
        /// <param name="run">Run Conteneur</param>
        /// <param name="location">L'indexe</param>
        /// <returns>Text</returns>
        private Text GetText(Run run, int location)
        {
            return (
                    from text in run.Texts
                    where text.TextLocation <= location && text.TextLocation + text.TextLength - 1 >= location
                    select text).Single();
        }

        /// <summary>
        /// Remplacer les champs de fusion par les données
        /// </summary>
        /// <param name="row"></param>
        public void Fill(DataRow row)
        {
            for (int i = 0; i < FieldsParameters.Count; i++)
            {
                FieldParameter field = FieldsParameters[i];
                string newText = field.GetValue(row);
                string[] texts = newText.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
                var concernedRun = GetRun(field.FieldLocation);
                var concernedText = GetText(concernedRun, field.FieldLocation);

                if (texts.Length == 1)
                {
                    int delta = concernedText.Replace(field.Text, newText);
                    for (int j = i + 1; j < FieldsParameters.Count; j++)
                    {
                        FieldsParameters[j].FieldLocation += delta;
                    }
                }
                else if (texts.Length > 1)
                {
                    string textRestant = concernedText.Value.Substring(concernedText.Value.IndexOf(field.Text) + field.Text.Length,
                        concernedText.Value.Length - concernedText.Value.IndexOf(field.Text) - field.Text.Length);
                    concernedText.Replace(field.Text, texts[0]);
                    //Récupérer les propriétés du paragraph
                    var pPrElement = ParagraphElement.Element(W.pPr);
                    //Récupérer les propriétés du Run
                    var rPrElement = concernedRun.RunElement.Element(W.rPr);

                    List<XElement> lines = new List<XElement>();
                    for (int k = 1; k < texts.Length; k++)
                    {
                        //Création d'un nouveau text
                        XElement t = new XElement(W.t, texts[k]);
                        if (k == (texts.Length - 1) && textRestant.Length > 0)
                        {
                            t.Value += textRestant;
                        }
                        //Création d'un nouveau Run en reprenant les propriétés du Run d'origine
                        concernedRun.RunElement.Add(new XElement(W.br));
                        concernedRun.RunElement.Add(t);
                        //Pour tous les fields restant, on rajoute les n saut de ligne à sa position
                        for (int j = i + 1; j < FieldsParameters.Count; j++)
                        {
                            FieldsParameters[j].FieldLocation += texts.Length - 1;
                        }
                    }
                }
                BuildRuns();
            }
        }

        #endregion
    }
}
