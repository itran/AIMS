using System;
using System.Collections.Generic;
using System.Text;
using AIMS.Common;
using AIMS.DAL;
using System.Data;

namespace AIMS.BLL
{
    public class User : BaseObject
    {
        #region "Private Declarations"
        private string _userName  ="";
        private string _userFullName = "";
        private string _userPassword = "";
        private string _userEmailAddress = "";
        private string _userPhone = "";
        private string _userFax = "";
        private string _userActiveYN = "";
        private string _domainAuthYN = "";
        #endregion

        #region "Public Declarations"
        public string UserName
        {
            get   { return _userName; }
            set   { _userName = value; }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public string UserFullName
        {
            get { return _userFullName; }
            set { _userFullName = value; }
        }

        public string UserEmailAddress
        {
            get { return _userEmailAddress; }
            set { _userEmailAddress = value; }
        }

        public string UserPhone
        {
            get { return _userPhone; }
            set { _userPhone = value; }
        }

        public string UserFax
        {
            get { return _userFax; }
            set { _userFax = value; }
        }

        public string UserActiveYN
        {
            get { return _userActiveYN; }
            set { _userActiveYN = value; }
        }

        public string DomainAuthYN
        {
            get { return _domainAuthYN; }
            set { _domainAuthYN = value; }
        }

        string _passwordWordSetupYN = "";
        public string PasswordWordSetupYN
        {
            get { return _passwordWordSetupYN; }
            set { _passwordWordSetupYN = value; }
        }

        string _signaturePath = "";
        public string SignaturePath
        {
            get { return _signaturePath; }
            set { _signaturePath = value; }
        }

        string _passwordWordHint = "";
        public string PasswordWordHint
        {
            get { return _passwordWordHint; }
            set { _passwordWordHint = value; }
        }

        string _passwordHintAnswer = "";
        public string PasswordWordHintAnswer
        {
            get { return _passwordHintAnswer; }
            set { _passwordHintAnswer = value; }
        }
        #endregion

        #region "Public Functions"

        public DataTable GetLoginDetails(string userName, string passWord)
        {
            DataTable tbl = new DataTable();
            return tbl;
        }

        public User GetUserDetails(string UserName)
        {
            User oUser = new User();
            DataSet ds = new DataSet();
            UserDAL userDAL = new UserDAL();

            ds = userDAL.GetUserDetails(UserName);  
            if (!oUser.MapData(ds)) oUser = null;
            return oUser;
        }

        public override bool MapData(DataRow row)
        {
            UserName = GetString(row, "User_Name");
            UserEmailAddress = GetString(row, "User_Email");
            UserFax = GetString(row, "User_Fax");
            UserPassword  = GetString(row, "User_Password");
            UserFullName  = GetString(row, "User_Full_Name");
            UserPhone  =  GetString(row, "User_Phone");
            UserActiveYN = GetString(row, "User_Active_YN");
            DomainAuthYN = GetString(row, "DOMAIN_AUTH_YN");

            PasswordWordHint = GetString(row, "PASSWORD_HINT");
            PasswordWordHintAnswer = GetString(row, "PASSWORD_HINT_ANSWER");
            PasswordWordSetupYN = GetString(row, "PASSWORD_SETUP");

            SignaturePath = GetString(row, "SIGNATURE_PATH");
            return base.MapData(row);
        }

        public DataTable GetUserRestrictions(string UserName) 
        {
            DataTable dtUserRestrictions = new DataTable();
            UserDAL userDAL = new UserDAL();
            dtUserRestrictions = userDAL.GetUserRestrictions(UserName);
            return dtUserRestrictions;
        }

        public DataTable GetUserMenuAccess(string UserName)
        {
            DataTable dtUserRestrictions = new DataTable();
            UserDAL userDAL = new UserDAL();
            dtUserRestrictions = userDAL.GetUserMenuAccess(UserName);
            return dtUserRestrictions;
        }

        public DataTable GetAllRestrictions(string UserName)
        {
            DataTable dtUserRestrictions = new DataTable();
            UserDAL userDAL = new UserDAL();
            dtUserRestrictions = userDAL.GetAllRestrictions(UserName);
            return dtUserRestrictions;
        }

        public bool SaveUserPassword(string userName, string Password, string PasswordHint, string PasswordHintAnswer)
        {
            User  oUser = new User();
            UserDAL UserDAL = new UserDAL();
            bool bSaved = false;
            bSaved = UserDAL.SaveUserPassword(userName, Password, PasswordHint, PasswordHintAnswer);
            
            UserDAL = null;
            return bSaved;
        }

        #endregion
    }
}
