using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSClient
{
    public partial class frmMDIBackGround : Form
    {
        public frmMDIBackGround()
        {
            InitializeComponent();
        }

        string _signaturePath = "";
        public string SignaturePath
        {
            get { return _signaturePath; }
            set
            {
                _signaturePath = value;
            }
        }

        private void frmMDIBackGround_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Drawing2D.LinearGradientBrush lb = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.CadetBlue, Color.WhiteSmoke, 180);
            //e.Graphics.FillRectangle(lb, this.ClientRectangle);
        }

        private void frmMDIBackGround_Load(object sender, EventArgs e)
        {
            frmMain frmNew = new frmMain();            
        }

        private void frmMDIBackGround_Resize(object sender, EventArgs e)
        {
            this.picLogo.Left = this.Right - this.picLogo.Width;
            this.picLogo.Top = this.Bottom - this.picLogo.Height - 20;
        }

    }
}