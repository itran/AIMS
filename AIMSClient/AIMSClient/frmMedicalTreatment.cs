using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmMedicalTreatment : Form
    {
        string _PatientID;
        UserControls.frmCalendar frmCal;
        AIMS.Client.CommonFuncs clsCommon;

        public frmMedicalTreatment(string patientID)
        {
            InitializeComponent();
            _PatientID = patientID;
        }

        
        private void frmMedicalTreatment_Load(object sender, EventArgs e)
        {
            clsCommon = new AIMS.Client.CommonFuncs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMedicalTreatment_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 180);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);
        }

        private void lnkDateOfTreatment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCal = new UserControls.frmCalendar();
            if (frmCal.ShowDialog() == DialogResult.OK)
            {
                txtTreatmentDate.Text = frmCal.StartDate.ToShortDateString();
            }
            
           
        }
    }
}