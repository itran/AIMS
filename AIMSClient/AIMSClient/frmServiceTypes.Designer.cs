namespace AIMSClient
{
    partial class frmServiceTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceTypes));
            this.htmlReporter1 = new UserControls.HTMLControl();
            this.SuspendLayout();
            // 
            // htmlReporter1
            // 
            this.htmlReporter1.HTMLEmptyButtonPushed = false;
            this.htmlReporter1.HTMLHeaderVisible = false;
            this.htmlReporter1.HTMLLink = "";
            this.htmlReporter1.HTMLMainMenuCount = 0;
            this.htmlReporter1.HTMLOnePageButtonPushed = false;
            this.htmlReporter1.HTMLScrollVisible = true;
            this.htmlReporter1.HTMLShowToolbar = true;
            this.htmlReporter1.HTMLWebAddress = "";
            this.htmlReporter1.Location = new System.Drawing.Point(12, 12);
            this.htmlReporter1.Name = "htmlReporter1";
            this.htmlReporter1.Size = new System.Drawing.Size(563, 376);
            this.htmlReporter1.TabIndex = 1;
            // 
            // frmServiceTypes
            // 
            this.ClientSize = new System.Drawing.Size(941, 578);
            this.Controls.Add(this.htmlReporter1);
            this.Name = "frmServiceTypes";
            this.Load += new System.EventHandler(this.frmServiceTypes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.HTMLControl htmlReporter1;
    }
}