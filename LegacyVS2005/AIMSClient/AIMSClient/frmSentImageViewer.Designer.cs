namespace AIMSClient
{
    partial class frmSentImageViewer
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
            this.imgViewer = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSentDttm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSentEmailFrom = new System.Windows.Forms.TextBox();
            this.txtSentEmailTo = new System.Windows.Forms.TextBox();
            this.txtSentEmailCC = new System.Windows.Forms.TextBox();
            this.txtSentEmailSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgViewer
            // 
            this.imgViewer.Location = new System.Drawing.Point(8, 127);
            this.imgViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.imgViewer.Name = "imgViewer";
            this.imgViewer.Size = new System.Drawing.Size(1020, 461);
            this.imgViewer.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSentDttm);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSentEmailFrom);
            this.groupBox1.Controls.Add(this.txtSentEmailTo);
            this.groupBox1.Controls.Add(this.txtSentEmailCC);
            this.groupBox1.Controls.Add(this.txtSentEmailSubject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 120);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtSentDttm
            // 
            this.txtSentDttm.Location = new System.Drawing.Point(768, 16);
            this.txtSentDttm.Name = "txtSentDttm";
            this.txtSentDttm.ReadOnly = true;
            this.txtSentDttm.Size = new System.Drawing.Size(246, 20);
            this.txtSentDttm.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(730, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sent:";
            // 
            // txtSentEmailFrom
            // 
            this.txtSentEmailFrom.Location = new System.Drawing.Point(69, 16);
            this.txtSentEmailFrom.Name = "txtSentEmailFrom";
            this.txtSentEmailFrom.ReadOnly = true;
            this.txtSentEmailFrom.Size = new System.Drawing.Size(583, 20);
            this.txtSentEmailFrom.TabIndex = 7;
            // 
            // txtSentEmailTo
            // 
            this.txtSentEmailTo.Location = new System.Drawing.Point(69, 42);
            this.txtSentEmailTo.Name = "txtSentEmailTo";
            this.txtSentEmailTo.ReadOnly = true;
            this.txtSentEmailTo.Size = new System.Drawing.Size(583, 20);
            this.txtSentEmailTo.TabIndex = 6;
            // 
            // txtSentEmailCC
            // 
            this.txtSentEmailCC.Location = new System.Drawing.Point(69, 68);
            this.txtSentEmailCC.Name = "txtSentEmailCC";
            this.txtSentEmailCC.ReadOnly = true;
            this.txtSentEmailCC.Size = new System.Drawing.Size(583, 20);
            this.txtSentEmailCC.TabIndex = 5;
            // 
            // txtSentEmailSubject
            // 
            this.txtSentEmailSubject.Location = new System.Drawing.Point(69, 94);
            this.txtSentEmailSubject.Name = "txtSentEmailSubject";
            this.txtSentEmailSubject.ReadOnly = true;
            this.txtSentEmailSubject.Size = new System.Drawing.Size(945, 20);
            this.txtSentEmailSubject.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Subject:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // frmSentImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imgViewer);
            this.Name = "frmSentImageViewer";
            this.Text = "frmSentImageViewer";
            this.Load += new System.EventHandler(this.frmSentImageViewer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser imgViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSentEmailCC;
        private System.Windows.Forms.TextBox txtSentEmailSubject;
        private System.Windows.Forms.TextBox txtSentEmailTo;
        private System.Windows.Forms.TextBox txtSentEmailFrom;
        private System.Windows.Forms.TextBox txtSentDttm;
        private System.Windows.Forms.Label label5;
    }
}