namespace chat
{
    partial class Contacts
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
            this.addContactButton = new System.Windows.Forms.Button();
            this.contactsListBox = new System.Windows.Forms.ListBox();
            this.StartChatButton = new System.Windows.Forms.Button();
            this.DeleteContact = new System.Windows.Forms.Button();
            this.CurrentUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addContactButton
            // 
            this.addContactButton.Location = new System.Drawing.Point(263, 12);
            this.addContactButton.Name = "addContactButton";
            this.addContactButton.Size = new System.Drawing.Size(141, 23);
            this.addContactButton.TabIndex = 0;
            this.addContactButton.Text = "Добавить контакт";
            this.addContactButton.UseVisualStyleBackColor = true;
            this.addContactButton.Click += new System.EventHandler(this.addContactButton_Click);
            // 
            // contactsListBox
            // 
            this.contactsListBox.FormattingEnabled = true;
            this.contactsListBox.Location = new System.Drawing.Point(12, 12);
            this.contactsListBox.Name = "contactsListBox";
            this.contactsListBox.Size = new System.Drawing.Size(218, 212);
            this.contactsListBox.TabIndex = 1;
            // 
            // StartChatButton
            // 
            this.StartChatButton.Location = new System.Drawing.Point(263, 61);
            this.StartChatButton.Name = "StartChatButton";
            this.StartChatButton.Size = new System.Drawing.Size(141, 23);
            this.StartChatButton.TabIndex = 2;
            this.StartChatButton.Text = "Создать чат";
            this.StartChatButton.UseVisualStyleBackColor = true;
            this.StartChatButton.Click += new System.EventHandler(this.StartChatButton_Click);
            // 
            // DeleteContact
            // 
            this.DeleteContact.Location = new System.Drawing.Point(263, 107);
            this.DeleteContact.Name = "DeleteContact";
            this.DeleteContact.Size = new System.Drawing.Size(141, 23);
            this.DeleteContact.TabIndex = 3;
            this.DeleteContact.Text = "Удалить контакт";
            this.DeleteContact.UseVisualStyleBackColor = true;
            this.DeleteContact.Click += new System.EventHandler(this.DeleteContact_Click);
            // 
            // CurrentUsername
            // 
            this.CurrentUsername.AutoSize = true;
            this.CurrentUsername.Location = new System.Drawing.Point(742, 12);
            this.CurrentUsername.Name = "CurrentUsername";
            this.CurrentUsername.Size = new System.Drawing.Size(35, 13);
            this.CurrentUsername.TabIndex = 4;
            this.CurrentUsername.Text = "label1";
            // 
            // Contacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentUsername);
            this.Controls.Add(this.DeleteContact);
            this.Controls.Add(this.StartChatButton);
            this.Controls.Add(this.contactsListBox);
            this.Controls.Add(this.addContactButton);
            this.Name = "Contacts";
            this.Text = "Contacts";
            this.Load += new System.EventHandler(this.Contacts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addContactButton;
        private System.Windows.Forms.ListBox contactsListBox;
        private System.Windows.Forms.Button StartChatButton;
        private System.Windows.Forms.Button DeleteContact;
        private System.Windows.Forms.Label CurrentUsername;
    }
}