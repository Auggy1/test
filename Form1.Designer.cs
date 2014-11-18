namespace Project_Forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.date_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.time_stamp = new System.Windows.Forms.Label();
            this.tab_control = new System.Windows.Forms.TabControl();
            this.home_tab = new System.Windows.Forms.TabPage();
            this.home_user_details = new System.Windows.Forms.RichTextBox();
            this.welcome_msg = new System.Windows.Forms.Label();
            this.home_logo = new System.Windows.Forms.PictureBox();
            this.ee_tab = new System.Windows.Forms.TabPage();
            this.ee_success_message = new System.Windows.Forms.Label();
            this.expense_error_msg = new System.Windows.Forms.Label();
            this.save_expense_btn = new System.Windows.Forms.Button();
            this.ee_category_list = new System.Windows.Forms.ComboBox();
            this.ee_expense_input = new System.Windows.Forms.TextBox();
            this.ee_comment_box = new System.Windows.Forms.RichTextBox();
            this.ee_date_picker = new System.Windows.Forms.DateTimePicker();
            this.ee_date_label = new System.Windows.Forms.Label();
            this.ee_comments_label = new System.Windows.Forms.Label();
            this.ee_label = new System.Windows.Forms.Label();
            this.ee_category_label = new System.Windows.Forms.Label();
            this.vr_tab = new System.Windows.Forms.TabPage();
            this.vr_error_msg = new System.Windows.Forms.Label();
            this.vr_mileage_total = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.vr_report_label = new System.Windows.Forms.Label();
            this.detailed_report_btn = new System.Windows.Forms.Button();
            this.export_btn = new System.Windows.Forms.Button();
            this.vr_mon_total = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.vr_grid = new System.Windows.Forms.DataGridView();
            this.dateHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenseHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vr_end_date_picker = new System.Windows.Forms.DateTimePicker();
            this.vr_start_date_picker = new System.Windows.Forms.DateTimePicker();
            this.view_reports_btn = new System.Windows.Forms.Button();
            this.vr_category_list = new System.Windows.Forms.ComboBox();
            this.vr_start_date = new System.Windows.Forms.Label();
            this.vr_end_date = new System.Windows.Forms.Label();
            this.vr_categories = new System.Windows.Forms.Label();
            this.vh_tab = new System.Windows.Forms.TabPage();
            this.vh_error_msg = new System.Windows.Forms.Label();
            this.vh_start_date_picker = new System.Windows.Forms.DateTimePicker();
            this.vh_grid = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.vh_user_list = new System.Windows.Forms.ComboBox();
            this.vh_end_date_picker = new System.Windows.Forms.DateTimePicker();
            this.vh_search_btn = new System.Windows.Forms.Button();
            this.vh_category_list = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.admin_tab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.add_user_btn = new System.Windows.Forms.Button();
            this.user_admin_label = new System.Windows.Forms.Label();
            this.delete_user_label = new System.Windows.Forms.Label();
            this.delete_chkbox = new System.Windows.Forms.CheckBox();
            this.admin_user_submit_btn = new System.Windows.Forms.Button();
            this.lock_unlock_label = new System.Windows.Forms.Label();
            this.admin_label = new System.Windows.Forms.Label();
            this.make_admin_chkbox = new System.Windows.Forms.CheckBox();
            this.lock_unlock_chkbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.admin_user_dropdown = new System.Windows.Forms.ComboBox();
            this.admin_users_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.admin_cat_newname = new System.Windows.Forms.TextBox();
            this.admin_cat_name_label = new System.Windows.Forms.Label();
            this.admin_cat_dropdown = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.admin_cat_delete_btn = new System.Windows.Forms.Button();
            this.admin_cat_rename_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.admin_new_cat_input = new System.Windows.Forms.TextBox();
            this.admin_cat_add_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.menuStrip1.SuspendLayout();
            this.tab_control.SuspendLayout();
            this.home_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.home_logo)).BeginInit();
            this.ee_tab.SuspendLayout();
            this.vr_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vr_grid)).BeginInit();
            this.vh_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vh_grid)).BeginInit();
            this.admin_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Location = new System.Drawing.Point(15, 423);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(30, 13);
            this.date_label.TabIndex = 0;
            this.date_label.Text = "Date";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.LogoutClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitProgramClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // applicationHelpToolStripMenuItem
            // 
            this.applicationHelpToolStripMenuItem.Name = "applicationHelpToolStripMenuItem";
            this.applicationHelpToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.applicationHelpToolStripMenuItem.Text = "Application Help";
            this.applicationHelpToolStripMenuItem.Click += new System.EventHandler(this.HelpClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationInfoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // applicationInfoToolStripMenuItem
            // 
            this.applicationInfoToolStripMenuItem.Name = "applicationInfoToolStripMenuItem";
            this.applicationInfoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.applicationInfoToolStripMenuItem.Text = "Application Info";
            this.applicationInfoToolStripMenuItem.Click += new System.EventHandler(this.AboutClick);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Options";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordOptionSelected);
            // 
            // time_stamp
            // 
            this.time_stamp.AutoSize = true;
            this.time_stamp.Location = new System.Drawing.Point(672, 423);
            this.time_stamp.Name = "time_stamp";
            this.time_stamp.Size = new System.Drawing.Size(63, 13);
            this.time_stamp.TabIndex = 11;
            this.time_stamp.Text = "Time Stamp";
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.home_tab);
            this.tab_control.Controls.Add(this.ee_tab);
            this.tab_control.Controls.Add(this.vr_tab);
            this.tab_control.Controls.Add(this.vh_tab);
            this.tab_control.Controls.Add(this.admin_tab);
            this.tab_control.Location = new System.Drawing.Point(12, 27);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(727, 393);
            this.tab_control.TabIndex = 1;
            // 
            // home_tab
            // 
            this.home_tab.Controls.Add(this.home_user_details);
            this.home_tab.Controls.Add(this.welcome_msg);
            this.home_tab.Controls.Add(this.home_logo);
            this.home_tab.Location = new System.Drawing.Point(4, 22);
            this.home_tab.Name = "home_tab";
            this.home_tab.Padding = new System.Windows.Forms.Padding(3);
            this.home_tab.Size = new System.Drawing.Size(719, 367);
            this.home_tab.TabIndex = 0;
            this.home_tab.Text = "Home";
            this.home_tab.UseVisualStyleBackColor = true;
            // 
            // home_user_details
            // 
            this.home_user_details.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_user_details.Location = new System.Drawing.Point(6, 251);
            this.home_user_details.Name = "home_user_details";
            this.home_user_details.ReadOnly = true;
            this.home_user_details.Size = new System.Drawing.Size(296, 108);
            this.home_user_details.TabIndex = 7;
            this.home_user_details.TabStop = false;
            this.home_user_details.Text = "Venture Business Management";
            // 
            // welcome_msg
            // 
            this.welcome_msg.AutoSize = true;
            this.welcome_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_msg.Location = new System.Drawing.Point(395, 81);
            this.welcome_msg.Name = "welcome_msg";
            this.welcome_msg.Size = new System.Drawing.Size(188, 24);
            this.welcome_msg.TabIndex = 1;
            this.welcome_msg.Text = "Welcome Message";
            // 
            // home_logo
            // 
            this.home_logo.Image = ((System.Drawing.Image)(resources.GetObject("home_logo.Image")));
            this.home_logo.Location = new System.Drawing.Point(6, 6);
            this.home_logo.Name = "home_logo";
            this.home_logo.Size = new System.Drawing.Size(296, 239);
            this.home_logo.TabIndex = 15;
            this.home_logo.TabStop = false;
            // 
            // ee_tab
            // 
            this.ee_tab.Controls.Add(this.ee_success_message);
            this.ee_tab.Controls.Add(this.expense_error_msg);
            this.ee_tab.Controls.Add(this.save_expense_btn);
            this.ee_tab.Controls.Add(this.ee_category_list);
            this.ee_tab.Controls.Add(this.ee_expense_input);
            this.ee_tab.Controls.Add(this.ee_comment_box);
            this.ee_tab.Controls.Add(this.ee_date_picker);
            this.ee_tab.Controls.Add(this.ee_date_label);
            this.ee_tab.Controls.Add(this.ee_comments_label);
            this.ee_tab.Controls.Add(this.ee_label);
            this.ee_tab.Controls.Add(this.ee_category_label);
            this.ee_tab.Location = new System.Drawing.Point(4, 22);
            this.ee_tab.Name = "ee_tab";
            this.ee_tab.Padding = new System.Windows.Forms.Padding(3);
            this.ee_tab.Size = new System.Drawing.Size(719, 367);
            this.ee_tab.TabIndex = 1;
            this.ee_tab.Text = "Enter Expense";
            this.ee_tab.UseVisualStyleBackColor = true;
            // 
            // ee_success_message
            // 
            this.ee_success_message.AutoSize = true;
            this.ee_success_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ee_success_message.ForeColor = System.Drawing.Color.LimeGreen;
            this.ee_success_message.Location = new System.Drawing.Point(199, 274);
            this.ee_success_message.Name = "ee_success_message";
            this.ee_success_message.Size = new System.Drawing.Size(109, 13);
            this.ee_success_message.TabIndex = 19;
            this.ee_success_message.Text = "Success Message";
            this.ee_success_message.Visible = false;
            // 
            // expense_error_msg
            // 
            this.expense_error_msg.AutoSize = true;
            this.expense_error_msg.ForeColor = System.Drawing.Color.Red;
            this.expense_error_msg.Location = new System.Drawing.Point(199, 251);
            this.expense_error_msg.Name = "expense_error_msg";
            this.expense_error_msg.Size = new System.Drawing.Size(101, 13);
            this.expense_error_msg.TabIndex = 18;
            this.expense_error_msg.Text = "Enter Expense Error";
            // 
            // save_expense_btn
            // 
            this.save_expense_btn.Location = new System.Drawing.Point(434, 207);
            this.save_expense_btn.Name = "save_expense_btn";
            this.save_expense_btn.Size = new System.Drawing.Size(104, 23);
            this.save_expense_btn.TabIndex = 4;
            this.save_expense_btn.Text = "Save Expense";
            this.save_expense_btn.UseVisualStyleBackColor = true;
            this.save_expense_btn.Click += new System.EventHandler(this.EnterExpenseClick);
            // 
            // ee_category_list
            // 
            this.ee_category_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ee_category_list.FormattingEnabled = true;
            this.ee_category_list.Location = new System.Drawing.Point(202, 60);
            this.ee_category_list.Name = "ee_category_list";
            this.ee_category_list.Size = new System.Drawing.Size(187, 21);
            this.ee_category_list.Sorted = true;
            this.ee_category_list.TabIndex = 0;
            // 
            // ee_expense_input
            // 
            this.ee_expense_input.Location = new System.Drawing.Point(202, 92);
            this.ee_expense_input.MaxLength = 6;
            this.ee_expense_input.Name = "ee_expense_input";
            this.ee_expense_input.Size = new System.Drawing.Size(187, 20);
            this.ee_expense_input.TabIndex = 1;
            this.ee_expense_input.TextChanged += new System.EventHandler(this.ExpenseEntryTextChanged);
            this.ee_expense_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExpenseEntryKeyPress);
            // 
            // ee_comment_box
            // 
            this.ee_comment_box.Location = new System.Drawing.Point(202, 147);
            this.ee_comment_box.Name = "ee_comment_box";
            this.ee_comment_box.Size = new System.Drawing.Size(187, 83);
            this.ee_comment_box.TabIndex = 3;
            this.ee_comment_box.Text = "";
            // 
            // ee_date_picker
            // 
            this.ee_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ee_date_picker.Location = new System.Drawing.Point(202, 121);
            this.ee_date_picker.Name = "ee_date_picker";
            this.ee_date_picker.Size = new System.Drawing.Size(106, 20);
            this.ee_date_picker.TabIndex = 2;
            // 
            // ee_date_label
            // 
            this.ee_date_label.AutoSize = true;
            this.ee_date_label.Location = new System.Drawing.Point(105, 121);
            this.ee_date_label.Name = "ee_date_label";
            this.ee_date_label.Size = new System.Drawing.Size(30, 13);
            this.ee_date_label.TabIndex = 17;
            this.ee_date_label.Text = "Date";
            // 
            // ee_comments_label
            // 
            this.ee_comments_label.AutoSize = true;
            this.ee_comments_label.Location = new System.Drawing.Point(105, 147);
            this.ee_comments_label.Name = "ee_comments_label";
            this.ee_comments_label.Size = new System.Drawing.Size(56, 13);
            this.ee_comments_label.TabIndex = 16;
            this.ee_comments_label.Text = "Comments";
            // 
            // ee_label
            // 
            this.ee_label.AutoSize = true;
            this.ee_label.Location = new System.Drawing.Point(105, 92);
            this.ee_label.Name = "ee_label";
            this.ee_label.Size = new System.Drawing.Size(91, 13);
            this.ee_label.TabIndex = 9;
            this.ee_label.Text = "Enter Expenditure";
            // 
            // ee_category_label
            // 
            this.ee_category_label.AutoSize = true;
            this.ee_category_label.Location = new System.Drawing.Point(105, 63);
            this.ee_category_label.Name = "ee_category_label";
            this.ee_category_label.Size = new System.Drawing.Size(49, 13);
            this.ee_category_label.TabIndex = 8;
            this.ee_category_label.Text = "Category";
            // 
            // vr_tab
            // 
            this.vr_tab.Controls.Add(this.vr_error_msg);
            this.vr_tab.Controls.Add(this.vr_mileage_total);
            this.vr_tab.Controls.Add(this.label22);
            this.vr_tab.Controls.Add(this.vr_report_label);
            this.vr_tab.Controls.Add(this.detailed_report_btn);
            this.vr_tab.Controls.Add(this.export_btn);
            this.vr_tab.Controls.Add(this.vr_mon_total);
            this.vr_tab.Controls.Add(this.label11);
            this.vr_tab.Controls.Add(this.vr_grid);
            this.vr_tab.Controls.Add(this.vr_end_date_picker);
            this.vr_tab.Controls.Add(this.vr_start_date_picker);
            this.vr_tab.Controls.Add(this.view_reports_btn);
            this.vr_tab.Controls.Add(this.vr_category_list);
            this.vr_tab.Controls.Add(this.vr_start_date);
            this.vr_tab.Controls.Add(this.vr_end_date);
            this.vr_tab.Controls.Add(this.vr_categories);
            this.vr_tab.Location = new System.Drawing.Point(4, 22);
            this.vr_tab.Name = "vr_tab";
            this.vr_tab.Padding = new System.Windows.Forms.Padding(3);
            this.vr_tab.Size = new System.Drawing.Size(719, 367);
            this.vr_tab.TabIndex = 2;
            this.vr_tab.Text = "View Reports";
            this.vr_tab.UseVisualStyleBackColor = true;
            // 
            // vr_error_msg
            // 
            this.vr_error_msg.AutoSize = true;
            this.vr_error_msg.ForeColor = System.Drawing.Color.Red;
            this.vr_error_msg.Location = new System.Drawing.Point(25, 192);
            this.vr_error_msg.Name = "vr_error_msg";
            this.vr_error_msg.Size = new System.Drawing.Size(100, 13);
            this.vr_error_msg.TabIndex = 36;
            this.vr_error_msg.Text = "View Reports Errors";
            this.vr_error_msg.Visible = false;
            // 
            // vr_mileage_total
            // 
            this.vr_mileage_total.AutoSize = true;
            this.vr_mileage_total.Location = new System.Drawing.Point(651, 347);
            this.vr_mileage_total.Name = "vr_mileage_total";
            this.vr_mileage_total.Size = new System.Drawing.Size(26, 13);
            this.vr_mileage_total.TabIndex = 35;
            this.vr_mileage_total.Text = "0 mi";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(581, 347);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "Mileage:";
            // 
            // vr_report_label
            // 
            this.vr_report_label.AutoSize = true;
            this.vr_report_label.Location = new System.Drawing.Point(411, 3);
            this.vr_report_label.Name = "vr_report_label";
            this.vr_report_label.Size = new System.Drawing.Size(62, 13);
            this.vr_report_label.TabIndex = 33;
            this.vr_report_label.Text = "Report Title";
            // 
            // detailed_report_btn
            // 
            this.detailed_report_btn.Enabled = false;
            this.detailed_report_btn.Location = new System.Drawing.Point(60, 254);
            this.detailed_report_btn.Name = "detailed_report_btn";
            this.detailed_report_btn.Size = new System.Drawing.Size(95, 23);
            this.detailed_report_btn.TabIndex = 32;
            this.detailed_report_btn.Text = "Detailed Report";
            this.detailed_report_btn.UseVisualStyleBackColor = true;
            this.detailed_report_btn.Click += new System.EventHandler(this.ViewDetailedClick);
            // 
            // export_btn
            // 
            this.export_btn.Enabled = false;
            this.export_btn.Location = new System.Drawing.Point(60, 283);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(95, 23);
            this.export_btn.TabIndex = 31;
            this.export_btn.Text = "Export to Excel";
            this.export_btn.UseVisualStyleBackColor = true;
            this.export_btn.Click += new System.EventHandler(this.ExportClick);
            // 
            // vr_mon_total
            // 
            this.vr_mon_total.AutoSize = true;
            this.vr_mon_total.Location = new System.Drawing.Point(309, 347);
            this.vr_mon_total.Name = "vr_mon_total";
            this.vr_mon_total.Size = new System.Drawing.Size(34, 13);
            this.vr_mon_total.TabIndex = 30;
            this.vr_mon_total.Text = "$0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Total:";
            // 
            // vr_grid
            // 
            this.vr_grid.AllowUserToAddRows = false;
            this.vr_grid.AllowUserToDeleteRows = false;
            this.vr_grid.AllowUserToResizeColumns = false;
            this.vr_grid.AllowUserToResizeRows = false;
            this.vr_grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.vr_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vr_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateHeader,
            this.expenseHeader,
            this.categoryHeader,
            this.usersHeader,
            this.commentsHeader});
            this.vr_grid.Location = new System.Drawing.Point(197, 18);
            this.vr_grid.Name = "vr_grid";
            this.vr_grid.RowHeadersWidth = 4;
            this.vr_grid.Size = new System.Drawing.Size(505, 325);
            this.vr_grid.TabIndex = 28;
            // 
            // dateHeader
            // 
            this.dateHeader.HeaderText = "Date";
            this.dateHeader.Name = "dateHeader";
            this.dateHeader.ReadOnly = true;
            this.dateHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // expenseHeader
            // 
            this.expenseHeader.HeaderText = "Expense";
            this.expenseHeader.Name = "expenseHeader";
            this.expenseHeader.ReadOnly = true;
            this.expenseHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // categoryHeader
            // 
            this.categoryHeader.HeaderText = "Category";
            this.categoryHeader.Name = "categoryHeader";
            this.categoryHeader.ReadOnly = true;
            this.categoryHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // usersHeader
            // 
            this.usersHeader.HeaderText = "Submitted By:";
            this.usersHeader.Name = "usersHeader";
            this.usersHeader.ReadOnly = true;
            this.usersHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // commentsHeader
            // 
            this.commentsHeader.HeaderText = "Comments";
            this.commentsHeader.Name = "commentsHeader";
            this.commentsHeader.ReadOnly = true;
            this.commentsHeader.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // vr_end_date_picker
            // 
            this.vr_end_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.vr_end_date_picker.Location = new System.Drawing.Point(28, 108);
            this.vr_end_date_picker.Name = "vr_end_date_picker";
            this.vr_end_date_picker.Size = new System.Drawing.Size(127, 20);
            this.vr_end_date_picker.TabIndex = 27;
            // 
            // vr_start_date_picker
            // 
            this.vr_start_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.vr_start_date_picker.Location = new System.Drawing.Point(28, 57);
            this.vr_start_date_picker.Name = "vr_start_date_picker";
            this.vr_start_date_picker.Size = new System.Drawing.Size(127, 20);
            this.vr_start_date_picker.TabIndex = 26;
            this.vr_start_date_picker.ValueChanged += new System.EventHandler(this.VRStartDateChange);
            // 
            // view_reports_btn
            // 
            this.view_reports_btn.Enabled = false;
            this.view_reports_btn.Location = new System.Drawing.Point(60, 225);
            this.view_reports_btn.Name = "view_reports_btn";
            this.view_reports_btn.Size = new System.Drawing.Size(95, 23);
            this.view_reports_btn.TabIndex = 24;
            this.view_reports_btn.Text = "View Reports";
            this.view_reports_btn.UseVisualStyleBackColor = true;
            this.view_reports_btn.Click += new System.EventHandler(this.ViewSummaryClick);
            // 
            // vr_category_list
            // 
            this.vr_category_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vr_category_list.FormattingEnabled = true;
            this.vr_category_list.Location = new System.Drawing.Point(28, 158);
            this.vr_category_list.Name = "vr_category_list";
            this.vr_category_list.Size = new System.Drawing.Size(127, 21);
            this.vr_category_list.TabIndex = 23;
            this.vr_category_list.SelectedIndexChanged += new System.EventHandler(this.VrCategorySelected);
            // 
            // vr_start_date
            // 
            this.vr_start_date.AutoSize = true;
            this.vr_start_date.Location = new System.Drawing.Point(25, 41);
            this.vr_start_date.Name = "vr_start_date";
            this.vr_start_date.Size = new System.Drawing.Size(55, 13);
            this.vr_start_date.TabIndex = 21;
            this.vr_start_date.Text = "Start Date";
            // 
            // vr_end_date
            // 
            this.vr_end_date.AutoSize = true;
            this.vr_end_date.Location = new System.Drawing.Point(25, 92);
            this.vr_end_date.Name = "vr_end_date";
            this.vr_end_date.Size = new System.Drawing.Size(52, 13);
            this.vr_end_date.TabIndex = 20;
            this.vr_end_date.Text = "End Date";
            // 
            // vr_categories
            // 
            this.vr_categories.AutoSize = true;
            this.vr_categories.Location = new System.Drawing.Point(25, 142);
            this.vr_categories.Name = "vr_categories";
            this.vr_categories.Size = new System.Drawing.Size(57, 13);
            this.vr_categories.TabIndex = 19;
            this.vr_categories.Text = "Categories";
            // 
            // vh_tab
            // 
            this.vh_tab.Controls.Add(this.vh_error_msg);
            this.vh_tab.Controls.Add(this.vh_start_date_picker);
            this.vh_tab.Controls.Add(this.vh_grid);
            this.vh_tab.Controls.Add(this.label17);
            this.vh_tab.Controls.Add(this.vh_user_list);
            this.vh_tab.Controls.Add(this.vh_end_date_picker);
            this.vh_tab.Controls.Add(this.vh_search_btn);
            this.vh_tab.Controls.Add(this.vh_category_list);
            this.vh_tab.Controls.Add(this.label19);
            this.vh_tab.Controls.Add(this.label20);
            this.vh_tab.Controls.Add(this.label21);
            this.vh_tab.Location = new System.Drawing.Point(4, 22);
            this.vh_tab.Name = "vh_tab";
            this.vh_tab.Padding = new System.Windows.Forms.Padding(3);
            this.vh_tab.Size = new System.Drawing.Size(719, 367);
            this.vh_tab.TabIndex = 3;
            this.vh_tab.Text = "View History";
            this.vh_tab.UseVisualStyleBackColor = true;
            // 
            // vh_error_msg
            // 
            this.vh_error_msg.AutoSize = true;
            this.vh_error_msg.ForeColor = System.Drawing.Color.Red;
            this.vh_error_msg.Location = new System.Drawing.Point(53, 280);
            this.vh_error_msg.Name = "vh_error_msg";
            this.vh_error_msg.Size = new System.Drawing.Size(90, 13);
            this.vh_error_msg.TabIndex = 45;
            this.vh_error_msg.Text = "View History Error";
            this.vh_error_msg.Visible = false;
            // 
            // vh_start_date_picker
            // 
            this.vh_start_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.vh_start_date_picker.Location = new System.Drawing.Point(114, 82);
            this.vh_start_date_picker.Name = "vh_start_date_picker";
            this.vh_start_date_picker.Size = new System.Drawing.Size(135, 20);
            this.vh_start_date_picker.TabIndex = 44;
            this.vh_start_date_picker.ValueChanged += new System.EventHandler(this.VHStartDateChange);
            // 
            // vh_grid
            // 
            this.vh_grid.AllowUserToAddRows = false;
            this.vh_grid.AllowUserToDeleteRows = false;
            this.vh_grid.AllowUserToResizeColumns = false;
            this.vh_grid.AllowUserToResizeRows = false;
            this.vh_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vh_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.Expense,
            this.name,
            this.User});
            this.vh_grid.Location = new System.Drawing.Point(306, 6);
            this.vh_grid.Name = "vh_grid";
            this.vh_grid.ReadOnly = true;
            this.vh_grid.RowHeadersWidth = 4;
            this.vh_grid.Size = new System.Drawing.Size(407, 337);
            this.vh_grid.TabIndex = 43;
            // 
            // Category
            // 
            this.Category.HeaderText = "Date";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Expense
            // 
            this.Expense.HeaderText = "Expense";
            this.Expense.Name = "Expense";
            this.Expense.ReadOnly = true;
            this.Expense.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // name
            // 
            this.name.HeaderText = "Category";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // User
            // 
            this.User.HeaderText = "Added By";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(53, 166);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "User";
            // 
            // vh_user_list
            // 
            this.vh_user_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vh_user_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vh_user_list.FormattingEnabled = true;
            this.vh_user_list.Location = new System.Drawing.Point(151, 163);
            this.vh_user_list.Name = "vh_user_list";
            this.vh_user_list.Size = new System.Drawing.Size(98, 21);
            this.vh_user_list.TabIndex = 41;
            // 
            // vh_end_date_picker
            // 
            this.vh_end_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.vh_end_date_picker.Location = new System.Drawing.Point(114, 121);
            this.vh_end_date_picker.Name = "vh_end_date_picker";
            this.vh_end_date_picker.Size = new System.Drawing.Size(135, 20);
            this.vh_end_date_picker.TabIndex = 40;
            // 
            // vh_search_btn
            // 
            this.vh_search_btn.Enabled = false;
            this.vh_search_btn.Location = new System.Drawing.Point(151, 233);
            this.vh_search_btn.Name = "vh_search_btn";
            this.vh_search_btn.Size = new System.Drawing.Size(98, 25);
            this.vh_search_btn.TabIndex = 38;
            this.vh_search_btn.Text = "Search";
            this.vh_search_btn.UseVisualStyleBackColor = true;
            this.vh_search_btn.Click += new System.EventHandler(this.ViewHistoryClick);
            // 
            // vh_category_list
            // 
            this.vh_category_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vh_category_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vh_category_list.FormattingEnabled = true;
            this.vh_category_list.Location = new System.Drawing.Point(151, 196);
            this.vh_category_list.Name = "vh_category_list";
            this.vh_category_list.Size = new System.Drawing.Size(98, 21);
            this.vh_category_list.TabIndex = 37;
            this.vh_category_list.SelectedIndexChanged += new System.EventHandler(this.VhCatergorySelected);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(53, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Start Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(52, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "End Date";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(53, 199);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 13);
            this.label21.TabIndex = 33;
            this.label21.Text = "Categories";
            // 
            // admin_tab
            // 
            this.admin_tab.Controls.Add(this.splitContainer1);
            this.admin_tab.Location = new System.Drawing.Point(4, 22);
            this.admin_tab.Name = "admin_tab";
            this.admin_tab.Padding = new System.Windows.Forms.Padding(3);
            this.admin_tab.Size = new System.Drawing.Size(719, 367);
            this.admin_tab.TabIndex = 4;
            this.admin_tab.Text = "Administration";
            this.admin_tab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.add_user_btn);
            this.splitContainer1.Panel1.Controls.Add(this.user_admin_label);
            this.splitContainer1.Panel1.Controls.Add(this.delete_user_label);
            this.splitContainer1.Panel1.Controls.Add(this.delete_chkbox);
            this.splitContainer1.Panel1.Controls.Add(this.admin_user_submit_btn);
            this.splitContainer1.Panel1.Controls.Add(this.lock_unlock_label);
            this.splitContainer1.Panel1.Controls.Add(this.admin_label);
            this.splitContainer1.Panel1.Controls.Add(this.make_admin_chkbox);
            this.splitContainer1.Panel1.Controls.Add(this.lock_unlock_chkbox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.admin_user_dropdown);
            this.splitContainer1.Panel1.Controls.Add(this.admin_users_label);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.admin_cat_newname);
            this.splitContainer1.Panel2.Controls.Add(this.admin_cat_name_label);
            this.splitContainer1.Panel2.Controls.Add(this.admin_cat_dropdown);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.admin_cat_delete_btn);
            this.splitContainer1.Panel2.Controls.Add(this.admin_cat_rename_btn);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.admin_new_cat_input);
            this.splitContainer1.Panel2.Controls.Add(this.admin_cat_add_btn);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Size = new System.Drawing.Size(713, 361);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 0;
            // 
            // add_user_btn
            // 
            this.add_user_btn.Location = new System.Drawing.Point(129, 65);
            this.add_user_btn.Name = "add_user_btn";
            this.add_user_btn.Size = new System.Drawing.Size(75, 23);
            this.add_user_btn.TabIndex = 31;
            this.add_user_btn.Text = "Add User";
            this.add_user_btn.UseVisualStyleBackColor = true;
            this.add_user_btn.Click += new System.EventHandler(this.AddUserClick);
            // 
            // user_admin_label
            // 
            this.user_admin_label.AutoSize = true;
            this.user_admin_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_admin_label.Location = new System.Drawing.Point(83, 27);
            this.user_admin_label.Name = "user_admin_label";
            this.user_admin_label.Size = new System.Drawing.Size(167, 20);
            this.user_admin_label.TabIndex = 23;
            this.user_admin_label.Text = "User Administration";
            // 
            // delete_user_label
            // 
            this.delete_user_label.AutoSize = true;
            this.delete_user_label.Location = new System.Drawing.Point(83, 263);
            this.delete_user_label.Name = "delete_user_label";
            this.delete_user_label.Size = new System.Drawing.Size(63, 13);
            this.delete_user_label.TabIndex = 30;
            this.delete_user_label.Text = "Delete User";
            // 
            // delete_chkbox
            // 
            this.delete_chkbox.AutoSize = true;
            this.delete_chkbox.Enabled = false;
            this.delete_chkbox.Location = new System.Drawing.Point(244, 262);
            this.delete_chkbox.Name = "delete_chkbox";
            this.delete_chkbox.Size = new System.Drawing.Size(15, 14);
            this.delete_chkbox.TabIndex = 29;
            this.delete_chkbox.UseVisualStyleBackColor = true;
            this.delete_chkbox.CheckedChanged += new System.EventHandler(this.DeleteCheckboxChange);
            // 
            // admin_user_submit_btn
            // 
            this.admin_user_submit_btn.Enabled = false;
            this.admin_user_submit_btn.Location = new System.Drawing.Point(121, 287);
            this.admin_user_submit_btn.Name = "admin_user_submit_btn";
            this.admin_user_submit_btn.Size = new System.Drawing.Size(100, 23);
            this.admin_user_submit_btn.TabIndex = 28;
            this.admin_user_submit_btn.Text = "Submit Changes";
            this.admin_user_submit_btn.UseVisualStyleBackColor = true;
            this.admin_user_submit_btn.Click += new System.EventHandler(this.SubmitUserChangesClick);
            // 
            // lock_unlock_label
            // 
            this.lock_unlock_label.AutoSize = true;
            this.lock_unlock_label.Location = new System.Drawing.Point(84, 236);
            this.lock_unlock_label.Name = "lock_unlock_label";
            this.lock_unlock_label.Size = new System.Drawing.Size(113, 13);
            this.lock_unlock_label.TabIndex = 27;
            this.lock_unlock_label.Text = "Lock/Unlock Account";
            // 
            // admin_label
            // 
            this.admin_label.AutoSize = true;
            this.admin_label.Location = new System.Drawing.Point(83, 210);
            this.admin_label.Name = "admin_label";
            this.admin_label.Size = new System.Drawing.Size(67, 13);
            this.admin_label.TabIndex = 26;
            this.admin_label.Text = "Administrator";
            // 
            // make_admin_chkbox
            // 
            this.make_admin_chkbox.AutoSize = true;
            this.make_admin_chkbox.Enabled = false;
            this.make_admin_chkbox.Location = new System.Drawing.Point(244, 208);
            this.make_admin_chkbox.Name = "make_admin_chkbox";
            this.make_admin_chkbox.Size = new System.Drawing.Size(15, 14);
            this.make_admin_chkbox.TabIndex = 25;
            this.make_admin_chkbox.UseVisualStyleBackColor = true;
            this.make_admin_chkbox.CheckedChanged += new System.EventHandler(this.AdminCheckboxChange);
            // 
            // lock_unlock_chkbox
            // 
            this.lock_unlock_chkbox.AutoSize = true;
            this.lock_unlock_chkbox.Enabled = false;
            this.lock_unlock_chkbox.Location = new System.Drawing.Point(244, 235);
            this.lock_unlock_chkbox.Name = "lock_unlock_chkbox";
            this.lock_unlock_chkbox.Size = new System.Drawing.Size(15, 14);
            this.lock_unlock_chkbox.TabIndex = 24;
            this.lock_unlock_chkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lock_unlock_chkbox.UseVisualStyleBackColor = true;
            this.lock_unlock_chkbox.CheckedChanged += new System.EventHandler(this.LockCheckboxChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "User Options";
            // 
            // admin_user_dropdown
            // 
            this.admin_user_dropdown.FormattingEnabled = true;
            this.admin_user_dropdown.Location = new System.Drawing.Point(138, 156);
            this.admin_user_dropdown.Name = "admin_user_dropdown";
            this.admin_user_dropdown.Size = new System.Drawing.Size(121, 21);
            this.admin_user_dropdown.TabIndex = 21;
            this.admin_user_dropdown.SelectedIndexChanged += new System.EventHandler(this.AdministrationUserSelected);
            // 
            // admin_users_label
            // 
            this.admin_users_label.AutoSize = true;
            this.admin_users_label.Location = new System.Drawing.Point(84, 159);
            this.admin_users_label.Name = "admin_users_label";
            this.admin_users_label.Size = new System.Drawing.Size(37, 13);
            this.admin_users_label.TabIndex = 20;
            this.admin_users_label.Text = "Users:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Edit Existing User:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Edit Existing Category:";
            // 
            // admin_cat_newname
            // 
            this.admin_cat_newname.Enabled = false;
            this.admin_cat_newname.Location = new System.Drawing.Point(127, 287);
            this.admin_cat_newname.Name = "admin_cat_newname";
            this.admin_cat_newname.Size = new System.Drawing.Size(100, 20);
            this.admin_cat_newname.TabIndex = 22;
            this.admin_cat_newname.TextChanged += new System.EventHandler(this.AdministrationCategoryNameEntered);
            // 
            // admin_cat_name_label
            // 
            this.admin_cat_name_label.AutoSize = true;
            this.admin_cat_name_label.Location = new System.Drawing.Point(36, 290);
            this.admin_cat_name_label.Name = "admin_cat_name_label";
            this.admin_cat_name_label.Size = new System.Drawing.Size(63, 13);
            this.admin_cat_name_label.TabIndex = 21;
            this.admin_cat_name_label.Text = "New Name:";
            // 
            // admin_cat_dropdown
            // 
            this.admin_cat_dropdown.FormattingEnabled = true;
            this.admin_cat_dropdown.Location = new System.Drawing.Point(127, 248);
            this.admin_cat_dropdown.Name = "admin_cat_dropdown";
            this.admin_cat_dropdown.Size = new System.Drawing.Size(100, 21);
            this.admin_cat_dropdown.TabIndex = 19;
            this.admin_cat_dropdown.SelectedIndexChanged += new System.EventHandler(this.AdministrationCategorySelected);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Categories:";
            // 
            // admin_cat_delete_btn
            // 
            this.admin_cat_delete_btn.Enabled = false;
            this.admin_cat_delete_btn.Location = new System.Drawing.Point(262, 246);
            this.admin_cat_delete_btn.Name = "admin_cat_delete_btn";
            this.admin_cat_delete_btn.Size = new System.Drawing.Size(75, 23);
            this.admin_cat_delete_btn.TabIndex = 17;
            this.admin_cat_delete_btn.Text = "Delete";
            this.admin_cat_delete_btn.UseVisualStyleBackColor = true;
            this.admin_cat_delete_btn.Click += new System.EventHandler(this.DeleteCategoryClick);
            // 
            // admin_cat_rename_btn
            // 
            this.admin_cat_rename_btn.Enabled = false;
            this.admin_cat_rename_btn.Location = new System.Drawing.Point(262, 285);
            this.admin_cat_rename_btn.Name = "admin_cat_rename_btn";
            this.admin_cat_rename_btn.Size = new System.Drawing.Size(75, 23);
            this.admin_cat_rename_btn.TabIndex = 16;
            this.admin_cat_rename_btn.Text = " Rename";
            this.admin_cat_rename_btn.UseVisualStyleBackColor = true;
            this.admin_cat_rename_btn.Click += new System.EventHandler(this.RenameCategoryClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Category to add:";
            // 
            // admin_new_cat_input
            // 
            this.admin_new_cat_input.Location = new System.Drawing.Point(127, 67);
            this.admin_new_cat_input.Name = "admin_new_cat_input";
            this.admin_new_cat_input.Size = new System.Drawing.Size(100, 20);
            this.admin_new_cat_input.TabIndex = 14;
            this.admin_new_cat_input.TextChanged += new System.EventHandler(this.AdministrationNewCatNameEntered);
            // 
            // admin_cat_add_btn
            // 
            this.admin_cat_add_btn.Enabled = false;
            this.admin_cat_add_btn.Location = new System.Drawing.Point(262, 65);
            this.admin_cat_add_btn.Name = "admin_cat_add_btn";
            this.admin_cat_add_btn.Size = new System.Drawing.Size(75, 23);
            this.admin_cat_add_btn.TabIndex = 13;
            this.admin_cat_add_btn.Text = "Add";
            this.admin_cat_add_btn.UseVisualStyleBackColor = true;
            this.admin_cat_add_btn.Click += new System.EventHandler(this.AddCategoryClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Category Administration";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 445);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tab_control);
            this.Controls.Add(this.time_stamp);
            this.Controls.Add(this.date_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venture Business Management";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab_control.ResumeLayout(false);
            this.home_tab.ResumeLayout(false);
            this.home_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.home_logo)).EndInit();
            this.ee_tab.ResumeLayout(false);
            this.ee_tab.PerformLayout();
            this.vr_tab.ResumeLayout(false);
            this.vr_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vr_grid)).EndInit();
            this.vh_tab.ResumeLayout(false);
            this.vh_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vh_grid)).EndInit();
            this.admin_tab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage home_tab;
        private System.Windows.Forms.RichTextBox home_user_details;
        private System.Windows.Forms.PictureBox home_logo;
        private System.Windows.Forms.TabPage ee_tab;
        private System.Windows.Forms.TabPage vr_tab;
        private System.Windows.Forms.TabPage vh_tab;
        private System.Windows.Forms.Label welcome_msg;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Label ee_category_label;
        private System.Windows.Forms.Label ee_label;
        private System.Windows.Forms.Label ee_comments_label;
        private System.Windows.Forms.Label ee_date_label;
        private System.Windows.Forms.DateTimePicker ee_date_picker;
        private System.Windows.Forms.RichTextBox ee_comment_box;
        private System.Windows.Forms.TextBox ee_expense_input;
        private System.Windows.Forms.ComboBox ee_category_list;
        private System.Windows.Forms.Button save_expense_btn;
        private System.Windows.Forms.Label vr_mon_total;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView vr_grid;
        private System.Windows.Forms.DateTimePicker vr_end_date_picker;
        private System.Windows.Forms.DateTimePicker vr_start_date_picker;
        private System.Windows.Forms.Button view_reports_btn;
        private System.Windows.Forms.ComboBox vr_category_list;
        private System.Windows.Forms.Label vr_start_date;
        private System.Windows.Forms.Label vr_end_date;
        private System.Windows.Forms.Label vr_categories;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox vh_user_list;
        private System.Windows.Forms.DateTimePicker vh_end_date_picker;
        private System.Windows.Forms.Button vh_search_btn;
        private System.Windows.Forms.ComboBox vh_category_list;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker vh_start_date_picker;
        private System.Windows.Forms.Button export_btn;
        private System.Windows.Forms.Button detailed_report_btn;
        private System.Windows.Forms.ToolStripMenuItem applicationInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationHelpToolStripMenuItem;
        private System.Windows.Forms.DataGridView vh_grid;
        private System.Windows.Forms.Label vr_report_label;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label vr_mileage_total;
        public System.Windows.Forms.Label time_stamp;
        private System.Windows.Forms.Label expense_error_msg;
        private System.Windows.Forms.Label vr_error_msg;
        private System.Windows.Forms.Label vh_error_msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expense;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn expenseHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsHeader;
        private System.Windows.Forms.Label ee_success_message;
        private System.Windows.Forms.TabPage admin_tab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox admin_user_dropdown;
        private System.Windows.Forms.Label admin_users_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label delete_user_label;
        private System.Windows.Forms.CheckBox delete_chkbox;
        private System.Windows.Forms.Button admin_user_submit_btn;
        private System.Windows.Forms.Label lock_unlock_label;
        private System.Windows.Forms.Label admin_label;
        private System.Windows.Forms.CheckBox make_admin_chkbox;
        private System.Windows.Forms.CheckBox lock_unlock_chkbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox admin_new_cat_input;
        private System.Windows.Forms.Button admin_cat_add_btn;
        private System.Windows.Forms.ComboBox admin_cat_dropdown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button admin_cat_delete_btn;
        private System.Windows.Forms.Button admin_cat_rename_btn;
        private System.Windows.Forms.TextBox admin_cat_newname;
        private System.Windows.Forms.Label admin_cat_name_label;
        private System.Windows.Forms.Button add_user_btn;
        private System.Windows.Forms.Label user_admin_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}