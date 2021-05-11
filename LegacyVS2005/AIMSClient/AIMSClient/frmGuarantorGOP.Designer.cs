namespace AIMSClient
{
    partial class frmGuarantorGOP
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
            this.btnAttachGOP = new System.Windows.Forms.Button();
            this.lstvwInsuranceGOP = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnAttachGOP
            // 
            this.btnAttachGOP.Location = new System.Drawing.Point(501, 264);
            this.btnAttachGOP.Name = "btnAttachGOP";
            this.btnAttachGOP.Size = new System.Drawing.Size(75, 38);
            this.btnAttachGOP.TabIndex = 0;
            this.btnAttachGOP.Text = "Select";
            this.btnAttachGOP.UseVisualStyleBackColor = true;
            this.btnAttachGOP.Click += new System.EventHandler(this.btnAttachGOP_Click);
            // 
            // lstvwInsuranceGOP
            // 
            this.lstvwInsuranceGOP.CheckBoxes = true;
            this.lstvwInsuranceGOP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.lstvwInsuranceGOP.HideSelection = false;
            this.lstvwInsuranceGOP.Location = new System.Drawing.Point(0, 0);
            this.lstvwInsuranceGOP.MultiSelect = false;
            this.lstvwInsuranceGOP.Name = "lstvwInsuranceGOP";
            this.lstvwInsuranceGOP.Size = new System.Drawing.Size(576, 258);
            this.lstvwInsuranceGOP.TabIndex = 1;
            this.lstvwInsuranceGOP.UseCompatibleStateImageBehavior = false;
            this.lstvwInsuranceGOP.View = System.Windows.Forms.View.Details;
            this.lstvwInsuranceGOP.SelectedIndexChanged += new System.EventHandler(this.lstvwInsuranceGOP_SelectedIndexChanged);
            this.lstvwInsuranceGOP.DoubleClick += new System.EventHandler(this.lstvwInsuranceGOP_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Letter Of Guarantee";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "L-O-G Received Date";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "EmailDocID";
            this.columnHeader2.Width = 0;
            // 
            // frmGuarantorGOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 302);
            this.Controls.Add(this.lstvwInsuranceGOP);
            this.Controls.Add(this.btnAttachGOP);
            this.Name = "frmGuarantorGOP";
            this.Text = "Select Insurance GOP";
            this.Load += new System.EventHandler(this.frmGuarantorGOP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAttachGOP;
        private System.Windows.Forms.ListView lstvwInsuranceGOP;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}