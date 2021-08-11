namespace AIMSClient
{
    partial class frmPendEmail
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
            this.btnIndexCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtPendDate = new System.Windows.Forms.TextBox();
            this.lblPendDate = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPendReasonComment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnIndexCancel
            // 
            this.btnIndexCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndexCancel.Image = global::AIMSClient.Properties.Resources.error_50px;
            this.btnIndexCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIndexCancel.Location = new System.Drawing.Point(251, 211);
            this.btnIndexCancel.Name = "btnIndexCancel";
            this.btnIndexCancel.Size = new System.Drawing.Size(70, 79);
            this.btnIndexCancel.TabIndex = 13;
            this.btnIndexCancel.Text = "Cancel";
            this.btnIndexCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIndexCancel.UseVisualStyleBackColor = true;
            this.btnIndexCancel.Click += new System.EventHandler(this.btnIndexCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Image = global::AIMSClient.Properties.Resources.check_50px;
            this.btnConfirm.Location = new System.Drawing.Point(175, 211);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(70, 79);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "Pend";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtPendDate
            // 
            this.txtPendDate.Location = new System.Drawing.Point(125, 19);
            this.txtPendDate.Name = "txtPendDate";
            this.txtPendDate.ReadOnly = true;
            this.txtPendDate.Size = new System.Drawing.Size(196, 20);
            this.txtPendDate.TabIndex = 8;
            this.txtPendDate.DoubleClick += new System.EventHandler(this.txtPendDate_DoubleClick);
            this.txtPendDate.TextChanged += new System.EventHandler(this.txtPendDate_TextChanged);
            // 
            // lblPendDate
            // 
            this.lblPendDate.AutoSize = true;
            this.lblPendDate.Location = new System.Drawing.Point(-2, 22);
            this.lblPendDate.Name = "lblPendDate";
            this.lblPendDate.Size = new System.Drawing.Size(58, 13);
            this.lblPendDate.TabIndex = 14;
            this.lblPendDate.TabStop = true;
            this.lblPendDate.Text = "Pend Date";
            this.lblPendDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPendDate_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pend Reason/Comment";
            // 
            // txtPendReasonComment
            // 
            this.txtPendReasonComment.Location = new System.Drawing.Point(125, 45);
            this.txtPendReasonComment.Multiline = true;
            this.txtPendReasonComment.Name = "txtPendReasonComment";
            this.txtPendReasonComment.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPendReasonComment.Size = new System.Drawing.Size(196, 160);
            this.txtPendReasonComment.TabIndex = 16;
            // 
            // frmPendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 295);
            this.Controls.Add(this.txtPendReasonComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPendDate);
            this.Controls.Add(this.btnIndexCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtPendDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Email Pending Criteria";
            this.Load += new System.EventHandler(this.frmPendEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIndexCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtPendDate;
        private System.Windows.Forms.LinkLabel lblPendDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPendReasonComment;
    }
}