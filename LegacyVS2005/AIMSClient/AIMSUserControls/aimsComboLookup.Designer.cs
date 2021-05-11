namespace AIMSUserControls
{
    partial class aimsComboLookup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCombo = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.radCode = new System.Windows.Forms.RadioButton();
            this.radDescription = new System.Windows.Forms.RadioButton();
            this.pnlCombo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCombo
            // 
            this.pnlCombo.Controls.Add(this.txtSearch);
            this.pnlCombo.Controls.Add(this.lstItems);
            this.pnlCombo.Controls.Add(this.radCode);
            this.pnlCombo.Controls.Add(this.radDescription);
            this.pnlCombo.Location = new System.Drawing.Point(4, 3);
            this.pnlCombo.Name = "pnlCombo";
            this.pnlCombo.Size = new System.Drawing.Size(270, 271);
            this.pnlCombo.TabIndex = 0;
            this.pnlCombo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCombo_Paint);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(1, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(266, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(-1, 53);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(266, 212);
            this.lstItems.TabIndex = 1;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            this.lstItems.DoubleClick += new System.EventHandler(this.lstItems_DoubleClick);
            this.lstItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstItems_KeyDown);
            // 
            // radCode
            // 
            this.radCode.AutoSize = true;
            this.radCode.Location = new System.Drawing.Point(108, 4);
            this.radCode.Name = "radCode";
            this.radCode.Size = new System.Drawing.Size(53, 17);
            this.radCode.TabIndex = 1;
            this.radCode.TabStop = true;
            this.radCode.Text = " Code";
            this.radCode.UseVisualStyleBackColor = true;
            this.radCode.CheckedChanged += new System.EventHandler(this.radCode_CheckedChanged);
            // 
            // radDescription
            // 
            this.radDescription.AutoSize = true;
            this.radDescription.Location = new System.Drawing.Point(4, 4);
            this.radDescription.Name = "radDescription";
            this.radDescription.Size = new System.Drawing.Size(78, 17);
            this.radDescription.TabIndex = 0;
            this.radDescription.TabStop = true;
            this.radDescription.Text = "Description";
            this.radDescription.UseVisualStyleBackColor = true;
            this.radDescription.CheckedChanged += new System.EventHandler(this.radDescription_CheckedChanged);
            // 
            // aimsComboLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCombo);
            this.Name = "aimsComboLookup";
            this.Size = new System.Drawing.Size(281, 278);
            this.Load += new System.EventHandler(this.aimsComboLookup_Load);
            this.Resize += new System.EventHandler(this.aimsComboLookup_Resize);
            this.pnlCombo.ResumeLayout(false);
            this.pnlCombo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCombo;
        public System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.RadioButton radCode;
        private System.Windows.Forms.RadioButton radDescription;
        public System.Windows.Forms.TextBox txtSearch;
    }
}
