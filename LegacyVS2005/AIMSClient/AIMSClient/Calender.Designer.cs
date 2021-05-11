namespace AIMSClient
{
    partial class Calender
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
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler4 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAppointments = new AIMSClient.dsAppointments();
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsResources = new AIMSClient.dsResources();
            this.appointmentsTableAdapter = new AIMSClient.dsAppointmentsTableAdapters.AppointmentsTableAdapter();
            this.resourcesTableAdapter = new AIMSClient.dsResourcesTableAdapters.ResourcesTableAdapter();
            this.tabGlobalCalender = new System.Windows.Forms.TabControl();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.AIMSScheduler = new DevExpress.XtraScheduler.SchedulerControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowDtNavigator = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideDtNavigator = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.calMonthView = new System.Windows.Forms.ToolStripMenuItem();
            this.calWeekView = new System.Windows.Forms.ToolStripMenuItem();
            this.calDayView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.calRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOverDueTasks = new System.Windows.Forms.TabPage();
            this.lstlvOverdueTasks = new System.Windows.Forms.ListView();
            this.tmrCalender = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsResources)).BeginInit();
            this.tabGlobalCalender.SuspendLayout();
            this.tabAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AIMSScheduler)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.tabOverDueTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.DataSource = this.appointmentsBindingSource;
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "Type";
            this.schedulerStorage1.Appointments.ResourceSharing = true;
            this.schedulerStorage1.Resources.DataSource = this.resourcesBindingSource;
            this.schedulerStorage1.Resources.Mappings.Caption = "ResourceName";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "ResourceID";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.dsAppointments;
            // 
            // dsAppointments
            // 
            this.dsAppointments.DataSetName = "dsAppointments";
            this.dsAppointments.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "Resources";
            this.resourcesBindingSource.DataSource = this.dsResources;
            // 
            // dsResources
            // 
            this.dsResources.DataSetName = "dsResources";
            this.dsResources.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // tabGlobalCalender
            // 
            this.tabGlobalCalender.Controls.Add(this.tabAppointments);
            this.tabGlobalCalender.Controls.Add(this.tabOverDueTasks);
            this.tabGlobalCalender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGlobalCalender.Location = new System.Drawing.Point(0, 0);
            this.tabGlobalCalender.Name = "tabGlobalCalender";
            this.tabGlobalCalender.SelectedIndex = 0;
            this.tabGlobalCalender.Size = new System.Drawing.Size(1229, 742);
            this.tabGlobalCalender.TabIndex = 0;
            // 
            // tabAppointments
            // 
            this.tabAppointments.Controls.Add(this.dateNavigator1);
            this.tabAppointments.Controls.Add(this.AIMSScheduler);
            this.tabAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(1221, 716);
            this.tabAppointments.TabIndex = 0;
            this.tabAppointments.Text = "Appointments";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateNavigator1.HotDate = null;
            this.dateNavigator1.Location = new System.Drawing.Point(1009, 3);
            this.dateNavigator1.LookAndFeel.SkinName = "Blue";
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.AIMSScheduler;
            this.dateNavigator1.Size = new System.Drawing.Size(209, 710);
            this.dateNavigator1.TabIndex = 3;
            // 
            // AIMSScheduler
            // 
            this.AIMSScheduler.ContextMenuStrip = this.contextMenuStrip;
            this.AIMSScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AIMSScheduler.Location = new System.Drawing.Point(3, 3);
            this.AIMSScheduler.Name = "AIMSScheduler";
            this.AIMSScheduler.Size = new System.Drawing.Size(1215, 710);
            this.AIMSScheduler.Start = new System.DateTime(2015, 9, 15, 0, 0, 0, 0);
            this.AIMSScheduler.Storage = this.schedulerStorage1;
            this.AIMSScheduler.TabIndex = 2;
            this.AIMSScheduler.Text = "schedulerControl1";
            this.AIMSScheduler.Views.DayView.TimeRulers.Add(timeRuler3);
            this.AIMSScheduler.Views.MonthView.AppointmentDisplayOptions.ShowRecurrence = true;
            this.AIMSScheduler.Views.MonthView.AppointmentDisplayOptions.ShowReminder = true;
            this.AIMSScheduler.Views.MonthView.CompressWeekend = false;
            this.AIMSScheduler.Views.MonthView.DisplayName = "Monthly";
            this.AIMSScheduler.Views.WorkWeekView.TimeRulers.Add(timeRuler4);
            this.AIMSScheduler.Click += new System.EventHandler(this.AIMSScheduler_Click_1);
            this.AIMSScheduler.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.AIMSScheduler_PopupMenuShowing);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowDtNavigator,
            this.mnuHideDtNavigator,
            this.toolStripSeparator1,
            this.calMonthView,
            this.calWeekView,
            this.calDayView,
            this.toolStripSeparator2,
            this.calRefresh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(186, 148);
            // 
            // mnuShowDtNavigator
            // 
            this.mnuShowDtNavigator.Name = "mnuShowDtNavigator";
            this.mnuShowDtNavigator.Size = new System.Drawing.Size(185, 22);
            this.mnuShowDtNavigator.Text = "Show Date Navigator";
            this.mnuShowDtNavigator.Click += new System.EventHandler(this.mnuShowDtNavigator_Click);
            // 
            // mnuHideDtNavigator
            // 
            this.mnuHideDtNavigator.Name = "mnuHideDtNavigator";
            this.mnuHideDtNavigator.Size = new System.Drawing.Size(185, 22);
            this.mnuHideDtNavigator.Text = "Hide Date Navigator";
            this.mnuHideDtNavigator.Click += new System.EventHandler(this.mnuHideDtNavigator_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // calMonthView
            // 
            this.calMonthView.Name = "calMonthView";
            this.calMonthView.Size = new System.Drawing.Size(185, 22);
            this.calMonthView.Text = "Month View";
            this.calMonthView.Click += new System.EventHandler(this.calMonthView_Click);
            // 
            // calWeekView
            // 
            this.calWeekView.Name = "calWeekView";
            this.calWeekView.Size = new System.Drawing.Size(185, 22);
            this.calWeekView.Text = "Week View";
            this.calWeekView.Click += new System.EventHandler(this.calWeekView_Click);
            // 
            // calDayView
            // 
            this.calDayView.Name = "calDayView";
            this.calDayView.Size = new System.Drawing.Size(185, 22);
            this.calDayView.Text = "Day View";
            this.calDayView.Click += new System.EventHandler(this.calDayView_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // calRefresh
            // 
            this.calRefresh.Name = "calRefresh";
            this.calRefresh.Size = new System.Drawing.Size(185, 22);
            this.calRefresh.Text = "Refresh Calender";
            this.calRefresh.Click += new System.EventHandler(this.calRefresh_Click);
            // 
            // tabOverDueTasks
            // 
            this.tabOverDueTasks.Controls.Add(this.lstlvOverdueTasks);
            this.tabOverDueTasks.ForeColor = System.Drawing.Color.Black;
            this.tabOverDueTasks.Location = new System.Drawing.Point(4, 22);
            this.tabOverDueTasks.Name = "tabOverDueTasks";
            this.tabOverDueTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverDueTasks.Size = new System.Drawing.Size(1221, 716);
            this.tabOverDueTasks.TabIndex = 1;
            this.tabOverDueTasks.Text = "Overdue Tasks";
            this.tabOverDueTasks.UseVisualStyleBackColor = true;
            // 
            // lstlvOverdueTasks
            // 
            this.lstlvOverdueTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstlvOverdueTasks.Location = new System.Drawing.Point(3, 3);
            this.lstlvOverdueTasks.Name = "lstlvOverdueTasks";
            this.lstlvOverdueTasks.Size = new System.Drawing.Size(1215, 710);
            this.lstlvOverdueTasks.TabIndex = 0;
            this.lstlvOverdueTasks.UseCompatibleStateImageBehavior = false;
            this.lstlvOverdueTasks.View = System.Windows.Forms.View.Details;
            // 
            // tmrCalender
            // 
            this.tmrCalender.Interval = 600000;
            this.tmrCalender.Tick += new System.EventHandler(this.tmrCalender_Tick);
            // 
            // Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 742);
            this.Controls.Add(this.tabGlobalCalender);
            this.Name = "Calender";
            this.Text = "AIMS Calender";
            this.Load += new System.EventHandler(this.Calender_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsResources)).EndInit();
            this.tabGlobalCalender.ResumeLayout(false);
            this.tabAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AIMSScheduler)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.tabOverDueTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private dsAppointments dsAppointments;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private AIMSClient.dsAppointmentsTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private dsResources dsResources;
        private System.Windows.Forms.BindingSource resourcesBindingSource;
        private AIMSClient.dsResourcesTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
        private System.Windows.Forms.TabControl tabGlobalCalender;
        private System.Windows.Forms.TabPage tabAppointments;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraScheduler.SchedulerControl AIMSScheduler;
        private System.Windows.Forms.TabPage tabOverDueTasks;
        private System.Windows.Forms.ListView lstlvOverdueTasks;
        private System.Windows.Forms.Timer tmrCalender;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuShowDtNavigator;
        private System.Windows.Forms.ToolStripMenuItem mnuHideDtNavigator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem calMonthView;
        private System.Windows.Forms.ToolStripMenuItem calWeekView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem calRefresh;
        private System.Windows.Forms.ToolStripMenuItem calDayView;
    }
}