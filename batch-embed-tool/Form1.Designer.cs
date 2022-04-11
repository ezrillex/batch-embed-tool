namespace batch_embed_tool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("root");
            this.textdebug = new System.Windows.Forms.TextBox();
            this.treefiles = new System.Windows.Forms.TreeView();
            this.convert_button = new System.Windows.Forms.Button();
            this.work_datagrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connect_button = new System.Windows.Forms.Button();
            this.exportJSON_button = new System.Windows.Forms.Button();
            this.exportCSV_button = new System.Windows.Forms.Button();
            this.button_files_as_names = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.work_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textdebug
            // 
            this.textdebug.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textdebug.Location = new System.Drawing.Point(0, 543);
            this.textdebug.Multiline = true;
            this.textdebug.Name = "textdebug";
            this.textdebug.ReadOnly = true;
            this.textdebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textdebug.Size = new System.Drawing.Size(1173, 93);
            this.textdebug.TabIndex = 2;
            // 
            // treefiles
            // 
            this.treefiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treefiles.CheckBoxes = true;
            this.treefiles.Enabled = false;
            this.treefiles.Location = new System.Drawing.Point(12, 12);
            this.treefiles.Name = "treefiles";
            treeNode1.Name = "Node0";
            treeNode1.Tag = "folder#12345";
            treeNode1.Text = "root";
            this.treefiles.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treefiles.Size = new System.Drawing.Size(573, 525);
            this.treefiles.TabIndex = 3;
            this.treefiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treefiles_AfterCheck);
            this.treefiles.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treefiles_AfterExpand);
            // 
            // convert_button
            // 
            this.convert_button.Enabled = false;
            this.convert_button.Location = new System.Drawing.Point(737, 12);
            this.convert_button.Name = "convert_button";
            this.convert_button.Size = new System.Drawing.Size(209, 23);
            this.convert_button.TabIndex = 5;
            this.convert_button.Text = "Generate Embeds and Direct Links";
            this.convert_button.UseVisualStyleBackColor = true;
            this.convert_button.Click += new System.EventHandler(this.convert_button_Click);
            // 
            // work_datagrid
            // 
            this.work_datagrid.AllowUserToAddRows = false;
            this.work_datagrid.AllowUserToDeleteRows = false;
            this.work_datagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.work_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.work_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.work_datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column3,
            this.Column2,
            this.Column4});
            this.work_datagrid.Location = new System.Drawing.Point(591, 70);
            this.work_datagrid.Name = "work_datagrid";
            this.work_datagrid.RowTemplate.Height = 25;
            this.work_datagrid.Size = new System.Drawing.Size(570, 467);
            this.work_datagrid.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "File Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Export Name";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "OneDrive ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Embed Link";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Direct Download Link";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(591, 12);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(140, 23);
            this.connect_button.TabIndex = 7;
            this.connect_button.Text = "Connect to OneDrive";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // exportJSON_button
            // 
            this.exportJSON_button.Enabled = false;
            this.exportJSON_button.Location = new System.Drawing.Point(952, 12);
            this.exportJSON_button.Name = "exportJSON_button";
            this.exportJSON_button.Size = new System.Drawing.Size(103, 23);
            this.exportJSON_button.TabIndex = 8;
            this.exportJSON_button.Text = "Export to JSON";
            this.exportJSON_button.UseVisualStyleBackColor = true;
            this.exportJSON_button.Click += new System.EventHandler(this.exportJSON_button_Click);
            // 
            // exportCSV_button
            // 
            this.exportCSV_button.Enabled = false;
            this.exportCSV_button.Location = new System.Drawing.Point(1061, 12);
            this.exportCSV_button.Name = "exportCSV_button";
            this.exportCSV_button.Size = new System.Drawing.Size(100, 23);
            this.exportCSV_button.TabIndex = 9;
            this.exportCSV_button.Text = "Export to CSV";
            this.exportCSV_button.UseVisualStyleBackColor = true;
            this.exportCSV_button.Click += new System.EventHandler(this.exportCSV_button_Click);
            // 
            // button_files_as_names
            // 
            this.button_files_as_names.Enabled = false;
            this.button_files_as_names.Location = new System.Drawing.Point(591, 41);
            this.button_files_as_names.Name = "button_files_as_names";
            this.button_files_as_names.Size = new System.Drawing.Size(178, 23);
            this.button_files_as_names.TabIndex = 10;
            this.button_files_as_names.Text = "Use filename as export name";
            this.button_files_as_names.UseVisualStyleBackColor = true;
            this.button_files_as_names.Click += new System.EventHandler(this.button_files_as_names_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 636);
            this.Controls.Add(this.button_files_as_names);
            this.Controls.Add(this.exportCSV_button);
            this.Controls.Add(this.exportJSON_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.work_datagrid);
            this.Controls.Add(this.convert_button);
            this.Controls.Add(this.treefiles);
            this.Controls.Add(this.textdebug);
            this.Name = "MainForm";
            this.Text = "Onedrive Batch Embed/Direct Links Tool Prototype";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.work_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textdebug;
        private TreeView treefiles;
        private Button convert_button;
        private DataGridView work_datagrid;
        private Button connect_button;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column4;
        private Button exportJSON_button;
        private Button exportCSV_button;
        private Button button_files_as_names;
    }
}