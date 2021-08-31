namespace AIMSClient
{
    partial class frmPasswordSetup
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
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPassConfirm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPasswordHintAnswer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbPasswordHint = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGetPassword = new System.Windows.Forms.Button();
            this.txtRecoveryPasswordHintAnswer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRecoveryPasswordHint = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 246);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnPassConfirm);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(584, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Account Password";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnPassConfirm
            // 
            this.btnPassConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassConfirm.Location = new System.Drawing.Point(375, 192);
            this.btnPassConfirm.Name = "btnPassConfirm";
            this.btnPassConfirm.Size = new System.Drawing.Size(122, 23);
            this.btnPassConfirm.TabIndex = 7;
            this.btnPassConfirm.Text = "Create Password";
            this.btnPassConfirm.UseVisualStyleBackColor = true;
            this.btnPassConfirm.Click += new System.EventHandler(this.btnPassConfirm_Click_1);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(503, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPasswordHintAnswer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPasswordConfirm);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.cmbPasswordHint);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 180);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password Setup";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(149, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "(This is the answer you will have to provide if you ever forget your password)";
            // 
            // txtPasswordHintAnswer
            // 
            this.txtPasswordHintAnswer.Location = new System.Drawing.Point(128, 111);
            this.txtPasswordHintAnswer.Name = "txtPasswordHintAnswer";
            this.txtPasswordHintAnswer.Size = new System.Drawing.Size(416, 20);
            this.txtPasswordHintAnswer.TabIndex = 3;
            this.txtPasswordHintAnswer.TextChanged += new System.EventHandler(this.txtPasswordHintAnswer_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password Hint Answer:";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(128, 58);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(287, 20);
            this.txtPasswordConfirm.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(287, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // cmbPasswordHint
            // 
            this.cmbPasswordHint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPasswordHint.FormattingEnabled = true;
            this.cmbPasswordHint.Items.AddRange(new object[] {
            "What was the last name of your Matric teacher?",
            "What was the name of the boy/girl you had your second kiss with?",
            "What was the name of your second dog/cat/goldfish/etc?",
            "Where were you when you had your first kiss?",
            "When you were young, what did you want to be when you grew up?",
            "Where were you when you first heard about 9/11?",
            "Who was your childhood hero/in?"});
            this.cmbPasswordHint.Location = new System.Drawing.Point(128, 84);
            this.cmbPasswordHint.Name = "cmbPasswordHint";
            this.cmbPasswordHint.Size = new System.Drawing.Size(416, 21);
            this.cmbPasswordHint.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password Hint:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Password";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGetPassword);
            this.tabPage2.Controls.Add(this.txtRecoveryPasswordHintAnswer);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cmbRecoveryPasswordHint);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(584, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Recover Your Password";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGetPassword
            // 
            this.btnGetPassword.Location = new System.Drawing.Point(420, 70);
            this.btnGetPassword.Name = "btnGetPassword";
            this.btnGetPassword.Size = new System.Drawing.Size(124, 31);
            this.btnGetPassword.TabIndex = 13;
            this.btnGetPassword.Text = "Retrieve My Password";
            this.btnGetPassword.UseVisualStyleBackColor = true;
            this.btnGetPassword.Click += new System.EventHandler(this.btnGetPassword_Click);
            // 
            // txtRecoveryPasswordHintAnswer
            // 
            this.txtRecoveryPasswordHintAnswer.Location = new System.Drawing.Point(128, 44);
            this.txtRecoveryPasswordHintAnswer.Name = "txtRecoveryPasswordHintAnswer";
            this.txtRecoveryPasswordHintAnswer.Size = new System.Drawing.Size(416, 20);
            this.txtRecoveryPasswordHintAnswer.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Password Hint Answer:";
            // 
            // cmbRecoveryPasswordHint
            // 
            this.cmbRecoveryPasswordHint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecoveryPasswordHint.FormattingEnabled = true;
            this.cmbRecoveryPasswordHint.Items.AddRange(new object[] {
            "What was the last name of your Matric teacher?",
            "What was the name of the boy/girl you had your second kiss with?",
            "What was the name of your second dog/cat/goldfish/etc?",
            "Where were you when you had your first kiss?",
            "When you were young, what did you want to be when you grew up?",
            "Where were you when you first heard about 9?",
            "Who was your childhood hero?"});
            this.cmbRecoveryPasswordHint.Location = new System.Drawing.Point(128, 17);
            this.cmbRecoveryPasswordHint.Name = "cmbRecoveryPasswordHint";
            this.cmbRecoveryPasswordHint.Size = new System.Drawing.Size(416, 21);
            this.cmbRecoveryPasswordHint.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Password Hint:";
            // 
            // frmPasswordSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 251);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmPasswordSetup";
            this.Text = "System Authorization";
            this.Load += new System.EventHandler(this.frmPasswordSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPassConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPasswordHintAnswer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbPasswordHint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetPassword;
        private System.Windows.Forms.TextBox txtRecoveryPasswordHintAnswer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbRecoveryPasswordHint;
        private System.Windows.Forms.Label label8;
    }
}