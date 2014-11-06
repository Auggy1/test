namespace Project_Forms
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
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login Information";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(16, 35);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(58, 13);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "Username:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(16, 63);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(56, 13);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Personal Information";
            // 
            // firstname_label
            // 
            this.firstname_label.AutoSize = true;
            this.firstname_label.Location = new System.Drawing.Point(16, 124);
            this.firstname_label.Name = "firstname_label";
            this.firstname_label.Size = new System.Drawing.Size(60, 13);
            this.firstname_label.TabIndex = 4;
            this.firstname_label.Text = "First Name:";
            // 
            // lastname_label
            // 
            this.lastname_label.AutoSize = true;
            this.lastname_label.Location = new System.Drawing.Point(16, 150);
            this.lastname_label.Name = "lastname_label";
            this.lastname_label.Size = new System.Drawing.Size(61, 13);
            this.lastname_label.TabIndex = 5;
            this.lastname_label.Text = "Last Name:";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Location = new System.Drawing.Point(16, 176);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(35, 13);
            this.email_label.TabIndex = 6;
            this.email_label.Text = "Email:";
            // 
            // vemail_label
            // 
            this.vemail_label.AutoSize = true;
            this.vemail_label.Location = new System.Drawing.Point(16, 202);
            this.vemail_label.Name = "vemail_label";
            this.vemail_label.Size = new System.Drawing.Size(67, 13);
            this.vemail_label.TabIndex = 7;
            this.vemail_label.Text = "Verifty Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "( At least 5 characters )";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "( At least 6 characters )";
            // 
            // na_username
            // 
            this.na_username.Location = new System.Drawing.Point(83, 35);
            this.na_username.Name = "na_username";
            this.na_username.Size = new System.Drawing.Size(100, 20);
            this.na_username.TabIndex = 0;
            this.na_username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // na_firstname
            // 
            this.na_firstname.Location = new System.Drawing.Point(82, 124);
            this.na_firstname.Name = "na_firstname";
            this.na_firstname.Size = new System.Drawing.Size(100, 20);
            this.na_firstname.TabIndex = 2;
            // 
            // na_password
            // 
            this.na_password.Location = new System.Drawing.Point(82, 63);
            this.na_password.Name = "na_password";
            this.na_password.PasswordChar = '*';
            this.na_password.Size = new System.Drawing.Size(100, 20);
            this.na_password.TabIndex = 1;
            this.na_password.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // na_lastname
            // 
            this.na_lastname.Location = new System.Drawing.Point(83, 150);
            this.na_lastname.Name = "na_lastname";
            this.na_lastname.Size = new System.Drawing.Size(100, 20);
            this.na_lastname.TabIndex = 3;
            // 
            // na_email
            // 
            this.na_email.Location = new System.Drawing.Point(83, 176);
            this.na_email.Name = "na_email";
            this.na_email.Size = new System.Drawing.Size(188, 20);
            this.na_email.TabIndex = 4;
            // 
            // na_verifyemail
            // 
            this.na_verifyemail.Location = new System.Drawing.Point(83, 202);
            this.na_verifyemail.Name = "na_verifyemail";
            this.na_verifyemail.Size = new System.Drawing.Size(188, 20);
            this.na_verifyemail.TabIndex = 5;
            // 
            // na_cancel_btn
            // 
            this.na_cancel_btn.Location = new System.Drawing.Point(185, 232);
            this.na_cancel_btn.Name = "na_cancel_btn";
            this.na_cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.na_cancel_btn.TabIndex = 7;
            this.na_cancel_btn.Text = "Cancel";
            this.na_cancel_btn.UseVisualStyleBackColor = true;
            this.na_cancel_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // na_submit_btn
            // 
            this.na_submit_btn.Location = new System.Drawing.Point(12, 232);
            this.na_submit_btn.Name = "na_submit_btn";
            this.na_submit_btn.Size = new System.Drawing.Size(75, 23);
            this.na_submit_btn.TabIndex = 6;
            this.na_submit_btn.Text = "Submit";
            this.na_submit_btn.UseVisualStyleBackColor = true;
            this.na_submit_btn.Click += new System.EventHandler(this.button2_Click);
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
            this.admin_chkbox.Location = new System.Drawing.Point(296, 124);
            this.admin_chkbox.Name = "admin_chkbox";
            this.admin_chkbox.Size = new System.Drawing.Size(15, 14);
            this.admin_chkbox.TabIndex = 10;
            this.admin_chkbox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Make user Admin?";
            // 
            // New_Account
            // 
            this.AcceptButton = this.na_submit_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 263);
            this.Controls.Add(this.label11);
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
            this.Name = "New_Account";
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox admin_chkbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}