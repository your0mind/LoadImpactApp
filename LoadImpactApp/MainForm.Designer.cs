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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.resultsPage = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.favoritesTestsComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.allTestsComboBox = new System.Windows.Forms.ComboBox();
            this.runsListBox = new System.Windows.Forms.ListBox();
            this.getResultsButton = new System.Windows.Forms.Button();
            this.testResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testsPage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.favoritesTestsListBox = new System.Windows.Forms.ListBox();
            this.removeFromFavButton = new System.Windows.Forms.Button();
            this.allTestsPage = new System.Windows.Forms.TabPage();
            this.allTestsListBox = new System.Windows.Forms.ListBox();
            this.addToFavButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.resultsPage.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testResultsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testInfoDataGridView)).BeginInit();
            this.testsPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.allTestsPage.SuspendLayout();
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
            // resultsPage
            // 
            this.resultsPage.BackColor = System.Drawing.SystemColors.Control;
            this.resultsPage.Controls.Add(this.testInfoDataGridView);
            this.resultsPage.Controls.Add(this.testResultsDataGridView);
            this.resultsPage.Controls.Add(this.getResultsButton);
            this.resultsPage.Controls.Add(this.runsListBox);
            this.resultsPage.Controls.Add(this.tabControl3);
            this.resultsPage.Location = new System.Drawing.Point(4, 22);
            this.resultsPage.Name = "resultsPage";
            this.resultsPage.Padding = new System.Windows.Forms.Padding(3);
            this.resultsPage.Size = new System.Drawing.Size(758, 496);
            this.resultsPage.TabIndex = 1;
            this.resultsPage.Text = "Results";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl3.Location = new System.Drawing.Point(15, 15);
            this.tabControl3.Multiline = true;
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(232, 58);
            this.tabControl3.TabIndex = 1;
            this.tabControl3.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl3_Selecting);
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
            // runsListBox
            // 
            this.runsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            // getResultsButton
            // 
            this.getResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.getResultsButton.Enabled = false;
            this.getResultsButton.Location = new System.Drawing.Point(14, 447);
            this.getResultsButton.Name = "getResultsButton";
            this.getResultsButton.Size = new System.Drawing.Size(232, 33);
            this.getResultsButton.TabIndex = 3;
            this.getResultsButton.Text = "Get results";
            this.getResultsButton.UseVisualStyleBackColor = true;
            this.getResultsButton.Click += new System.EventHandler(this.getResultsButton_Click);
            // 
            // testResultsDataGridView
            // 
            this.testResultsDataGridView.AllowUserToAddRows = false;
            this.testResultsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.testResultsDataGridView.RowHeadersVisible = false;
            this.testResultsDataGridView.RowHeadersWidth = 150;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.testResultsDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testResultsDataGridView.RowTemplate.Height = 30;
            this.testResultsDataGridView.RowTemplate.ReadOnly = true;
            this.testResultsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.testResultsDataGridView.Size = new System.Drawing.Size(477, 397);
            this.testResultsDataGridView.TabIndex = 4;
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
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 12F;
            this.Column4.HeaderText = "Max";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 12F;
            this.Column3.HeaderText = "Avg";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column1.FillWeight = 45F;
            this.Column1.HeaderText = "Metric name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // testInfoDataGridView
            // 
            this.testInfoDataGridView.AllowUserToAddRows = false;
            this.testInfoDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.testInfoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testInfoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testInfoDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.testInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4});
            this.testInfoDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.DefaultCellStyle = dataGridViewCellStyle20;
            this.testInfoDataGridView.EnableHeadersVisualStyles = false;
            this.testInfoDataGridView.Location = new System.Drawing.Point(265, 15);
            this.testInfoDataGridView.Name = "testInfoDataGridView";
            this.testInfoDataGridView.ReadOnly = true;
            this.testInfoDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.testInfoDataGridView.RowHeadersVisible = false;
            this.testInfoDataGridView.RowHeadersWidth = 150;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.testInfoDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testInfoDataGridView.RowTemplate.Height = 30;
            this.testInfoDataGridView.RowTemplate.ReadOnly = true;
            this.testInfoDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.testInfoDataGridView.Size = new System.Drawing.Size(477, 57);
            this.testInfoDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 25F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Max VUs";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 30F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Ended";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 45F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Test name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.resultsPage.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testResultsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testInfoDataGridView)).EndInit();
            this.testsPage.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.allTestsPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TabPage resultsPage;
        private System.Windows.Forms.DataGridView testInfoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView testResultsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button getResultsButton;
        private System.Windows.Forms.ListBox runsListBox;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox allTestsComboBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox favoritesTestsComboBox;
        private System.Windows.Forms.TabPage testsPage;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage allTestsPage;
        private System.Windows.Forms.Button addToFavButton;
        private System.Windows.Forms.ListBox allTestsListBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button removeFromFavButton;
        private System.Windows.Forms.ListBox favoritesTestsListBox;
        private System.Windows.Forms.TabControl tabControl1;
    }
}