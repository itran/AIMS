namespace AIMSUserControls
{
    partial class frmLookup
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
            this.aimsComboLookup1 = new AIMSUserControls.aimsComboLookup();
            this.SuspendLayout();
            // 
            // aimsComboLookup1
            // 
            this.aimsComboLookup1.AIMSDataTbl = null;
            this.aimsComboLookup1.DataField1 = null;
            this.aimsComboLookup1.DataField2 = null;
            this.aimsComboLookup1.ItemsLoaded = 0;
            this.aimsComboLookup1.Location = new System.Drawing.Point(3, 5);
            this.aimsComboLookup1.Name = "aimsComboLookup1";
            this.aimsComboLookup1.Size = new System.Drawing.Size(277, 160);
            this.aimsComboLookup1.TabIndex = 0;
            this.aimsComboLookup1.TableName = null;
            // 
            // frmLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 202);
            this.Controls.Add(this.aimsComboLookup1);
            this.Name = "frmLookup";
            this.Text = "frmLookup";
            this.Load += new System.EventHandler(this.frmLookup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private aimsComboLookup aimsComboLookup1;
    }
}