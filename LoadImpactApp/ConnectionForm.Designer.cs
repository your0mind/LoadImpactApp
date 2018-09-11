namespace LoadImpactApp
{
    partial class ConnectionForm
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
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.rememeberCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.faqButton = new System.Windows.Forms.Button();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tokenBox
            // 
            this.tokenBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tokenBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tokenBox.Location = new System.Drawing.Point(26, 35);
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.Size = new System.Drawing.Size(200, 22);
            this.tokenBox.TabIndex = 0;
            this.tokenBox.TextChanged += new System.EventHandler(this.tokenBox_TextChanged);
            // 
            // rememeberCheck
            // 
            this.rememeberCheck.AutoSize = true;
            this.rememeberCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememeberCheck.Location = new System.Drawing.Point(102, 74);
            this.rememeberCheck.Name = "rememeberCheck";
            this.rememeberCheck.Size = new System.Drawing.Size(95, 20);
            this.rememeberCheck.TabIndex = 3;
            this.rememeberCheck.Text = "Remember";
            this.rememeberCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rest API token:";
            // 
            // connectButton
            // 
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectButton.Location = new System.Drawing.Point(235, 35);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(45, 55);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // faqButton
            // 
            this.faqButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.faqButton.Location = new System.Drawing.Point(27, 66);
            this.faqButton.Name = "faqButton";
            this.faqButton.Size = new System.Drawing.Size(60, 24);
            this.faqButton.TabIndex = 5;
            this.faqButton.Text = "F.A.Q.";
            this.faqButton.UseVisualStyleBackColor = true;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.connectionStatusLabel.Location = new System.Drawing.Point(136, 17);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(149, 15);
            this.connectionStatusLabel.TabIndex = 6;
            this.connectionStatusLabel.Text = "ConnectionStatus";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.connectionStatusLabel.UseMnemonic = false;
            this.connectionStatusLabel.Visible = false;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 122);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.faqButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rememeberCheck);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.tokenBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadImpactApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectionForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.CheckBox rememeberCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button faqButton;
        private System.Windows.Forms.Label connectionStatusLabel;
    }
}

