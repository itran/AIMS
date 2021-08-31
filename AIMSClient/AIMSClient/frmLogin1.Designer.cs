namespace AIMSClient
{
    partial class frmLogin1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin1));
            this.gpbxLogon = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpbxVersion = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPassword = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.gpbxLogon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbxLogon
            // 
            this.gpbxLogon.BackColor = System.Drawing.Color.Transparent;
            this.gpbxLogon.Controls.Add(this.btnExit);
            this.gpbxLogon.Controls.Add(this.txtPassword);
            this.gpbxLogon.Controls.Add(this.txtName);
            this.gpbxLogon.Controls.Add(this.btnCancel);
            this.gpbxLogon.Controls.Add(this.gpbxVersion);
            this.gpbxLogon.Controls.Add(this.btnOK);
            this.gpbxLogon.Controls.Add(this.lblPassword);
            this.gpbxLogon.Controls.Add(this.lblName);
            this.gpbxLogon.Location = new System.Drawing.Point(105, 138);
            this.gpbxLogon.Name = "gpbxLogon";
            this.gpbxLogon.Size = new System.Drawing.Size(331, 120);
            this.gpbxLogon.TabIndex = 10;
            this.gpbxLogon.TabStop = false;
            this.gpbxLogon.Text = "Please enter your username and password";
            // 
            // btnExit
            // 
            this.btnExit.Image = global::AIMSClient.Properties.Resources.psClose;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(219, 83);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 28);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 57);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(229, 20);
            this.txtPassword.TabIndex = 22;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(229, 20);
            this.txtName.TabIndex = 21;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(219, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(1, 1);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // gpbxVersion
            // 
            this.gpbxVersion.BackColor = System.Drawing.Color.Transparent;
            this.gpbxVersion.Location = new System.Drawing.Point(24, 181);
            this.gpbxVersion.Name = "gpbxVersion";
            this.gpbxVersion.Size = new System.Drawing.Size(280, 64);
            this.gpbxVersion.TabIndex = 19;
            this.gpbxVersion.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(75, 83);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 28);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(16, 64);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 15;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblName.Location = new System.Drawing.Point(14, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 13);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Username";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPassword
            // 
            this.btnPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnPassword.Enabled = false;
            this.btnPassword.Location = new System.Drawing.Point(294, 389);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(78, 24);
            this.btnPassword.TabIndex = 14;
            this.btnPassword.Text = "Password";
            this.btnPassword.UseVisualStyleBackColor = false;
            this.btnPassword.Visible = false;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::AIMSClient.Properties.Resources.AIMS;
            this.picLogo.Location = new System.Drawing.Point(92, 37);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(369, 74);
            this.picLogo.TabIndex = 11;
            this.picLogo.TabStop = false;
            this.picLogo.Visible = false;
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(549, 311);
            this.Name = "frmLogin";
            this.gpbxLogon.ResumeLayout(false);
            this.gpbxLogon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gpbxLogon;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.GroupBox gpbxVersion;
        internal System.Windows.Forms.Button btnPassword;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnExit;
    }
}