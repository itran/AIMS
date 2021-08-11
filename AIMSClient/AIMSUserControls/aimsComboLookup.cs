using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using System.Threading;
using System.Globalization;

namespace AIMSUserControls
{
    public partial class aimsComboLookup : UserControl
    {
        #region GlobalVariables
        private DataTable _tbl;
        private string _field1;
        private string _field2;
        private string _field3;
        private string _tableName;
        private Int32 _itemsLoaded;
        private bool _showButtons;
        private string _field1Caption;
        private string _field2Caption;
        private string _StartItem;
        private aimsComboLookup comboList;
        private AIMS.DAL.ComboLookup _clsDAL;
        private Thread _tCombo;
        private bool _showButton2;
        private string _OrderByField;
        
        //Double Click delegate
        public delegate void DblClickHandler();
        public delegate void RadioBtnChange();
                
                        
        //*************
       
       // private Thread tDataLoad;
        
        
        #endregion

        #region Constructors
        
        public aimsComboLookup()
        {
            InitializeComponent();
        }

     
        #endregion

        #region Properties

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

        public string DataField1
        {
            get
            {
                return _field1;
            }
            set
            {
                if (value != _field1)
                {
                    _field1 = value;
                }
            }
        }

        public string DataField2
        {
            get
            {
                return _field2;
            }
            set
            {
                if (value != _field2)
                {
                    _field2 = value;
                }
            }
        }

        public string DataField3
        {
            get
            {
                return _field3;
            }
            set
            {
                if (value != _field3)
                {
                    _field3 = value;
                }
            }
        }

        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                if (value != _tableName)
                {
                    _tableName = value;
                }
            }
        }

        public Int32 ItemsLoaded
        {
            get
            {
                return _itemsLoaded;
            }
            set
            {
                if (value != _itemsLoaded)
                {
                    _itemsLoaded = value;
                }
            }
        }

        public bool ShowButtons
        {
            get
            {
                return _showButtons;
            }
            set
            {
                
                    _showButtons = value;
                    this.radCode.Visible = value;
                    this.radDescription.Visible = value;
                           
            }
        }

        public string Field1Value
        {
            get
            {
                return _field1Caption;
            }
            set
            {
                if (value != _field1Caption)
                {
                    _field1Caption = value;
                    radDescription.Text = _field1Caption;
                }
            }
        }
        
        public string Field2Value
        {
            get
            {
                return _field2Caption;
            }
            set
            {
                if (value != _field2Caption)
                {
                    _field2Caption = value;
                    radCode.Text = value;
                }
            }
        }

        public bool ShowButtonTwo
        {
            get
            {
                return _showButton2;
            }
            set
            {

                _showButton2 = value;
                this.radCode.Visible = value;
                
            }
        }
        
        public string OrderByField
        {
            get { return _OrderByField; }
            set { _OrderByField = value; }
        }
        #endregion

        #region "Public Events"

        public void Clear()
        {
            lstItems.Items.Clear();
        }

        public void CheckDescription()
        {
            radDescription.Checked = true;
            txtSearch.Text = "";
        }

        /// <summary>
        /// This event fires the double click event when the listbox is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lstItems_DoubleClick(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex != -1)
            {
                OnDblClicked();
            }

        }

        public event DblClickHandler DblClicked;
        public event RadioBtnChange BtnChange;

        protected virtual void OnDblClicked()
        {
            if (DblClicked != null)
            {
                //Todo Add code to remove the Textbox Textchanged event.
                //txtSearch.Text = lstItems.SelectedItem.ToString();
                DblClicked(); //Notify Subscribers
            }
        }

        protected virtual void OnRadioBtnChange()
        {
            if (BtnChange != null)
            {
                BtnChange();
            }
        }
        #endregion
   
        #region Control Events

        private void aimsComboLookup_Resize(object sender, EventArgs e)
        {
            //this.pnlCombo.Width = Convert.ToInt32(this.ClientSize.Width * 99);
            this.pnlCombo.Width = this.ClientSize.Width - 10;
            this.pnlCombo.Height = this.ClientSize.Height - 10;
            //this.lstItems.Width = Convert.ToInt32(this.pnlCombo.Width * 97);
            this.lstItems.Width = this.pnlCombo.Width - 10;
            this.lstItems.Top = txtSearch.Bottom + 2;
            //this.lstItems.Height = this.pnlCombo.Bottom - 10;
            //this.txtSearch.Width = Convert.ToInt32(this.pnlCombo.Width * 97);
            this.txtSearch.Width = this.pnlCombo.Width - 10;
            if (ShowButtons == true)
            {
                txtSearch.Top = 17 + 5;
                //txtSearch.Top = radCode.Height + 5;                
            }
            else
            {
                txtSearch.Top = 0;
            }
        }            
        #endregion

        #region Helper Methods

        public void Initialise(string startItem)
        {
            try
            {                  
                _tbl = new DataTable();
                _clsDAL = new AIMS.DAL.ComboLookup();

                switch (OrderByField)
                {
                    case "PATIENT_NAME":
                        _tbl = _clsDAL.GetComboValues(DataField1, DataField2, TableName, ItemsLoaded, "PATIENT_NAME");
                        break;
                    case "INVOICE_NO":
                        _tbl = _clsDAL.GetComboValues(DataField1, DataField2, TableName, ItemsLoaded, "INVOICE_NO");
                        break;
                    case "RECEIPT_NO":
                        _tbl = _clsDAL.GetComboValues(DataField1, DataField2, TableName, ItemsLoaded, "RECEIPT_NO");
                        break;
                    case "GUARANTOR_NAME":
                        _tbl = _clsDAL.GetComboValues(DataField1, DataField2, TableName, ItemsLoaded, "GUARANTOR_NAME");
                        break;
                    case "SUPPLIER_NAME":
                        _tbl = _clsDAL.GetComboValues(DataField1, DataField2, TableName, ItemsLoaded, "SUPPLIER_NAME");
                        break;
                    case "GUARANTOR_REF_NO":
                        _tbl = _clsDAL.GetComboValues(DataField1, DataField2, TableName, ItemsLoaded, "GUARANTOR_REF_NO");
                        break;
                }
                
                lstItems.ValueMember = DataField2;
                lstItems.DisplayMember = DataField1;
                lstItems.DataSource = _tbl;
                lstItems.SelectedIndex = -1;
                lstItems.ScrollAlwaysVisible = true;
                lstItems.Sorted = true;
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void LoadCombo()
        {
           
        }
        
        #endregion

        #region Control Events
        
        private void radCode_CheckedChanged(object sender, EventArgs e)
        {
            string tempField2 = DataField2;
            DataField2 = DataField1;
            DataField1 = tempField2;
            Initialise("");
            txtSearch.Clear();
            txtSearch.Focus();
            //BtnChange();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CompareInfo ComboInfo = CultureInfo.InvariantCulture.CompareInfo;
            if (txtSearch.Text.Length > 0)
            {
                lstItems.SelectedIndex = lstItems.FindString(txtSearch.Text);
            }
            else
            {
                lstItems.SelectedIndex = -1;
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DblClick();
        }

        public void lstItems_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyValue == 13)
            {
                if (lstItems.SelectedIndex != -1)
                {
               
                    OnDblClicked();
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    if ((lstItems.SelectedIndex != -1) && (txtSearch.Text.Length != 0))
            //    {
            //        OnDblClicked();
            //    }
            //}
        }

        #endregion

        private void pnlCombo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aimsComboLookup_Load(object sender, EventArgs e)
        {

        }

        private void radGuarantor_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void radDescription_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
