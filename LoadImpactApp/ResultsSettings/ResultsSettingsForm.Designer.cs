namespace LoadImpactApp
{
    partial class ResultsSettingsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.metricSettingsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vusNumberAnalisisCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.finalGetResultsButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.metricSettingsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.metricSettingsPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 576);
            this.panel1.TabIndex = 0;
            // 
            // metricSettingsPanel
            // 
            this.metricSettingsPanel.AutoSize = true;
            this.metricSettingsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metricSettingsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.metricSettingsPanel.ColumnCount = 1;
            this.metricSettingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.metricSettingsPanel.Controls.Add(this.label1, 0, 2);
            this.metricSettingsPanel.Controls.Add(this.label2, 0, 5);
            this.metricSettingsPanel.Controls.Add(this.label3, 0, 8);
            this.metricSettingsPanel.Controls.Add(this.vusNumberAnalisisCheckBox, 0, 0);
            this.metricSettingsPanel.Location = new System.Drawing.Point(10, 10);
            this.metricSettingsPanel.Name = "metricSettingsPanel";
            this.metricSettingsPanel.RowCount = 11;
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.metricSettingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.metricSettingsPanel.Size = new System.Drawing.Size(388, 263);
            this.metricSettingsPanel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Standard metrics:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server agent metrics:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Page metrics:";
            // 
            // vusNumberAnalisisCheckBox
            // 
            this.vusNumberAnalisisCheckBox.AutoSize = true;
            this.vusNumberAnalisisCheckBox.Checked = true;
            this.vusNumberAnalisisCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vusNumberAnalisisCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vusNumberAnalisisCheckBox.Location = new System.Drawing.Point(3, 3);
            this.vusNumberAnalisisCheckBox.Name = "vusNumberAnalisisCheckBox";
            this.vusNumberAnalisisCheckBox.Size = new System.Drawing.Size(382, 20);
            this.vusNumberAnalisisCheckBox.TabIndex = 3;
            this.vusNumberAnalisisCheckBox.Text = "Ignore the sections of growth/decrease in the number of VUs";
            this.vusNumberAnalisisCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Controls.Add(this.finalGetResultsButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 576);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 36);
            this.panel2.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(254, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // finalGetResultsButton
            // 
            this.finalGetResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finalGetResultsButton.BackColor = System.Drawing.Color.Transparent;
            this.finalGetResultsButton.Location = new System.Drawing.Point(333, 4);
            this.finalGetResultsButton.Name = "finalGetResultsButton";
            this.finalGetResultsButton.Size = new System.Drawing.Size(75, 23);
            this.finalGetResultsButton.TabIndex = 0;
            this.finalGetResultsButton.Text = "OK";
            this.finalGetResultsButton.UseVisualStyleBackColor = false;
            this.finalGetResultsButton.Click += new System.EventHandler(this.finalGetResultsButton_Click);
            // 
            // ResultsSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(420, 612);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultsSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Result settings";
            this.Load += new System.EventHandler(this.ResultsSettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.metricSettingsPanel.ResumeLayout(false);
            this.metricSettingsPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button finalGetResultsButton;
        private System.Windows.Forms.TableLayoutPanel metricSettingsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox vusNumberAnalisisCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}