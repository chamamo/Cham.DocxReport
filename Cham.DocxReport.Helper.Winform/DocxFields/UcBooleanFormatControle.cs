using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cham.DocxReport.Helper.Core;
using Cham.DocxReport.Helper.Core.Properties;

namespace Cham.DocxReport.Helper.Winform.DocxFields
{
    internal partial class UcBooleanFormatControle : UcStringFormatControle
    {
        #region Constructor

        protected UcBooleanFormatControle()
        {
            InitializeComponent();
        }

        public UcBooleanFormatControle(BooleanFormat format)
            : base(format)
        {
            InitializeComponent();
            BooleanFormat = format;            
        }

        #endregion

        #region Properties

        private BooleanFormat BooleanFormat
        {
            get;
            set;
        }

        private bool Locked
        {
            get;
            set;
        }

        #endregion

        #region Methods

        private void InitializeComponentCustom()
        {
            Locked = true;
            gbFalse.Text = Resources.No;
            gbTrue.Text = Resources.Yes;


            cbFalseDisplay.Items.Add(Resources.False);
            cbFalseDisplay.Items.Add(Resources.No);

            cbTrueDisplay.Items.Add(Resources.True);
            cbTrueDisplay.Items.Add(Resources.Yes);

            cbFalseDisplay.Text = BooleanFormat.FalseDisplay;
            cbTrueDisplay.Text = BooleanFormat.TrueDisplay;
            Locked = false;

            lblFalseDisplay.Text = Resources.Viewing;
            lblTrueDisplay.Text = Resources.Viewing;

        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponentCustom();
        }

        private void cbFalseValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Locked)
            {
                BooleanFormat.FalseDisplay = this.cbFalseDisplay.Text;
                BooleanFormat.TrueDisplay = this.cbTrueDisplay.Text;
                base.InvokeUpdateSample();
            }
        }

        #endregion
    }
}
