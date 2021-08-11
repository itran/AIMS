using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AIMSUserControls
{
    public partial class aimsListView : UserControl
    {
        public aimsListView()
        {
            InitializeComponent();
        }

        #region Global Variables
        private DataTable _tbl;
        private bool _allowEdit;

        #endregion

        #region Public Properties

        public DataTable AIMSDataTbl
        {
            get
            {
                return _tbl;
            }
            set
            {
                if (value != _tbl)
                {
                    _tbl = value;
                }
            }

        }

        /// <summary>
        /// Checks whether the user should have access to edit listview items
        /// </summary>
        public bool AIMSAllowUserEdit
        {
            get
            {
                return _allowEdit;
            }
            set
            {
                if (value != _allowEdit)
                {
                    _allowEdit = value;
                }
            }

        }


        #endregion
    }
}
