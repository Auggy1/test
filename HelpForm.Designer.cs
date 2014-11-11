﻿namespace Project_Forms
{
    partial class Form2
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Welcome!");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Login");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Enter Expense");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("View Reports");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("View History");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Add User");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Edit User");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Add Category");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Edit Category");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Rename Category");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Delete Category");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Admin Capabilities ", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(649, 428);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node13";
            treeNode1.Text = "Welcome!";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Login";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Enter Expense";
            treeNode4.Name = "Node9";
            treeNode4.Text = "View Reports";
            treeNode5.Name = "Node10";
            treeNode5.Text = "View History";
            treeNode6.Name = "Node0";
            treeNode6.Text = "General";
            treeNode7.Name = "Node5";
            treeNode7.Text = "Add User";
            treeNode8.Name = "Node6";
            treeNode8.Text = "Edit User";
            treeNode9.Name = "Node7";
            treeNode9.Text = "Add Category";
            treeNode10.Name = "Node11";
            treeNode10.Text = "Edit Category";
            treeNode11.Name = "Node12";
            treeNode11.Text = "Rename Category";
            treeNode12.Name = "Node0";
            treeNode12.Text = "Delete Category";
            treeNode13.Name = "Node4";
            treeNode13.Text = "Admin Capabilities ";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6,
            treeNode13});
            this.treeView1.Size = new System.Drawing.Size(191, 404);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(405, 404);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 428);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Help";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}