using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Cham.DocxReport
{
    public class Run
    {
        #region Champs

        private List<Text> m_Texts;

        #endregion

        #region Constructor

        #endregion

        #region Properties

        public XElement RunElement { get; set; }
        public int RunLength { get; set; }
        public int RunLocation { get; set; }

        public List<Text> Texts 
        {
            get
            {
                if(m_Texts==null)
                {
                    BuildTexts();
                }
                return m_Texts;
            }
        }

        public int Index { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Récupérer les balses Text qui sont dans le Run
        /// </summary>
        private void BuildTexts()
        {
            var textElements = RunElement
               .Descendants(W.t);

            int i = 0;
            var texts = textElements
                .Select(t => new Text
                {
                    TextElement = t,
                    TextLength = t.Value.Length,
                    TextLocation = textElements
                    .TakeWhile(a => a != t)
                   .Select(z => z.Value.Length)
                   .Sum() + RunLocation,
                    RunParent = this,
                    Index=i++
                }).ToList();

            m_Texts = texts;
        }        

        #endregion
    }
}
