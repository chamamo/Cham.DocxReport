using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class UcDateFormatControle : UcStringFormatControle
    {
        #region Constructor

        protected UcDateFormatControle()
        {
            InitializeComponent();
        }

        public UcDateFormatControle(DateFormat format)
            : base(format)
        {
            InitializeComponent();
            DateFormat = format;            
        }

        #endregion

        #region Properties

        private DateFormat DateFormat
        {
            get;
            set;
        }

        protected bool Locked
        {
            get;
            set;
        }

        protected List<string> Formats
        {
            get;
            set;
        }


        #endregion

        #region Methods

        private void InitializeComponentCustom()
        {
            Locked = true;
            BuildFormats();
            int i = 0;
            foreach (string str in Formats)
            {
                lbFormats.Items.Add(DateFormat.Format(str, DateFormat.Sample));
                if (str.Equals(DateFormat.StrFormat))
                {
                    lbFormats.SelectedIndex = i;
                }
                i++;
            }
            Locked = false;
        }

        protected virtual void BuildFormats()
        {
            Formats = new List<string>();
            Formats.Add("dd/MM/yyyy");
            Formats.Add("dd/MM/yyyy HH:mm");
            Formats.Add("dd/MM/yyyy HH:mm:ss");
            Formats.Add("MM/dd/yyyy");
            Formats.Add("MM/dd/yyyy HH:mm");
            Formats.Add("MM/dd/yyyy HH:mm:ss");
            Formats.Add("dd/MM");
            Formats.Add("MM/dd");
            Formats.Add("MM/yyyy");

            Formats.Add("dd MMMM yyyy");
            Formats.Add("dddd dd MMMM yyyy");
            Formats.Add("MMMM yyyy");
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponentCustom();
        }

        private void lbFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locked)
            {
                DateFormat.StrFormat = Formats[lbFormats.SelectedIndex];
                base.InvokeUpdateSample();
            }
        }

        #endregion
    }
}
