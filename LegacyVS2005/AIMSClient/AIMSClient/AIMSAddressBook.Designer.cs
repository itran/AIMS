namespace AIMSClient
{
    partial class frmAIMSAddressBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAIMSAddressBook));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.aimsComboLookup1 = new AIMSUserControls.aimsComboLookup();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtContactFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContactEmailAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddToContacts = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddToContacts);
            this.groupBox1.Controls.Add(this.txtContactEmailAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtContactLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtContactFirstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 137);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Contact";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.aimsComboLookup1);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 302);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contact Search";
            // 
            // aimsComboLookup1
            // 
            this.aimsComboLookup1.AIMSDataTbl = null;
            this.aimsComboLookup1.DataField1 = null;
            this.aimsComboLookup1.DataField2 = null;
            this.aimsComboLookup1.Field1Value = "Contact Email Address";
            this.aimsComboLookup1.Field2Value = "";
            this.aimsComboLookup1.ItemsLoaded = 0;
            this.aimsComboLookup1.Location = new System.Drawing.Point(6, 19);
            this.aimsComboLookup1.Name = "aimsComboLookup1";
            this.aimsComboLookup1.OrderByField = null;
            this.aimsComboLookup1.ShowButtons = true;
            this.aimsComboLookup1.ShowButtonTwo = false;
            this.aimsComboLookup1.Size = new System.Drawing.Size(379, 258);
            this.aimsComboLookup1.TabIndex = 2;
            this.aimsComboLookup1.TableName = null;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(259, 257);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // txtContactFirstName
            // 
            this.txtContactFirstName.Location = new System.Drawing.Point(69, 30);
            this.txtContactFirstName.Name = "txtContactFirstName";
            this.txtContactFirstName.Size = new System.Drawing.Size(317, 20);
            this.txtContactFirstName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // txtContactLastName
            // 
            this.txtContactLastName.Location = new System.Drawing.Point(69, 56);
            this.txtContactLastName.Name = "txtContactLastName";
            this.txtContactLastName.Size = new System.Drawing.Size(317, 20);
            this.txtContactLastName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name";
            // 
            // txtContactEmailAddress
            // 
            this.txtContactEmailAddress.Location = new System.Drawing.Point(69, 82);
            this.txtContactEmailAddress.Name = "txtContactEmailAddress";
            this.txtContactEmailAddress.Size = new System.Drawing.Size(317, 20);
            this.txtContactEmailAddress.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email";
            // 
            // btnAddToContacts
            // 
            this.btnAddToContacts.Location = new System.Drawing.Point(272, 108);
            this.btnAddToContacts.Name = "btnAddToContacts";
            this.btnAddToContacts.Size = new System.Drawing.Size(114, 23);
            this.btnAddToContacts.TabIndex = 8;
            this.btnAddToContacts.Text = "Add to Contacts";
            this.btnAddToContacts.UseVisualStyleBackColor = true;
            this.btnAddToContacts.Click += new System.EventHandler(this.btnAddToContacts_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmAIMSAddressBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAIMSAddressBook";
            this.Text = "AIMS Address Book";
            this.Load += new System.EventHandler(this.frmAIMSAddressBook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelect;
        private AIMSUserControls.aimsComboLookup aimsComboLookup1;
        private System.Windows.Forms.TextBox txtContactFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContactLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContactEmailAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddToContacts;
        private System.Windows.Forms.ErrorProvider errProvider;
    }
}