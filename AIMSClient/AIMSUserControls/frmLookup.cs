using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIMSUserControls
{
    public partial class frmLookup : Form
    {
        private string _formCaption;
        
        public frmLookup()
        {
            InitializeComponent();
        }

        private void frmLookup_Load(object sender, EventArgs e)
        {
            this.Text = FormCaption;
        }

            #region Public Properties

            public string FormCaption
            {
                get
                {
                    return _formCaption;
                }
                set
                {
                    if (value != _formCaption)
                    {
                        _formCaption = value;
                    }
                }

            }
            #endregion

        }

        }

