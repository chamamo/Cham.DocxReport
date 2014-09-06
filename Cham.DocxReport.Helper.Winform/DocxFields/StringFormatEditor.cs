using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class StringFormatEditor : Form
    {

        #region Constructor

        protected StringFormatEditor()
        {
            InitializeComponent();
        }

        public StringFormatEditor(StringFormat stringFormat)
            : this()
        {
            InitializeComponentCustom(stringFormat);
        }

        #endregion

        #region Properties

        public StringFormat StringFormat
        {
            get;
            protected set;
        }

        #endregion

        #region Méthode

        /// <summary>
        /// Initialisation
        /// </summary>
        /// <param name="manager"></param>
        private void InitializeComponentCustom(StringFormat stringFormat)
        {
            StringFormat = stringFormat;
            Text = Resources.Format;
            gbExemple.Text = Resources.Sample;
            gbFormats.Text = Resources.Format;
            gbProprietes.Text = Resources.Properties;
            btnOK.Text = Resources.OK;
            btnCancel.Text = Resources.Cancel;
            Build();
        }

        private void Build()
        {
            lbFormats.Items.Add(new GeneralStringFormat());
            int selectedIndex = 0;

            selectedIndex = 
                StringFormat is BooleanFormat ? 7 :
                StringFormat is TimeFormat ? 6 :
                StringFormat is DateFormat ? 5 :                
                StringFormat is PercentageFormat ? 4 :
                StringFormat is CurrencyFormat ? 3 :
                StringFormat is IntegerFormat ? 2 :
                StringFormat is NumberFormat ? 1 :
                0;

            lbFormats.Items.Add(selectedIndex == 1 ? (NumberFormat)StringFormat.Clone() : new NumberFormat());
            lbFormats.Items.Add(selectedIndex == 2 ? (IntegerFormat)StringFormat.Clone() : new IntegerFormat());
            lbFormats.Items.Add(selectedIndex == 3 ? (CurrencyFormat)StringFormat.Clone() : new CurrencyFormat());
            lbFormats.Items.Add(selectedIndex == 4 ? (PercentageFormat)StringFormat.Clone() : new PercentageFormat());            
            lbFormats.Items.Add(selectedIndex == 5 ? (DateFormat)StringFormat.Clone() : new DateFormat());
            lbFormats.Items.Add(selectedIndex == 6 ? (TimeFormat)StringFormat.Clone() : new TimeFormat());
            lbFormats.Items.Add(selectedIndex == 7 ? (BooleanFormat)StringFormat.Clone() : new BooleanFormat());
            lbFormats.SelectedIndex = selectedIndex;
        }

        #endregion

        #region Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            StringFormat = lbFormats.SelectedItem as StringFormat;
            DialogResult = DialogResult.OK;
        }

        #endregion

        private void lbFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateSample(sender, e);
            StringFormat selectedItem = lbFormats.SelectedItem as StringFormat;
            UcStringFormatControle ucStringFormatControle = this.GetUcStringFormatControle(selectedItem);
            gbProprietes.Controls.Clear();
            if (ucStringFormatControle != null)
            {
                this.gbProprietes.Controls.Add(ucStringFormatControle);
                ucStringFormatControle.Dock = DockStyle.Fill;
                ucStringFormatControle.UpdateSample += new EventHandler(UpdateSample);
            }
        }

        private void UpdateSample(object sender, EventArgs e)
        {
            var selectedItem = this.lbFormats.SelectedItem as Core.StringFormat;
            this.lblExemple.Text = selectedItem.Format(selectedItem.Sample);
        }

        public UcStringFormatControle GetUcStringFormatControle(StringFormat stringFormat)
        {
            if (stringFormat is IntegerFormat)
            {
                return new UcIntegerFormatControle((IntegerFormat)stringFormat);
            }

            else if (stringFormat is PercentageFormat)
            {
                return new UcPercentageFormatControle((PercentageFormat)stringFormat);
            }
            else if (stringFormat is CurrencyFormat)
            {
                return new UcCurrencyFormatControle((CurrencyFormat)stringFormat);
            }
            else if (stringFormat is NumberFormat)
            {
                return new UcNumberFormatControle((NumberFormat)stringFormat);
            }
            else if (stringFormat is BooleanFormat)
            {
                return new UcBooleanFormatControle((BooleanFormat)stringFormat);
            }

            else if (stringFormat is TimeFormat)
            {
                return new UcTimeFormatControle((TimeFormat)stringFormat);
            }

            else if (stringFormat is DateFormat)
            {
                return new UcDateFormatControle((DateFormat)stringFormat);
            }

            else
            {
                return new UcStringFormatControle((GeneralStringFormat)stringFormat);
            }
            //return null;
        }


    }
}
