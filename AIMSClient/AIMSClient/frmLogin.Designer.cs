namespace AIMSClient
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.gpbxLogon = new System.Windows.Forms.GroupBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkForgotPass = new System.Windows.Forms.LinkLabel();
            this.lnkCreatePass = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpbxVersion = new System.Windows.Forms.GroupBox();
            this.btnPassword = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.gpbxLogon.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbxLogon
            // 
            this.gpbxLogon.BackColor = System.Drawing.Color.Transparent;
            this.gpbxLogon.Controls.Add(this.pnlMain);
            this.gpbxLogon.Controls.Add(this.btnCancel);
            this.gpbxLogon.Controls.Add(this.gpbxVersion);
            this.gpbxLogon.Location = new System.Drawing.Point(29, 92);
            this.gpbxLogon.Name = "gpbxLogon";
            this.gpbxLogon.Size = new System.Drawing.Size(902, 215);
            this.gpbxLogon.TabIndex = 10;
            this.gpbxLogon.TabStop = false;
            this.gpbxLogon.Enter += new System.EventHandler(this.gpbxLogon_Enter);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.lnkForgotPass);
            this.pnlMain.Controls.Add(this.lnkCreatePass);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.txtName);
            this.pnlMain.Controls.Add(this.btnOK);
            this.pnlMain.Controls.Add(this.lblPassword);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Location = new System.Drawing.Point(219, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(414, 191);
            this.pnlMain.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(132, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 26);
            this.label1.TabIndex = 36;
            this.label1.Text = "WELCOME TO AIMS";
            // 
            // lnkForgotPass
            // 
            this.lnkForgotPass.AutoSize = true;
            this.lnkForgotPass.Location = new System.Drawing.Point(266, 112);
            this.lnkForgotPass.Name = "lnkForgotPass";
            this.lnkForgotPass.Size = new System.Drawing.Size(86, 13);
            this.lnkForgotPass.TabIndex = 35;
            this.lnkForgotPass.TabStop = true;
            this.lnkForgotPass.Text = "Forgot Password";
            this.lnkForgotPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPass_LinkClicked);
            // 
            // lnkCreatePass
            // 
            this.lnkCreatePass.AutoSize = true;
            this.lnkCreatePass.Location = new System.Drawing.Point(173, 112);
            this.lnkCreatePass.Name = "lnkCreatePass";
            this.lnkCreatePass.Size = new System.Drawing.Size(87, 13);
            this.lnkCreatePass.TabIndex = 34;
            this.lnkCreatePass.TabStop = true;
            this.lnkCreatePass.Text = "Create Password";
            this.lnkCreatePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCreatePass_LinkClicked);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::AIMSClient.Properties.Resources.psClose;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(267, 143);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 28);
            this.btnExit.TabIndex = 33;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(123, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(229, 20);
            this.txtPassword.TabIndex = 32;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(123, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(229, 20);
            this.txtName.TabIndex = 31;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(183, 143);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 28);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPassword.Location = new System.Drawing.Point(64, 96);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblName.Location = new System.Drawing.Point(62, 62);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 13);
            this.lblName.TabIndex = 29;
            this.lblName.Text = "Username";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.gpbxVersion.Visible = false;
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
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = global::AIMSClient.Properties.Resources.AIMS_LOGO__1_;
            this.picLogo.Location = new System.Drawing.Point(76, 408);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(855, 205);
            this.picLogo.TabIndex = 11;
            this.picLogo.TabStop = false;
            this.picLogo.Visible = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 520);
            this.ControlBox = false;
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.gpbxLogon);
            this.Controls.Add(this.btnPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLogin_Paint);
            this.Resize += new System.EventHandler(this.frmLogin_Resize);
            this.gpbxLogon.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gpbxLogon;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.GroupBox gpbxVersion;
        internal System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkForgotPass;
        private System.Windows.Forms.LinkLabel lnkCreatePass;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.Label lblName;
    }
}