using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoadImpactApp.ResultsSettings
{
    public  class MetricSettingsTableBase : TableLayoutPanel
    {
        protected Button m_AddMetricButton;

        public MetricSettingsTableBase()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            DoubleBuffered = true;

            ColumnCount = 7;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f));

            RowCount = 2;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Metric name" }, 0, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Min" }, 1, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Median" }, 2, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Max" }, 3, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Look for stability" }, 4, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Arithmetic precision" }, 5, 0);

            m_AddMetricButton = new Button() { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke, Text = "Add metric" };
            m_AddMetricButton.Click += AddMetricButton_Click;
            Controls.Add(m_AddMetricButton, 0, 1);

            ControlAdded += MetricSettingsTable_ControlAdded;
        }

        protected void RemoveMetricSettingsRow(int rowIndex)
        {
            for (int i = 0; i < ColumnCount; i++)
            {
                Controls.Remove(GetControlFromPosition(i, rowIndex));
            }

            for (int i = rowIndex + 1; i < RowCount - 1; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    SetRow(GetControlFromPosition(j, i), i - 1);
                }
            }

            SetRow(m_AddMetricButton, RowCount - 2);
            RowStyles.RemoveAt(rowIndex);
            RowCount--;
        }

        protected void MetricSettingsTable_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is Button)
            {
                if (e.Control.Text == "X")
                {
                    e.Control.Click += RemoveMetricSettingsRow_Click;
                }
            }
        }

        public void AddMetricSettingsRange(List<MetricSettings> range)
        {
            foreach (var metricSettings in range)
            {
                AddMetricSettings(new MetricSettings()
                {
                    Name = metricSettings.Name,
                    Smoothed = metricSettings.Smoothed,
                    Precision = metricSettings.Precision
                });
            }
        }

        public List<MetricSettings> GetMetricsSettings()
        {
            var metricsSettings = new List<MetricSettings>();
            for (int i = 1; i < RowCount - 1; i++)
            {
                metricsSettings.Add(new MetricSettings()
                {
                    Name = GetControlFromPosition(0, i).Text,
                    Smoothed = ((CheckBox)GetControlFromPosition(4, i)).Checked,
                    Precision = (int)((NumericUpDown)GetControlFromPosition(5, i)).Value
                });
            }
            return metricsSettings;
        }

        protected void AddMetricForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string metric = ((AddMetricFormBase)sender).GetMetric();
            if (metric != null)
            {
                AddMetricSettings(new MetricSettings()
                {
                    Name = metric,
                    Min = true,
                    Median = true,
                    Max = true,
                    Smoothed = true,
                    Precision = 2
                });
            }
        }

        protected void AddDefaultControlsForSettings(MetricSettings metricSettings)
        {
            RowCount++;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            SetRow(m_AddMetricButton, RowCount - 1);

            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Min }, 1, RowCount - 2);
            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Median }, 2, RowCount - 2);
            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Max }, 3, RowCount - 2);
            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Smoothed }, 4, RowCount - 2);
            Controls.Add(new NumericUpDown() { Value = metricSettings.Precision, Font = new Font("Microsoft Sans Serif", 10), Maximum = 5 }, 5, RowCount - 2);
            Controls.Add(new Button()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Pink,
                ForeColor = Color.Red,
                Dock = DockStyle.Fill,
                Text = "X"
            }, 6, RowCount - 2);
        }

        protected virtual void RemoveMetricSettingsRow_Click(object sender, EventArgs e) { }
        protected virtual void AddMetricButton_Click(object sender, EventArgs e) { }
        public virtual void AddMetricSettings(MetricSettings metricSettings) { }
    }
}
