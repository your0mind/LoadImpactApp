namespace LoadImpactApp
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.removeFromFavButton = new System.Windows.Forms.Button();
            this.favoritesTestsListBox = new System.Windows.Forms.ListBox();
            this.allTestsPage = new System.Windows.Forms.TabPage();
            this.addToFavButton = new System.Windows.Forms.Button();
            this.allTestsListBox = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.testsPage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.resultsPage = new System.Windows.Forms.TabPage();
            this.exportResultsButton = new System.Windows.Forms.Button();
            this.testInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getResultsButton = new System.Windows.Forms.Button();
            this.runsListBox = new System.Windows.Forms.ListBox();
            this.testsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.allTestsComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.favoritesTestsComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.allTestsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.testsPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.resultsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testInfoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testResultsDataGridView)).BeginInit();
            this.testsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.BackColor = System.Drawing.Color.White;
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.disconnectButton.Location = new System.Drawing.Point(742, 9);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(35, 35);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.BackColor = System.Drawing.Color.White;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshButton.Location = new System.Drawing.Point(699, 9);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(35, 35);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.removeFromFavButton);
            this.tabPage2.Controls.Add(this.favoritesTestsListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(272, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Favorites";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // removeFromFavButton
            // 
            this.removeFromFavButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.removeFromFavButton.Location = new System.Drawing.Point(140, 411);
            this.removeFromFavButton.Name = "removeFromFavButton";
            this.removeFromFavButton.Size = new System.Drawing.Size(130, 24);
            this.removeFromFavButton.TabIndex = 4;
            this.removeFromFavButton.Text = "Remove";
            this.removeFromFavButton.UseVisualStyleBackColor = true;
            this.removeFromFavButton.Click += new System.EventHandler(this.removeFromFavButton_Click);
            // 
            // favoritesTestsListBox
            // 
            this.favoritesTestsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.favoritesTestsListBox.FormattingEnabled = true;
            this.favoritesTestsListBox.HorizontalScrollbar = true;
            this.favoritesTestsListBox.IntegralHeight = false;
            this.favoritesTestsListBox.ItemHeight = 16;
            this.favoritesTestsListBox.Location = new System.Drawing.Point(1, 3);
            this.favoritesTestsListBox.Name = "favoritesTestsListBox";
            this.favoritesTestsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.favoritesTestsListBox.Size = new System.Drawing.Size(268, 404);
            this.favoritesTestsListBox.TabIndex = 3;
            // 
            // allTestsPage
            // 
            this.allTestsPage.Controls.Add(this.addToFavButton);
            this.allTestsPage.Controls.Add(this.allTestsListBox);
            this.allTestsPage.Location = new System.Drawing.Point(4, 25);
            this.allTestsPage.Name = "allTestsPage";
            this.allTestsPage.Padding = new System.Windows.Forms.Padding(3);
            this.allTestsPage.Size = new System.Drawing.Size(272, 437);
            this.allTestsPage.TabIndex = 0;
            this.allTestsPage.Text = "All";
            this.allTestsPage.UseVisualStyleBackColor = true;
            // 
            // addToFavButton
            // 
            this.addToFavButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addToFavButton.Location = new System.Drawing.Point(0, 411);
            this.addToFavButton.Name = "addToFavButton";
            this.addToFavButton.Size = new System.Drawing.Size(130, 24);
            this.addToFavButton.TabIndex = 1;
            this.addToFavButton.Text = "Add to favorites";
            this.addToFavButton.UseVisualStyleBackColor = true;
            this.addToFavButton.Click += new System.EventHandler(this.addToFavButton_Click);
            // 
            // allTestsListBox
            // 
            this.allTestsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.allTestsListBox.FormattingEnabled = true;
            this.allTestsListBox.HorizontalScrollbar = true;
            this.allTestsListBox.IntegralHeight = false;
            this.allTestsListBox.ItemHeight = 16;
            this.allTestsListBox.Location = new System.Drawing.Point(1, 3);
            this.allTestsListBox.Name = "allTestsListBox";
            this.allTestsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.allTestsListBox.Size = new System.Drawing.Size(268, 404);
            this.allTestsListBox.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(355, 47);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 22);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(199, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(44, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(157, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 40);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(199, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 40);
            this.label3.TabIndex = 2;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(251, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 40);
            this.label4.TabIndex = 3;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(293, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 40);
            this.label5.TabIndex = 5;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(355, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 40);
            this.label6.TabIndex = 6;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox4.Location = new System.Drawing.Point(157, 47);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(34, 24);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox5.Location = new System.Drawing.Point(251, 47);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(34, 24);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox6.Location = new System.Drawing.Point(293, 47);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(54, 24);
            this.checkBox6.TabIndex = 11;
            this.checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // testsPage
            // 
            this.testsPage.BackColor = System.Drawing.SystemColors.Control;
            this.testsPage.Controls.Add(this.tabControl2);
            this.testsPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testsPage.Location = new System.Drawing.Point(4, 22);
            this.testsPage.Name = "testsPage";
            this.testsPage.Padding = new System.Windows.Forms.Padding(3);
            this.testsPage.Size = new System.Drawing.Size(758, 496);
            this.testsPage.TabIndex = 0;
            this.testsPage.Text = "Tests";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl2.Controls.Add(this.allTestsPage);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(15, 15);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(280, 466);
            this.tabControl2.TabIndex = 0;
            // 
            // resultsPage
            // 
            this.resultsPage.BackColor = System.Drawing.SystemColors.Control;
            this.resultsPage.Controls.Add(this.exportResultsButton);
            this.resultsPage.Controls.Add(this.testInfoDataGridView);
            this.resultsPage.Controls.Add(this.testResultsDataGridView);
            this.resultsPage.Controls.Add(this.getResultsButton);
            this.resultsPage.Controls.Add(this.runsListBox);
            this.resultsPage.Controls.Add(this.testsTabControl);
            this.resultsPage.Location = new System.Drawing.Point(4, 22);
            this.resultsPage.Name = "resultsPage";
            this.resultsPage.Padding = new System.Windows.Forms.Padding(3);
            this.resultsPage.Size = new System.Drawing.Size(758, 496);
            this.resultsPage.TabIndex = 1;
            this.resultsPage.Text = "Results";
            // 
            // exportResultsButton
            // 
            this.exportResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportResultsButton.Enabled = false;
            this.exportResultsButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.exportResultsButton.Location = new System.Drawing.Point(511, 447);
            this.exportResultsButton.Name = "exportResultsButton";
            this.exportResultsButton.Size = new System.Drawing.Size(232, 33);
            this.exportResultsButton.TabIndex = 6;
            this.exportResultsButton.Text = "Export results";
            this.exportResultsButton.UseVisualStyleBackColor = true;
            this.exportResultsButton.Click += new System.EventHandler(this.exportResultsButton_Click);
            // 
            // testInfoDataGridView
            // 
            this.testInfoDataGridView.AllowUserToAddRows = false;
            this.testInfoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.testInfoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testInfoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testInfoDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.testInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column7,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.Column6});
            this.testInfoDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.testInfoDataGridView.EnableHeadersVisualStyles = false;
            this.testInfoDataGridView.Location = new System.Drawing.Point(265, 15);
            this.testInfoDataGridView.Name = "testInfoDataGridView";
            this.testInfoDataGridView.ReadOnly = true;
            this.testInfoDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.testInfoDataGridView.RowHeadersVisible = false;
            this.testInfoDataGridView.RowHeadersWidth = 150;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.testInfoDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.RowTemplate.Height = 30;
            this.testInfoDataGridView.RowTemplate.ReadOnly = true;
            this.testInfoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.testInfoDataGridView.Size = new System.Drawing.Size(477, 57);
            this.testInfoDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 35F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Test name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.FillWeight = 15F;
            this.Column7.HeaderText = "ID";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 20F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Ended";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 10F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Max VUs";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.FillWeight = 20F;
            this.Column6.HeaderText = "Area of stable VUs active (%)";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // testResultsDataGridView
            // 
            this.testResultsDataGridView.AllowUserToAddRows = false;
            this.testResultsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.testResultsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testResultsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testResultsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.testResultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.testResultsDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.testResultsDataGridView.EnableHeadersVisualStyles = false;
            this.testResultsDataGridView.Location = new System.Drawing.Point(265, 82);
            this.testResultsDataGridView.Name = "testResultsDataGridView";
            this.testResultsDataGridView.ReadOnly = true;
            this.testResultsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.testResultsDataGridView.RowHeadersVisible = false;
            this.testResultsDataGridView.RowHeadersWidth = 150;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.testResultsDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testResultsDataGridView.RowTemplate.Height = 30;
            this.testResultsDataGridView.RowTemplate.ReadOnly = true;
            this.testResultsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.Size = new System.Drawing.Size(477, 356);
            this.testResultsDataGridView.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.FillWeight = 45F;
            this.Column1.HeaderText = "Metric name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 12F;
            this.Column2.HeaderText = "Min";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 12F;
            this.Column3.HeaderText = "Median";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 12F;
            this.Column4.HeaderText = "Max";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.FillWeight = 19F;
            this.Column5.HeaderText = "Unit";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // getResultsButton
            // 
            this.getResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.getResultsButton.Enabled = false;
            this.getResultsButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.getResultsButton.Location = new System.Drawing.Point(14, 447);
            this.getResultsButton.Name = "getResultsButton";
            this.getResultsButton.Size = new System.Drawing.Size(232, 33);
            this.getResultsButton.TabIndex = 3;
            this.getResultsButton.Text = "Get results";
            this.getResultsButton.UseVisualStyleBackColor = true;
            this.getResultsButton.Click += new System.EventHandler(this.getResultsButton_Click);
            // 
            // runsListBox
            // 
            this.runsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.runsListBox.BackColor = System.Drawing.SystemColors.Window;
            this.runsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runsListBox.FormattingEnabled = true;
            this.runsListBox.HorizontalScrollbar = true;
            this.runsListBox.IntegralHeight = false;
            this.runsListBox.ItemHeight = 16;
            this.runsListBox.Location = new System.Drawing.Point(15, 82);
            this.runsListBox.Name = "runsListBox";
            this.runsListBox.Size = new System.Drawing.Size(230, 356);
            this.runsListBox.TabIndex = 2;
            this.runsListBox.SelectedIndexChanged += new System.EventHandler(this.runsListBox_SelectedIndexChanged);
            // 
            // testsTabControl
            // 
            this.testsTabControl.Controls.Add(this.tabPage1);
            this.testsTabControl.Controls.Add(this.tabPage3);
            this.testsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testsTabControl.Location = new System.Drawing.Point(15, 15);
            this.testsTabControl.Multiline = true;
            this.testsTabControl.Name = "testsTabControl";
            this.testsTabControl.SelectedIndex = 0;
            this.testsTabControl.Size = new System.Drawing.Size(232, 58);
            this.testsTabControl.TabIndex = 1;
            this.testsTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl3_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.allTestsComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(224, 29);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // allTestsComboBox
            // 
            this.allTestsComboBox.FormattingEnabled = true;
            this.allTestsComboBox.Location = new System.Drawing.Point(1, 3);
            this.allTestsComboBox.Name = "allTestsComboBox";
            this.allTestsComboBox.Size = new System.Drawing.Size(220, 24);
            this.allTestsComboBox.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.favoritesTestsComboBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(224, 29);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Favorites";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // favoritesTestsComboBox
            // 
            this.favoritesTestsComboBox.FormattingEnabled = true;
            this.favoritesTestsComboBox.Location = new System.Drawing.Point(1, 3);
            this.favoritesTestsComboBox.Name = "favoritesTestsComboBox";
            this.favoritesTestsComboBox.Size = new System.Drawing.Size(220, 24);
            this.favoritesTestsComboBox.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.testsPage);
            this.tabControl1.Controls.Add(this.resultsPage);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(48, 18);
            this.tabControl1.Location = new System.Drawing.Point(10, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 522);
            this.tabControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadImpactApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tabPage2.ResumeLayout(false);
            this.allTestsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.testsPage.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.resultsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testInfoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testResultsDataGridView)).EndInit();
            this.testsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabControl testsTabControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox favoritesTestsListBox;
        private System.Windows.Forms.Button removeFromFavButton;
        private System.Windows.Forms.TabPage allTestsPage;
        private System.Windows.Forms.ListBox allTestsListBox;
        private System.Windows.Forms.Button addToFavButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TabPage testsPage;
        private System.Windows.Forms.TabPage resultsPage;
        private System.Windows.Forms.DataGridView testInfoDataGridView;
        private System.Windows.Forms.DataGridView testResultsDataGridView;
        private System.Windows.Forms.Button getResultsButton;
        private System.Windows.Forms.ListBox runsListBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox allTestsComboBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox favoritesTestsComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button exportResultsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}