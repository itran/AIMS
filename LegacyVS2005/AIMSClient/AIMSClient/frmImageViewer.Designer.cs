namespace AIMSClient
{
    partial class frmImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageViewer));
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPreviousImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNextImage
            // 
            this.btnNextImage.Image = global::AIMSClient.Properties.Resources.next;
            this.btnNextImage.Location = new System.Drawing.Point(481, 497);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(35, 29);
            this.btnNextImage.TabIndex = 2;
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Visible = false;
            // 
            // btnPreviousImage
            // 
            this.btnPreviousImage.Image = global::AIMSClient.Properties.Resources.previous;
            this.btnPreviousImage.Location = new System.Drawing.Point(443, 497);
            this.btnPreviousImage.Name = "btnPreviousImage";
            this.btnPreviousImage.Size = new System.Drawing.Size(35, 29);
            this.btnPreviousImage.TabIndex = 3;
            this.btnPreviousImage.UseVisualStyleBackColor = true;
            this.btnPreviousImage.Visible = false;
            // 
            // frmImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 580);
            this.Controls.Add(this.btnPreviousImage);
            this.Controls.Add(this.btnNextImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmImageViewer";
            this.Load += new System.EventHandler(this.frmImageViewer_Load);
            this.Closing += this.frmImageViewer_Closing;

            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnPreviousImage;
    }
}