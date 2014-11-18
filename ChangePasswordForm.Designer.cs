namespace Project_Forms
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.change_pass_btn = new System.Windows.Forms.Button();
            this.old_password_label = new System.Windows.Forms.Label();
            this.new_password_label = new System.Windows.Forms.Label();
            this.verify_password_label = new System.Windows.Forms.Label();
            this.old_password_box = new System.Windows.Forms.TextBox();
            this.new_password_box = new System.Windows.Forms.TextBox();
            this.verify_password_box = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.password_error_msg = new System.Windows.Forms.Label();
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // change_pass_btn
            // 
            this.change_pass_btn.Enabled = false;
            this.change_pass_btn.Location = new System.Drawing.Point(85, 118);
            this.change_pass_btn.Name = "change_pass_btn";
            this.change_pass_btn.Size = new System.Drawing.Size(108, 23);
            this.change_pass_btn.TabIndex = 0;
            this.change_pass_btn.Text = "Change Passsword";
            this.change_pass_btn.UseVisualStyleBackColor = true;
            this.change_pass_btn.Click += new System.EventHandler(this.ChangePasswordClick);
            // 
            // old_password_label
            // 
            this.old_password_label.AutoSize = true;
            this.old_password_label.Location = new System.Drawing.Point(23, 20);
            this.old_password_label.Name = "old_password_label";
            this.old_password_label.Size = new System.Drawing.Size(100, 13);
            this.old_password_label.TabIndex = 1;
            this.old_password_label.Text = "Enter Old Password";
            // 
            // new_password_label
            // 
            this.new_password_label.AutoSize = true;
            this.new_password_label.Location = new System.Drawing.Point(23, 48);
            this.new_password_label.Name = "new_password_label";
            this.new_password_label.Size = new System.Drawing.Size(106, 13);
            this.new_password_label.TabIndex = 2;
            this.new_password_label.Text = "Enter New Password";
            // 
            // verify_password_label
            // 
            this.verify_password_label.AutoSize = true;
            this.verify_password_label.Location = new System.Drawing.Point(23, 74);
            this.verify_password_label.Name = "verify_password_label";
            this.verify_password_label.Size = new System.Drawing.Size(107, 13);
            this.verify_password_label.TabIndex = 3;
            this.verify_password_label.Text = "Verify New Password";
            // 
            // old_password_box
            // 
            this.old_password_box.Location = new System.Drawing.Point(158, 17);
            this.old_password_box.Name = "old_password_box";
            this.old_password_box.Size = new System.Drawing.Size(100, 20);
            this.old_password_box.TabIndex = 4;
            this.old_password_box.TextChanged += new System.EventHandler(this.OldPasswordChange);
            // 
            // new_password_box
            // 
            this.new_password_box.Enabled = false;
            this.new_password_box.Location = new System.Drawing.Point(158, 45);
            this.new_password_box.Name = "new_password_box";
            this.new_password_box.Size = new System.Drawing.Size(100, 20);
            this.new_password_box.TabIndex = 5;
            this.new_password_box.TextChanged += new System.EventHandler(this.NewPasswordChange);
            // 
            // verify_password_box
            // 
            this.verify_password_box.Enabled = false;
            this.verify_password_box.Location = new System.Drawing.Point(158, 71);
            this.verify_password_box.Name = "verify_password_box";
            this.verify_password_box.Size = new System.Drawing.Size(100, 20);
            this.verify_password_box.TabIndex = 6;
            this.verify_password_box.TextChanged += new System.EventHandler(this.VerifyPasswordChange);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // password_error_msg
            // 
            this.password_error_msg.AutoSize = true;
            this.password_error_msg.ForeColor = System.Drawing.Color.Red;
            this.password_error_msg.Location = new System.Drawing.Point(12, 102);
            this.password_error_msg.Name = "password_error_msg";
            this.password_error_msg.Size = new System.Drawing.Size(110, 13);
            this.password_error_msg.TabIndex = 7;
            this.password_error_msg.Text = "Password Input Errors";
            this.password_error_msg.Visible = false;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // ChangePasswordForm
            // 
            this.AcceptButton = this.change_pass_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 152);
            this.Controls.Add(this.password_error_msg);
            this.Controls.Add(this.verify_password_box);
            this.Controls.Add(this.new_password_box);
            this.Controls.Add(this.old_password_box);
            this.Controls.Add(this.verify_password_label);
            this.Controls.Add(this.new_password_label);
            this.Controls.Add(this.old_password_label);
            this.Controls.Add(this.change_pass_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button change_pass_btn;
        private System.Windows.Forms.Label old_password_label;
        private System.Windows.Forms.Label new_password_label;
        private System.Windows.Forms.Label verify_password_label;
        private System.Windows.Forms.TextBox old_password_box;
        private System.Windows.Forms.TextBox new_password_box;
        private System.Windows.Forms.TextBox verify_password_box;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label password_error_msg;
        private System.Windows.Forms.ErrorProvider errorProvider3;
    }
}