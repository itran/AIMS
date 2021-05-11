namespace AIMSClient
{
    partial class frmTasks
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSendTaskIM = new System.Windows.Forms.CheckBox();
            this.cboTaskStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.chkTaskActiveYN = new System.Windows.Forms.CheckBox();
            this.lnklblCompletionDate = new System.Windows.Forms.LinkLabel();
            this.txtCompletionDate = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTasks = new System.Windows.Forms.ComboBox();
            this.txtTaskDetails = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lnklblTaskDueDate = new System.Windows.Forms.LinkLabel();
            this.txtTaskDueDate = new System.Windows.Forms.TextBox();
            this.cboTaskUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chkSendTaskIM);
            this.panel1.Controls.Add(this.cboTaskStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboPriority);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTaskID);
            this.panel1.Controls.Add(this.chkTaskActiveYN);
            this.panel1.Controls.Add(this.lnklblCompletionDate);
            this.panel1.Controls.Add(this.txtCompletionDate);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnAddTask);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboTasks);
            this.panel1.Controls.Add(this.txtTaskDetails);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lnklblTaskDueDate);
            this.panel1.Controls.Add(this.txtTaskDueDate);
            this.panel1.Controls.Add(this.cboTaskUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 372);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 171;
            this.label6.Text = "[250 Characters]";
            // 
            // chkSendTaskIM
            // 
            this.chkSendTaskIM.AutoSize = true;
            this.chkSendTaskIM.Checked = true;
            this.chkSendTaskIM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendTaskIM.Location = new System.Drawing.Point(95, 63);
            this.chkSendTaskIM.Name = "chkSendTaskIM";
            this.chkSendTaskIM.Size = new System.Drawing.Size(134, 17);
            this.chkSendTaskIM.TabIndex = 170;
            this.chkSendTaskIM.Text = "Send Task Notification";
            this.chkSendTaskIM.UseVisualStyleBackColor = true;
            // 
            // cboTaskStatus
            // 
            this.cboTaskStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaskStatus.FormattingEnabled = true;
            this.cboTaskStatus.Location = new System.Drawing.Point(91, 304);
            this.cboTaskStatus.Name = "cboTaskStatus";
            this.cboTaskStatus.Size = new System.Drawing.Size(239, 21);
            this.cboTaskStatus.TabIndex = 169;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 168;
            this.label5.Text = "Task Status";
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.Location = new System.Drawing.Point(91, 111);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(239, 21);
            this.cboPriority.TabIndex = 167;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 166;
            this.label4.Text = "Priority";
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Location = new System.Drawing.Point(225, 247);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(0, 13);
            this.lblTaskID.TabIndex = 165;
            this.lblTaskID.Visible = false;
            // 
            // chkTaskActiveYN
            // 
            this.chkTaskActiveYN.AutoSize = true;
            this.chkTaskActiveYN.Checked = true;
            this.chkTaskActiveYN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaskActiveYN.Location = new System.Drawing.Point(222, 336);
            this.chkTaskActiveYN.Name = "chkTaskActiveYN";
            this.chkTaskActiveYN.Size = new System.Drawing.Size(92, 17);
            this.chkTaskActiveYN.TabIndex = 164;
            this.chkTaskActiveYN.Text = "Task Active ?";
            this.chkTaskActiveYN.UseVisualStyleBackColor = true;
            this.chkTaskActiveYN.Visible = false;
            // 
            // lnklblCompletionDate
            // 
            this.lnklblCompletionDate.AutoSize = true;
            this.lnklblCompletionDate.Location = new System.Drawing.Point(229, 269);
            this.lnklblCompletionDate.Name = "lnklblCompletionDate";
            this.lnklblCompletionDate.Size = new System.Drawing.Size(85, 13);
            this.lnklblCompletionDate.TabIndex = 163;
            this.lnklblCompletionDate.TabStop = true;
            this.lnklblCompletionDate.Text = "Completion Date";
            this.lnklblCompletionDate.Visible = false;
            this.lnklblCompletionDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCompletionDate_LinkClicked);
            // 
            // txtCompletionDate
            // 
            this.txtCompletionDate.Location = new System.Drawing.Point(316, 266);
            this.txtCompletionDate.Name = "txtCompletionDate";
            this.txtCompletionDate.ReadOnly = true;
            this.txtCompletionDate.Size = new System.Drawing.Size(239, 20);
            this.txtCompletionDate.TabIndex = 162;
            this.txtCompletionDate.Visible = false;
            this.txtCompletionDate.DoubleClick += new System.EventHandler(this.txtCompletionDate_DoubleClick);
            this.txtCompletionDate.TextChanged += new System.EventHandler(this.txtCompletionDate_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::AIMSClient.Properties.Resources.refresh;
            this.btnClear.Location = new System.Drawing.Point(144, 331);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(47, 30);
            this.btnClear.TabIndex = 161;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Image = global::AIMSClient.Properties.Resources.add;
            this.btnAddTask.Location = new System.Drawing.Point(91, 331);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(47, 30);
            this.btnAddTask.TabIndex = 160;
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Task";
            // 
            // cboTasks
            // 
            this.cboTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTasks.FormattingEnabled = true;
            this.cboTasks.Location = new System.Drawing.Point(91, 9);
            this.cboTasks.Name = "cboTasks";
            this.cboTasks.Size = new System.Drawing.Size(239, 21);
            this.cboTasks.TabIndex = 8;
            // 
            // txtTaskDetails
            // 
            this.txtTaskDetails.Location = new System.Drawing.Point(91, 138);
            this.txtTaskDetails.MaxLength = 250;
            this.txtTaskDetails.Multiline = true;
            this.txtTaskDetails.Name = "txtTaskDetails";
            this.txtTaskDetails.Size = new System.Drawing.Size(239, 132);
            this.txtTaskDetails.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Details";
            // 
            // lnklblTaskDueDate
            // 
            this.lnklblTaskDueDate.AutoSize = true;
            this.lnklblTaskDueDate.Location = new System.Drawing.Point(14, 88);
            this.lnklblTaskDueDate.Name = "lnklblTaskDueDate";
            this.lnklblTaskDueDate.Size = new System.Drawing.Size(53, 13);
            this.lnklblTaskDueDate.TabIndex = 5;
            this.lnklblTaskDueDate.TabStop = true;
            this.lnklblTaskDueDate.Text = "Due Date";
            this.lnklblTaskDueDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblTaskDueDate_LinkClicked);
            // 
            // txtTaskDueDate
            // 
            this.txtTaskDueDate.Location = new System.Drawing.Point(91, 85);
            this.txtTaskDueDate.Name = "txtTaskDueDate";
            this.txtTaskDueDate.ReadOnly = true;
            this.txtTaskDueDate.Size = new System.Drawing.Size(239, 20);
            this.txtTaskDueDate.TabIndex = 4;
            this.txtTaskDueDate.DoubleClick += new System.EventHandler(this.txtTaskDueDate_DoubleClick);
            this.txtTaskDueDate.TextChanged += new System.EventHandler(this.txtTaskDueDate_TextChanged);
            // 
            // cboTaskUser
            // 
            this.cboTaskUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaskUser.FormattingEnabled = true;
            this.cboTaskUser.Location = new System.Drawing.Point(91, 36);
            this.cboTaskUser.Name = "cboTaskUser";
            this.cboTaskUser.Size = new System.Drawing.Size(239, 21);
            this.cboTaskUser.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 372);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTasks";
            this.Text = "Add Task";
            this.Load += new System.EventHandler(this.frmTasks_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTaskUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnklblTaskDueDate;
        private System.Windows.Forms.TextBox txtTaskDueDate;
        private System.Windows.Forms.TextBox txtTaskDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTasks;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.LinkLabel lnklblCompletionDate;
        private System.Windows.Forms.TextBox txtCompletionDate;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.CheckBox chkTaskActiveYN;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTaskStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSendTaskIM;
        private System.Windows.Forms.Label label6;

    }
}