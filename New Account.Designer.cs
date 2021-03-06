﻿namespace Project_Forms
{
    partial class New_Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_Account));
            this.label1 = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.firstname_label = new System.Windows.Forms.Label();
            this.lastname_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.vemail_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.na_username = new System.Windows.Forms.TextBox();
            this.na_firstname = new System.Windows.Forms.TextBox();
            this.na_password = new System.Windows.Forms.TextBox();
            this.na_lastname = new System.Windows.Forms.TextBox();
            this.na_email = new System.Windows.Forms.TextBox();
            this.na_verifyemail = new System.Windows.Forms.TextBox();
            this.na_cancel_btn = new System.Windows.Forms.Button();
            this.na_submit_btn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.admin_chkbox = new System.Windows.Forms.CheckBox();
            this.make_admin_label = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.optional_label = new System.Windows.Forms.Label();
            this.optional_label_2 = new System.Windows.Forms.Label();
            this.na_error_msg_1 = new System.Windows.Forms.Label();
            this.na_error_msg_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login Information";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(21, 43);
            this.username_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(77, 17);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "Username:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(21, 78);
            this.password_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(73, 17);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Personal Information";
            // 
            // firstname_label
            // 
            this.firstname_label.AutoSize = true;
            this.firstname_label.Location = new System.Drawing.Point(21, 169);
            this.firstname_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstname_label.Name = "firstname_label";
            this.firstname_label.Size = new System.Drawing.Size(80, 17);
            this.firstname_label.TabIndex = 4;
            this.firstname_label.Text = "First Name:";
            // 
            // lastname_label
            // 
            this.lastname_label.AutoSize = true;
            this.lastname_label.Location = new System.Drawing.Point(21, 201);
            this.lastname_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastname_label.Name = "lastname_label";
            this.lastname_label.Size = new System.Drawing.Size(80, 17);
            this.lastname_label.TabIndex = 5;
            this.lastname_label.Text = "Last Name:";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Location = new System.Drawing.Point(21, 233);
            this.email_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(46, 17);
            this.email_label.TabIndex = 6;
            this.email_label.Text = "Email:";
            // 
            // vemail_label
            // 
            this.vemail_label.AutoSize = true;
            this.vemail_label.Location = new System.Drawing.Point(21, 265);
            this.vemail_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vemail_label.Name = "vemail_label";
            this.vemail_label.Size = new System.Drawing.Size(90, 17);
            this.vemail_label.TabIndex = 7;
            this.vemail_label.Text = "Verifty Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "( At least 5 characters )";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 86);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "( At least 6 characters )";
            // 
            // na_username
            // 
            this.na_username.Location = new System.Drawing.Point(111, 43);
            this.na_username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_username.Name = "na_username";
            this.na_username.Size = new System.Drawing.Size(132, 22);
            this.na_username.TabIndex = 0;
            this.toolTip1.SetToolTip(this.na_username, resources.GetString("na_username.ToolTip"));
            this.na_username.TextChanged += new System.EventHandler(this.UsernameBoxTextChange);
            // 
            // na_firstname
            // 
            this.na_firstname.Location = new System.Drawing.Point(109, 169);
            this.na_firstname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_firstname.Name = "na_firstname";
            this.na_firstname.Size = new System.Drawing.Size(132, 22);
            this.na_firstname.TabIndex = 2;
            this.na_firstname.TextChanged += new System.EventHandler(this.FirstNameTextChange);
            // 
            // na_password
            // 
            this.na_password.Location = new System.Drawing.Point(109, 78);
            this.na_password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_password.Name = "na_password";
            this.na_password.PasswordChar = '*';
            this.na_password.Size = new System.Drawing.Size(132, 22);
            this.na_password.TabIndex = 1;
            this.toolTip1.SetToolTip(this.na_password, resources.GetString("na_password.ToolTip"));
            this.na_password.TextChanged += new System.EventHandler(this.PasswordBoxTextChange);
            // 
            // na_lastname
            // 
            this.na_lastname.Location = new System.Drawing.Point(111, 201);
            this.na_lastname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_lastname.Name = "na_lastname";
            this.na_lastname.Size = new System.Drawing.Size(132, 22);
            this.na_lastname.TabIndex = 3;
            this.na_lastname.TextChanged += new System.EventHandler(this.LastNameTextChange);
            // 
            // na_email
            // 
            this.na_email.Location = new System.Drawing.Point(111, 233);
            this.na_email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_email.Name = "na_email";
            this.na_email.Size = new System.Drawing.Size(221, 22);
            this.na_email.TabIndex = 4;
            this.na_email.TextChanged += new System.EventHandler(this.EmailTextChange);
            // 
            // na_verifyemail
            // 
            this.na_verifyemail.Location = new System.Drawing.Point(111, 265);
            this.na_verifyemail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_verifyemail.Name = "na_verifyemail";
            this.na_verifyemail.Size = new System.Drawing.Size(221, 22);
            this.na_verifyemail.TabIndex = 5;
            this.na_verifyemail.TextChanged += new System.EventHandler(this.VerifyEmailTextChange);
            // 
            // na_cancel_btn
            // 
            this.na_cancel_btn.Location = new System.Drawing.Point(331, 322);
            this.na_cancel_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_cancel_btn.Name = "na_cancel_btn";
            this.na_cancel_btn.Size = new System.Drawing.Size(100, 28);
            this.na_cancel_btn.TabIndex = 7;
            this.na_cancel_btn.Text = "Cancel";
            this.na_cancel_btn.UseVisualStyleBackColor = true;
            this.na_cancel_btn.Click += new System.EventHandler(this.CancelClick);
            // 
            // na_submit_btn
            // 
            this.na_submit_btn.Enabled = false;
            this.na_submit_btn.Location = new System.Drawing.Point(16, 322);
            this.na_submit_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.na_submit_btn.Name = "na_submit_btn";
            this.na_submit_btn.Size = new System.Drawing.Size(100, 28);
            this.na_submit_btn.TabIndex = 6;
            this.na_submit_btn.Text = "Submit";
            this.na_submit_btn.UseVisualStyleBackColor = true;
            this.na_submit_btn.Click += new System.EventHandler(this.SubmitClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // admin_chkbox
            // 
            this.admin_chkbox.AutoSize = true;
            this.admin_chkbox.Location = new System.Drawing.Point(411, 169);
            this.admin_chkbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.admin_chkbox.Name = "admin_chkbox";
            this.admin_chkbox.Size = new System.Drawing.Size(18, 17);
            this.admin_chkbox.TabIndex = 10;
            this.admin_chkbox.UseVisualStyleBackColor = true;
            // 
            // make_admin_label
            // 
            this.make_admin_label.AutoSize = true;
            this.make_admin_label.Location = new System.Drawing.Point(341, 169);
            this.make_admin_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.make_admin_label.Name = "make_admin_label";
            this.make_admin_label.Size = new System.Drawing.Size(55, 17);
            this.make_admin_label.TabIndex = 11;
            this.make_admin_label.Text = "Admin?";
            // 
            // optional_label
            // 
            this.optional_label.AutoSize = true;
            this.optional_label.Location = new System.Drawing.Point(341, 236);
            this.optional_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.optional_label.Name = "optional_label";
            this.optional_label.Size = new System.Drawing.Size(71, 17);
            this.optional_label.TabIndex = 12;
            this.optional_label.Text = "(Optional)";
            // 
            // optional_label_2
            // 
            this.optional_label_2.AutoSize = true;
            this.optional_label_2.Location = new System.Drawing.Point(341, 268);
            this.optional_label_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.optional_label_2.Name = "optional_label_2";
            this.optional_label_2.Size = new System.Drawing.Size(71, 17);
            this.optional_label_2.TabIndex = 13;
            this.optional_label_2.Text = "(Optional)";
            // 
            // na_error_msg_1
            // 
            this.na_error_msg_1.AutoSize = true;
            this.na_error_msg_1.ForeColor = System.Drawing.Color.Red;
            this.na_error_msg_1.Location = new System.Drawing.Point(21, 116);
            this.na_error_msg_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.na_error_msg_1.Name = "na_error_msg_1";
            this.na_error_msg_1.Size = new System.Drawing.Size(187, 17);
            this.na_error_msg_1.TabIndex = 14;
            this.na_error_msg_1.Text = "username or password error";
            this.na_error_msg_1.Visible = false;
            // 
            // na_error_msg_2
            // 
            this.na_error_msg_2.AutoSize = true;
            this.na_error_msg_2.ForeColor = System.Drawing.Color.Red;
            this.na_error_msg_2.Location = new System.Drawing.Point(21, 292);
            this.na_error_msg_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.na_error_msg_2.Name = "na_error_msg_2";
            this.na_error_msg_2.Size = new System.Drawing.Size(232, 17);
            this.na_error_msg_2.TabIndex = 15;
            this.na_error_msg_2.Text = "first name, last name, or email error";
            this.na_error_msg_2.Visible = false;
            // 
            // New_Account
            // 
            this.AcceptButton = this.na_submit_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 366);
            this.Controls.Add(this.na_error_msg_2);
            this.Controls.Add(this.na_error_msg_1);
            this.Controls.Add(this.optional_label_2);
            this.Controls.Add(this.optional_label);
            this.Controls.Add(this.make_admin_label);
            this.Controls.Add(this.admin_chkbox);
            this.Controls.Add(this.na_submit_btn);
            this.Controls.Add(this.na_cancel_btn);
            this.Controls.Add(this.na_verifyemail);
            this.Controls.Add(this.na_email);
            this.Controls.Add(this.na_lastname);
            this.Controls.Add(this.na_password);
            this.Controls.Add(this.na_firstname);
            this.Controls.Add(this.na_username);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.vemail_label);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.lastname_label);
            this.Controls.Add(this.firstname_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "New_Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Account";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label firstname_label;
        private System.Windows.Forms.Label lastname_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label vemail_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox na_username;
        private System.Windows.Forms.TextBox na_firstname;
        private System.Windows.Forms.TextBox na_password;
        private System.Windows.Forms.TextBox na_lastname;
        private System.Windows.Forms.TextBox na_email;
        private System.Windows.Forms.TextBox na_verifyemail;
        private System.Windows.Forms.Button na_cancel_btn;
        private System.Windows.Forms.Button na_submit_btn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label make_admin_label;
        private System.Windows.Forms.CheckBox admin_chkbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label optional_label_2;
        private System.Windows.Forms.Label optional_label;
        private System.Windows.Forms.Label na_error_msg_2;
        private System.Windows.Forms.Label na_error_msg_1;
    }
}