namespace AIMSClient
{
    partial class frmAppointmentsAudit
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
            this.lstvwAppointmentsAudit = new System.Windows.Forms.ListView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printAuditReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvwAppointmentsAudit
            // 
            this.lstvwAppointmentsAudit.ContextMenuStrip = this.contextMenu;
            this.lstvwAppointmentsAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvwAppointmentsAudit.Location = new System.Drawing.Point(0, 0);
            this.lstvwAppointmentsAudit.Name = "lstvwAppointmentsAudit";
            this.lstvwAppointmentsAudit.Size = new System.Drawing.Size(935, 515);
            this.lstvwAppointmentsAudit.TabIndex = 1;
            this.lstvwAppointmentsAudit.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printAuditReportToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(167, 26);
            // 
            // printAuditReportToolStripMenuItem
            // 
            this.printAuditReportToolStripMenuItem.Name = "printAuditReportToolStripMenuItem";
            this.printAuditReportToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.printAuditReportToolStripMenuItem.Text = "Print Audit report";
            this.printAuditReportToolStripMenuItem.Click += new System.EventHandler(this.printAuditReportToolStripMenuItem_Click);
            // 
            // frmAppointmentsAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 515);
            this.Controls.Add(this.lstvwAppointmentsAudit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAppointmentsAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAppointmentsAudit";
            this.Load += new System.EventHandler(this.frmAppointmentsAudit_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvwAppointmentsAudit;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem printAuditReportToolStripMenuItem;
    }
}