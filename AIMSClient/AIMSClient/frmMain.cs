using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using AIMS.Common;
using AIMS.DAL;

namespace AIMSClient
{
    public partial class frmMain : Form
    {
        frmMain frmMDI;
        frmPatients frmPat;
        frmGuarantors frmGuarant;
        frmSuppliers frmSup;
        frmInvoices frmInv;
        frmReports frmRep;
        frmPayment frmPay;
        frmLogin frmStart;
        //frmAIMSDashboard frmDash;
        frmOPSDashboard frmDash;
        //frmAIMSDashboardAdmin frmDashAdmin;
        frmAdministrationDashboard frmDashAdmin;
        frmWorkbasket frmWorkbasket;
        frmWorkBasketAdmin frmWorkbasketAdmin;
        frmIncidents frmIncident;
        Calender frmcalender;
        string _userName = string.Empty;
        string _userEmailAddress = string.Empty;
        string _userID = string.Empty;
        string _signaturePath = string.Empty;
        string _restrictions = string.Empty;
        
        bool _enableToolBar = false;

        AIMS.Client.CommonFuncs CommonFuncs = new AIMS.Client.CommonFuncs();
        
        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                stbMDI.Panels[0].Text = _userName;
            }
        }

        public string UserEmailAddress
        {
            get { return _userEmailAddress; }
            set
            {
                _userEmailAddress = value;                
            }
        }

        public string SignaturePath
        {
            get { return _signaturePath; }
            set
            {
                _signaturePath = value;
            }
        }

        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                lblLoggedOnUser.Text = _userID;
            }
        }

        public string Restrictions
        {
            get { return _restrictions; }
            set
            {
                _restrictions = value;                
            }
        }
        
        public bool EnableToolBar
        {
            get { return _enableToolBar; }
            set
            {
                _enableToolBar = value;
                tbarMain.Enabled = _enableToolBar;
            }
        }

        bool _viewPatientFiles = false;        
        public bool ViewPatientFiles
        {
            get { return _viewPatientFiles; }
            set
            {
                _viewPatientFiles = value;
                tbarMain.Buttons[0].Enabled = _viewPatientFiles;                
            }
        }

        bool _viewInvoices = false;
        public bool ViewInvoices
        {
            get { return _viewInvoices; }
            set
            {
                _viewInvoices = value;
                tbarMain.Buttons[1].Enabled = _viewInvoices;                
            }
        }

        bool _viewPayments = false;
        public bool ViewPayments
        {
            get { return _viewPayments; }
            set
            {
                _viewPayments = value;
                tbarMain.Buttons[2].Enabled = _viewPayments;
            }
        }

        bool _viewReports = false;
        public bool ViewReports
        {
            get { return _viewReports; }
            set
            {
                _viewReports = value;
                tbarMain.Buttons[3].Enabled = _viewReports;
            }
        }

        bool _viewGuarantors = false;
        public bool ViewGuarantors
        {
            get { return _viewGuarantors; }
            set
            {
                _viewGuarantors = value;
                tbarMain.Buttons[5].Enabled = _viewGuarantors;
            }
        }

        bool _viewSuppliers = false;
        public bool ViewSuppliers
        {
            get { return _viewSuppliers; }
            set
            {
                _viewSuppliers = value;
                tbarMain.Buttons[6].Enabled = _viewSuppliers;                
            }
        }

        bool _viewUserMaintenance = false;
        public bool ViewUserMaintenance
        {
            get { return _viewUserMaintenance; }
            set
            {
                _viewUserMaintenance = value;
                tbarMain.Buttons[7].Enabled = _viewUserMaintenance;
            }
        }

        bool _viewDashboard = false;
        public bool ViewDashboard
        {
            get { return _viewDashboard; }
            set
            {
                _viewDashboard = value;
                tbarMain.Buttons[9].Enabled = _viewDashboard;
            }
        }

        bool _viewCalender = false;
        public bool ViewCalender
        {
            get { return _viewCalender; }
            set
            {
                _viewCalender = value;
                //tbarMain.Buttons[13].Enabled = _viewDashboard;
            }
        }

        public frmMain()
        {
            InitializeComponent();
            //create an object of class Rectangle   (rect)
            Rectangle rect = new Rectangle();
            //rect get data from the function returning the working area of the screen
            rect = Screen.GetWorkingArea(this);
            //place our form at left
            this.Left = 0;
            //place our form at top
            this.Top = 0;
            //set the size (width and height) of our form as the size of the screen
            //working area
            this.Size = new Size(Convert.ToInt32(rect.Width), Convert.ToInt32(rect.Height));
        }

        void ShowOtherBaskets()
        {
 
        }

        public void Dashboard_Click(Object sender, EventArgs e)
        {
            string MenuClickText = ((MenuItem)(sender)).Text;

            switch (MenuClickText)
            {
                case "Operation Dashboard":
                    //if (UserAllowed("94"))
                    //{
                        if (frmDash == null)
                        {
                            //frmDash = new frmAIMSDashboard();
                            frmDash = new frmOPSDashboard();
                            SetMdiStatusbar("Loading Operations Dashboard....");
                            frmDash.UserName = this.stbMDI.Panels[0].Text;
                            frmDash.UserID = this.lblLoggedOnUser.Text;
                            frmDash.Restrictions = this.Restrictions;
                            DisplayChildForm(frmDash, false);
                        }
                        else
                        {
                            DisplayChildForm(frmDash, true);
                        }
                    //}
                    //else
                    //{
                    //     CommonFuncs.DisplayMessage("Not allowed to view Operations Dashboard", CommonTypes.MessagType.Warning);
                    //}
                    break;
                case "Administration Dashboard":
                    //if (UserAllowed("95"))
                    //{
                        if (frmDashAdmin == null)
                        {
                            frmDashAdmin = new frmAdministrationDashboard();
                            SetMdiStatusbar("Loading Admin Dashboard....");
                            frmDashAdmin.UserName = this.stbMDI.Panels[0].Text;
                            frmDashAdmin.UserID = this.lblLoggedOnUser.Text;
                            frmDashAdmin.Restrictions = this.Restrictions;
                            DisplayChildForm(frmDashAdmin, false);
                        }
                        else
                        {
                            DisplayChildForm(frmDashAdmin, true);
                        }
                    //}
                    //else
                    //{
                    //    CommonFuncs.DisplayMessage("Not allowed to view Admin Dashboard", CommonTypes.MessagType.Warning);
                    //}
                    break;
            }
        }

        public void menuItem1_Click(Object sender, EventArgs  e)
        {
            string MenuClickText = ((MenuItem)(sender)).Text;

            switch (MenuClickText)
            {
                case  "Operations Workbasket":
                    if (UserAllowed("94"))
                    {
                        if (frmWorkbasket == null)
                        {
                            frmWorkbasket = new frmWorkbasket();
                            SetMdiStatusbar("Loading Operations Work-Basket....");
                            frmWorkbasket.UserName = this.stbMDI.Panels[0].Text;
                            frmWorkbasket.UserID = this.lblLoggedOnUser.Text;
                            frmWorkbasket.Restrictions = this.Restrictions;
                            DisplayChildForm(frmWorkbasket, false);
                        }
                        else
                        {
                            DisplayChildForm(frmWorkbasket, true);
                        }	 
                    }else
	                {
                        CommonFuncs.DisplayMessage("Not allowed to view Operations Workbasket",CommonTypes.MessagType.Warning);  
	                }
                    break;
                break;
                case "Administration Workbasket":
                    if (UserAllowed("95"))
                    {
                        if (frmWorkbasketAdmin == null)
                        {
                            frmWorkbasketAdmin = new frmWorkBasketAdmin();
                            SetMdiStatusbar("Loading Operations Work-Basket....");
                            frmWorkbasketAdmin.UserName = this.stbMDI.Panels[0].Text;
                            frmWorkbasketAdmin.UserID = this.lblLoggedOnUser.Text;
                            frmWorkbasketAdmin.Restrictions = this.Restrictions;
                            DisplayChildForm(frmWorkbasketAdmin, false);
                        }
                        else
                        {
                            DisplayChildForm(frmWorkbasketAdmin, true);
                        }
                    }
                    else
                    {
                        CommonFuncs.DisplayMessage("Not allowed to view Admin Workbasket", CommonTypes.MessagType.Warning);  
                    }
                    break;
                break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                MenuItem menuItem1 = new MenuItem("Operations Workbasket");
                menuItem1.Click += menuItem1_Click;
                
                MenuItem menuItem2 = new MenuItem("Administration Workbasket");
                menuItem2.Click += menuItem1_Click;

                MenuItem OpsDash = new MenuItem("Operation Dashboard");
                OpsDash.Click += Dashboard_Click;

                MenuItem AdminDash = new MenuItem("Administration Dashboard");
                AdminDash.Click += Dashboard_Click;

                ContextMenu contextMenu1 = new ContextMenu(new MenuItem[] { menuItem1, menuItem2 });
                ContextMenu contextMenu2 = new ContextMenu(new MenuItem[] { OpsDash, AdminDash });

                tbarMain.Buttons["tbtnWorkBasket"].DropDownMenu = contextMenu1;
                tbarMain.Buttons["toolBarButton4"].DropDownMenu = contextMenu2;
                
                

                
                //Disable  access to the program
                //tbarMain.Enabled = false;

               //BM Avoid opening multiple instances of the program
               object obj =  PriorProcess();
               
               if (obj == null )
               {
                   SetupScreen();
                   lblLoggedOnUser.Text = UserName;
                   tbarMain.Buttons[0].Enabled = ViewPatientFiles;
                   tbarMain.Buttons[1].Enabled = ViewInvoices;
                   tbarMain.Buttons[2].Enabled = ViewPayments;
                   tbarMain.Buttons[3].Enabled = ViewReports;
                   tbarMain.Buttons[4].Enabled = ViewGuarantors;
                   tbarMain.Buttons[5].Enabled = ViewSuppliers;
                   tbarMain.Buttons[7].Enabled = ViewUserMaintenance;
                   tbarMain.Buttons[9].Enabled = ViewDashboard;
                   
                   //tbarMain.Buttons[13].Enabled = ViewCalender;
               }
               else
               {
                   CommonFuncs.DisplayMessage("AIMS Recorder is running.",AIMS.Common.CommonTypes.MessagType.Warning );
                   Application.ExitThread();
               }
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage("AIMS Recorder could not load. Please contact system administrator.", AIMS.Common.CommonTypes.MessagType.Error);
                CommonFuncs.ErrorLogger("Loading AIMS Recorder Error - " + ex.ToString());
            }
        }

        #region Private Methods

        private void SetupScreen()
        {
            try
            {
                frmMDI = this;
                frmMDI.Height = this.ClientSize.Height;
                this.menuStrip1.Visible = false;

                //create an object of class Rectangle   (rect)
                Rectangle rect = new Rectangle();
                //rect get data from the function returning the working area of the screen
                rect = Screen.GetWorkingArea(this);
                //place our form at left
                this.Left = 0;
                //place our form at top
                this.Top = 0;
                //set the size (width and height) of our form as the size of the screen
                //working area
                this.Size = new Size(Convert.ToInt32(rect.Width), Convert.ToInt32(rect.Height));

                //Disable the menu bar
                //this.tbarMain.Visible = false;

                frmStart = new frmLogin(frmMDI);
                frmStart.MdiParent = this;
                frmStart.Height = this.ClientSize.Height - 10000;
                frmStart.Width = this.ClientSize.Width;
                frmStart.Dock = DockStyle.Fill;
                 
                frmStart.Show();
                

                this.stbMDI.Panels[0].Text = CommonFuncs.CurrentUserLoggedUser;
                this.stbMDI.Panels[2].Text = DateTime.Now.ToShortDateString();
                this.stbMDI.Panels[1].Text = "i-Tran Software Solutions (Pty) Ltd.";
            }
            catch (System.Exception ex)
            {
                CommonFuncs.DisplayMessage("AIMS Recorder screen setup failed. Please contact system administrator.", AIMS.Common.CommonTypes.MessagType.Error);               
                CommonFuncs.ErrorLogger("Loading AIMS Recorder Setup Screen Method Failed - " + ex.ToString());
                //throw;
            }

            
                       
        }

        #endregion

        #region ToolBar Events

        private void tbarMain_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                switch (e.Button.Text.ToUpper())
                {
                    case "PATIENTS":
                        if (frmPat == null)
                        {
                            frmPat = new frmPatients();
                            SetMdiStatusbar("Loading Patient List....");
                            frmPat.UserName = this.stbMDI.Panels[0].Text;
                            frmPat.UserID = this.lblLoggedOnUser.Text;
                            frmPat.Restrictions = this.Restrictions;
                            frmPat.UserEmailAddress = UserEmailAddress;
                            frmPat.SignaturePath = this.SignaturePath;
                            DisplayChildForm(frmPat, false);                        
                        }
                        else
                        {
                            DisplayChildForm(frmPat, true);
                        }
                        break;

                    case "GUARANTORS":

                        if (frmGuarant == null)
                        {
                            frmGuarant = new frmGuarantors();
                            SetMdiStatusbar("Loading Guarantors....");
                            frmGuarant.UserName = this.stbMDI.Panels[0].Text;
                            frmGuarant.UserID = this.lblLoggedOnUser.Text;
                            frmGuarant.Restrictions = this.Restrictions;
                            DisplayChildForm(frmGuarant, false);
                        }
                        else
                        {
                            DisplayChildForm(frmGuarant, true);
                        }
                        break;

                    case "SUPPLIERS":
                        if (frmSup == null)
                        {
                            frmSup = new frmSuppliers();
                            SetMdiStatusbar("Loading Suppliers....");
                            frmSup.UserName = this.stbMDI.Panels[0].Text;
                            frmSup.UserID = this.lblLoggedOnUser.Text;
                            frmSup.Restrictions = this.Restrictions;
                            DisplayChildForm(frmSup, false);
                        }
                        else
                        {
                            DisplayChildForm(frmSup, true);
                        }

                        break;

                    case "INVOICES":
                        if (frmInv == null)
                        {
                            frmInv = new frmInvoices();
                            SetMdiStatusbar("Loading Invoices....");
                            frmInv.UserName = this.stbMDI.Panels[0].Text;
                            frmInv.UserID  = this.lblLoggedOnUser.Text;
                            frmInv.Restrictions = this.Restrictions;
                            DisplayChildForm(frmInv, false);
                        }
                        else
                        {
                            DisplayChildForm(frmInv, true);
                        }

                        break;

                    case "REPORTS":
                        if (frmRep == null)
                        {
                            frmRep = new frmReports();
                            SetMdiStatusbar("Loading Reports....");
                            DisplayChildForm(frmRep, false);
                        }
                        else
                        {
                            DisplayChildForm(frmRep, true);
                        }
                        break;
                    case "PAYMENTS":
                        if (frmPay == null)
                        {
                            frmPay = new frmPayment();
                            SetMdiStatusbar("Loading Payment List....");
                            frmPay.UserName = this.stbMDI.Panels[0].Text;
                            frmPay.UserID = this.lblLoggedOnUser.Text;
                            frmPay.Restrictions = this.Restrictions;
                            DisplayChildForm(frmPay, false);
                        }
                        else
                        {
                            DisplayChildForm(frmPay, true);
                        }
                        break;
                    case "DASHBOARD":
                        //if (frmDash == null)
                        //{
                        //    frmDash = new frmAIMSDashboard();
                        //    SetMdiStatusbar("Loading AIMS Dashboard....");
                        //    frmDash.UserName = this.stbMDI.Panels[0].Text;
                        //    frmDash.UserID = this.lblLoggedOnUser.Text;
                        //    frmDash.Restrictions = this.Restrictions;
                        //    DisplayChildForm(frmDash, false);
                        //}
                        //else
                        //{
                        //    DisplayChildForm(frmDash, true);
                        //}
                        break;
                    case "WORKBASKET":
                        break;
                    case "MAIL":
                        if (frmIncident == null)
                        {
                            frmIncident = new frmIncidents();
                            SetMdiStatusbar("Loading AIMS Email Incidents Logged....");
                            frmIncident.UserName = this.stbMDI.Panels[0].Text;
                            frmIncident.UserID = this.lblLoggedOnUser.Text;
                            frmIncident.Restrictions = this.Restrictions;
                            DisplayChildForm(frmIncident, false);
                        }
                        else
                        {
                            DisplayChildForm(frmIncident, true);
                        }
                        break;
                    case "CALENDER":
                        if (frmcalender == null)
                        {
                            frmcalender = new Calender();
                            SetMdiStatusbar("Loading AIMS GLOBAL Calender....");
                            frmcalender.UserName = this.stbMDI.Panels[0].Text;
                            frmcalender.UserID = this.lblLoggedOnUser.Text;
                            frmcalender.Restrictions = this.Restrictions;
                            DisplayChildForm(frmcalender, false);
                        }
                        else
                        {
                            DisplayChildForm(frmcalender, true);
                        }
                        break;
                    case "EXIT":
                        if (MessageBox.Show("Closing AIMS Recorder, Do you want to continue ?","Closing. . .",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes )
                        {
                            Application.ExitThread();
                        }
                        break;
                    case "BASKETS":
                        BasketMenuStrip.Show(this.tbarMain, new System.Drawing.Point(0, 22));
                        break;
                }
                this.stbMDI.Panels[1].Text = "i-Tran Software Solutions (Pty) Ltd.";
            }
            catch (System.Exception ex)
            {
                CommonFuncs.ErrorLogger("Loading Form Error: \n" + ex.ToString());
            }
        }

        #endregion

        #region Helper Methods

        public void SetMdiStatusbar(string statusMsg)
        {

            this.stbMDI.Panels[1].Text = statusMsg;
        }

        public void ToolBarEnable()
        {
            this.tbarMain.Enabled = true;
        }

        public void DisplayChildForm(Form frm, bool setFocus)
        {
            if (!setFocus)
            {
                if (frm != null)
                {
                    frm.MdiParent = this;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Height = Convert.ToInt32(this.ClientSize.Height - 5000);
                    frm.Width = this.ClientSize.Width;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                    SetMdiStatusbar("");
                }
            }
            else
            {
                frm.Focus();
            }


        }

        #endregion

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 0)
            {
                this.stbMDI.Panels[0].Width = Convert.ToInt32(this.ClientSize.Width * 0.25);
                this.stbMDI.Panels[1].Width = Convert.ToInt32(this.ClientSize.Width * 0.5);
                this.stbMDI.Panels[2].Width = Convert.ToInt32(this.ClientSize.Width * 0.25);                
            }            
        }

        private void frmMain_close(object sender, EventArgs e)
        {
            try
            {
                Process Curr = Process.GetCurrentProcess();
                Process[] procs = Process.GetProcessesByName(Curr.ProcessName);
                foreach (Process p in procs)
                {
                    if ((p.Id != Curr.Id) && (p.MainModule.FileName == Curr.MainModule.FileName))
                    {
                        p.Kill();
                    }
                }
            }
            finally 
            {
            }
        }

        public static Process PriorProcess()
        {
            try
            {
                Process Curr = Process.GetCurrentProcess();
                Process[] procs = Process.GetProcessesByName(Curr.ProcessName);
                foreach (Process p in procs)
                {
                    if ((p.Id != Curr.Id ) && (p.MainModule.FileName == Curr.MainModule.FileName))
                    {
                        return p;
                    }    
                }
                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private bool UserAllowed(string RestrictionID)
        {
            bool bAllowedFunction = false;
            if (Restrictions.Trim().Length > 0)
            {
                string[] arrPermissions = Restrictions.Split(new Char[] { ',' });

                foreach (string Permission in arrPermissions)
                {
                    if (Permission.Trim() != "" && Permission == RestrictionID)
                    {
                        bAllowedFunction = true;
                        break;
                    }
                }
            }
            return bAllowedFunction;
        }
   }
}

