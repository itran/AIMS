namespace AIMSClient
{
    partial class frmReportViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportViewer));
            this.htmlReporter1 = new UserControls.HTMLControl();
            this.dataTable1 = new System.Data.DataTable();
            this.dataTable2 = new System.Data.DataTable();
            this.dataTable3 = new System.Data.DataTable();
            this.dataTable4 = new System.Data.DataTable();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).BeginInit();
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
            this.htmlReporter1.Location = new System.Drawing.Point(3, -1);
            this.htmlReporter1.Name = "htmlReporter1";
            this.htmlReporter1.Size = new System.Drawing.Size(851, 481);
            this.htmlReporter1.TabIndex = 0;
            this.htmlReporter1.Load += new System.EventHandler(this.htmlReporter1_Load);
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // dataTable2
            // 
            this.dataTable2.TableName = "Table2";
            // 
            // dataTable3
            // 
            this.dataTable3.TableName = "Table3";
            // 
            // dataTable4
            // 
            this.dataTable4.TableName = "Table4";
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 492);
            this.Controls.Add(this.htmlReporter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportViewer";
            this.Text = "frmReportViewer";
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            this.Resize += new System.EventHandler(this.frmReportViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.HTMLControl htmlReporter1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataTable dataTable2;
        private System.Data.DataTable dataTable3;
        private System.Data.DataTable dataTable4;
    }
}