namespace Project_Forms
{
    partial class Adminstration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adminstration));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.user_admin_err_msg = new System.Windows.Forms.Label();
            this.delete_user_label = new System.Windows.Forms.Label();
            this.delete_chkbox = new System.Windows.Forms.CheckBox();
            this.admin_user_dropdown = new System.Windows.Forms.ComboBox();
            this.admin_users_label = new System.Windows.Forms.Label();
            this.admin_user_submit_btm = new System.Windows.Forms.Button();
            this.lock_unlock_label = new System.Windows.Forms.Label();
            this.admin_label = new System.Windows.Forms.Label();
            this.make_admin_chkbox = new System.Windows.Forms.CheckBox();
            this.lock_unlock_chkbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.admin_new_cat_input = new System.Windows.Forms.TextBox();
            this.admin_cat_dropdown = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.admin_cat_delete_btn = new System.Windows.Forms.Button();
            this.admin_cat_rename_btn = new System.Windows.Forms.Button();
            this.admin_cat_add_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 335);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.user_admin_err_msg);
            this.tabPage1.Controls.Add(this.delete_user_label);
            this.tabPage1.Controls.Add(this.delete_chkbox);
            this.tabPage1.Controls.Add(this.admin_user_dropdown);
            this.tabPage1.Controls.Add(this.admin_users_label);
            this.tabPage1.Controls.Add(this.admin_user_submit_btm);
            this.tabPage1.Controls.Add(this.lock_unlock_label);
            this.tabPage1.Controls.Add(this.admin_label);
            this.tabPage1.Controls.Add(this.make_admin_chkbox);
            this.tabPage1.Controls.Add(this.lock_unlock_chkbox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // user_admin_err_msg
            // 
            this.user_admin_err_msg.AutoSize = true;
            this.user_admin_err_msg.ForeColor = System.Drawing.Color.Red;
            this.user_admin_err_msg.Location = new System.Drawing.Point(33, 123);
            this.user_admin_err_msg.Name = "user_admin_err_msg";
            this.user_admin_err_msg.Size = new System.Drawing.Size(35, 13);
            this.user_admin_err_msg.TabIndex = 18;
            this.user_admin_err_msg.Text = "label3";
            this.user_admin_err_msg.Visible = false;
            // 
            // delete_user_label
            // 
            this.delete_user_label.AutoSize = true;
            this.delete_user_label.Location = new System.Drawing.Point(342, 115);
            this.delete_user_label.Name = "delete_user_label";
            this.delete_user_label.Size = new System.Drawing.Size(63, 13);
            this.delete_user_label.TabIndex = 17;
            this.delete_user_label.Text = "Delete User";
            // 
            // delete_chkbox
            // 
            this.delete_chkbox.AutoSize = true;
            this.delete_chkbox.Location = new System.Drawing.Point(495, 115);
            this.delete_chkbox.Name = "delete_chkbox";
            this.delete_chkbox.Size = new System.Drawing.Size(15, 14);
            this.delete_chkbox.TabIndex = 16;
            this.delete_chkbox.UseVisualStyleBackColor = true;
            // 
            // admin_user_dropdown
            // 
            this.admin_user_dropdown.FormattingEnabled = true;
            this.admin_user_dropdown.Location = new System.Drawing.Point(87, 71);
            this.admin_user_dropdown.Name = "admin_user_dropdown";
            this.admin_user_dropdown.Size = new System.Drawing.Size(121, 21);
            this.admin_user_dropdown.TabIndex = 9;
            this.admin_user_dropdown.SelectedIndexChanged += new System.EventHandler(this.admin_user_dropdown_SelectedIndexChanged);
            // 
            // admin_users_label
            // 
            this.admin_users_label.AutoSize = true;
            this.admin_users_label.Location = new System.Drawing.Point(32, 71);
            this.admin_users_label.Name = "admin_users_label";
            this.admin_users_label.Size = new System.Drawing.Size(34, 13);
            this.admin_users_label.TabIndex = 8;
            this.admin_users_label.Text = "Users";
            // 
            // admin_user_submit_btm
            // 
            this.admin_user_submit_btm.Location = new System.Drawing.Point(380, 139);
            this.admin_user_submit_btm.Name = "admin_user_submit_btm";
            this.admin_user_submit_btm.Size = new System.Drawing.Size(100, 23);
            this.admin_user_submit_btm.TabIndex = 6;
            this.admin_user_submit_btm.Text = "Submit Changes";
            this.admin_user_submit_btm.UseVisualStyleBackColor = true;
            this.admin_user_submit_btm.Click += new System.EventHandler(this.button1_Click);
            // 
            // lock_unlock_label
            // 
            this.lock_unlock_label.AutoSize = true;
            this.lock_unlock_label.Location = new System.Drawing.Point(343, 88);
            this.lock_unlock_label.Name = "lock_unlock_label";
            this.lock_unlock_label.Size = new System.Drawing.Size(113, 13);
            this.lock_unlock_label.TabIndex = 5;
            this.lock_unlock_label.Text = "Lock/Unlock Account";
            // 
            // admin_label
            // 
            this.admin_label.AutoSize = true;
            this.admin_label.Location = new System.Drawing.Point(342, 62);
            this.admin_label.Name = "admin_label";
            this.admin_label.Size = new System.Drawing.Size(67, 13);
            this.admin_label.TabIndex = 4;
            this.admin_label.Text = "Administrator";
            // 
            // make_admin_chkbox
            // 
            this.make_admin_chkbox.AutoSize = true;
            this.make_admin_chkbox.Location = new System.Drawing.Point(494, 61);
            this.make_admin_chkbox.Name = "make_admin_chkbox";
            this.make_admin_chkbox.Size = new System.Drawing.Size(15, 14);
            this.make_admin_chkbox.TabIndex = 3;
            this.make_admin_chkbox.UseVisualStyleBackColor = true;
            // 
            // lock_unlock_chkbox
            // 
            this.lock_unlock_chkbox.AutoSize = true;
            this.lock_unlock_chkbox.Location = new System.Drawing.Point(495, 88);
            this.lock_unlock_chkbox.Name = "lock_unlock_chkbox";
            this.lock_unlock_chkbox.Size = new System.Drawing.Size(15, 14);
            this.lock_unlock_chkbox.TabIndex = 2;
            this.lock_unlock_chkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lock_unlock_chkbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a User to Edit";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.admin_new_cat_input);
            this.tabPage2.Controls.Add(this.admin_cat_dropdown);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.admin_cat_delete_btn);
            this.tabPage2.Controls.Add(this.admin_cat_rename_btn);
            this.tabPage2.Controls.Add(this.admin_cat_add_btn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(536, 309);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Categories";
            this.tabPage2.ToolTipText = "Choose a category to Add/Rename/Delete";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Category to add:";
            // 
            // admin_new_cat_input
            // 
            this.admin_new_cat_input.Location = new System.Drawing.Point(124, 82);
            this.admin_new_cat_input.Name = "admin_new_cat_input";
            this.admin_new_cat_input.Size = new System.Drawing.Size(100, 20);
            this.admin_new_cat_input.TabIndex = 11;
            // 
            // admin_cat_dropdown
            // 
            this.admin_cat_dropdown.FormattingEnabled = true;
            this.admin_cat_dropdown.Location = new System.Drawing.Point(371, 81);
            this.admin_cat_dropdown.Name = "admin_cat_dropdown";
            this.admin_cat_dropdown.Size = new System.Drawing.Size(121, 21);
            this.admin_cat_dropdown.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(417, 204);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Submit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(126, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Enter the new name of the category:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(311, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Categories";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(167, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Category Administration";
            // 
            // admin_cat_delete_btn
            // 
            this.admin_cat_delete_btn.Location = new System.Drawing.Point(417, 142);
            this.admin_cat_delete_btn.Name = "admin_cat_delete_btn";
            this.admin_cat_delete_btn.Size = new System.Drawing.Size(75, 23);
            this.admin_cat_delete_btn.TabIndex = 2;
            this.admin_cat_delete_btn.Text = "Delete";
            this.admin_cat_delete_btn.UseVisualStyleBackColor = true;
            this.admin_cat_delete_btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // admin_cat_rename_btn
            // 
            this.admin_cat_rename_btn.Location = new System.Drawing.Point(310, 142);
            this.admin_cat_rename_btn.Name = "admin_cat_rename_btn";
            this.admin_cat_rename_btn.Size = new System.Drawing.Size(75, 23);
            this.admin_cat_rename_btn.TabIndex = 1;
            this.admin_cat_rename_btn.Text = " Rename";
            this.admin_cat_rename_btn.UseVisualStyleBackColor = true;
            this.admin_cat_rename_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // admin_cat_add_btn
            // 
            this.admin_cat_add_btn.Location = new System.Drawing.Point(33, 142);
            this.admin_cat_add_btn.Name = "admin_cat_add_btn";
            this.admin_cat_add_btn.Size = new System.Drawing.Size(75, 23);
            this.admin_cat_add_btn.TabIndex = 0;
            this.admin_cat_add_btn.Text = "Add";
            this.admin_cat_add_btn.UseVisualStyleBackColor = true;
            this.admin_cat_add_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Adminstration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 374);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Adminstration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adminstration Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label admin_users_label;
        private System.Windows.Forms.Button admin_user_submit_btm;
        private System.Windows.Forms.Label lock_unlock_label;
        private System.Windows.Forms.Label admin_label;
        private System.Windows.Forms.CheckBox make_admin_chkbox;
        private System.Windows.Forms.CheckBox lock_unlock_chkbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button admin_cat_delete_btn;
        private System.Windows.Forms.Button admin_cat_rename_btn;
        private System.Windows.Forms.Button admin_cat_add_btn;
        private System.Windows.Forms.ComboBox admin_user_dropdown;
        private System.Windows.Forms.Label delete_user_label;
        private System.Windows.Forms.CheckBox delete_chkbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox admin_cat_dropdown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox admin_new_cat_input;
        private System.Windows.Forms.Label user_admin_err_msg;
    }
}