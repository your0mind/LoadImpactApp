using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoadImpactApp.ResultsSettings
{
    [TypeDescriptionProvider(typeof(MetricSettingsTableDescriptionProvider<AbstractMetricSettingsTable, TableLayoutPanel>))]
    public abstract class AbstractMetricSettingsTable : TableLayoutPanel
    {
        protected Button m_AddMetricButton;

        public AbstractMetricSettingsTable()
        {
            //AutoSize = true;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            //ColumnCount = 7;
            //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60));
            //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
            //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            //RowCount = 2;
            //RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            //RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            //Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Metric name" }, 0, 0);
            //Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Min" }, 1, 0);
            //Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Median" }, 2, 0);
            //Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Max" }, 3, 0);
            //Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Look for stability" }, 4, 0);
            //Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Text = "Arithmetic precision" }, 5, 0);

            m_AddMetricButton = new Button() { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke, Text = "Add metric" };
            m_AddMetricButton.Click += AddMetricButton_Click;
            Controls.Add(m_AddMetricButton, 0, 1);

            ControlAdded += MetricSettingsTable_ControlAdded;
        }

        protected void MetricSettingsTable_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is Button)
            {
                e.Control.Click += RemoveMetricSettingsRow_Click;
            }
        }

        public void AddMetricSettingsRange(List<MetricSettings> range)
        {
            foreach (var metricSettings in range)
            {
                AddMetricSettings(new MetricSettings()
                {
                    Name = metricSettings.Name,
                    Min = metricSettings.Min,
                    Median = metricSettings.Median,
                    Max = metricSettings.Max,
                    LookForStability = metricSettings.LookForStability,
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
                    Min = ((CheckBox)GetControlFromPosition(1, i)).Checked,
                    Median = ((CheckBox)GetControlFromPosition(2, i)).Checked,
                    Max = ((CheckBox)GetControlFromPosition(3, i)).Checked,
                    LookForStability = ((CheckBox)GetControlFromPosition(4, i)).Checked,
                    Precision = (int)((NumericUpDown)GetControlFromPosition(5, i)).Value
                });
            }
            return metricsSettings;
        }

        protected abstract void RemoveMetricSettingsRow_Click(object sender, EventArgs e);
        protected abstract void AddMetricButton_Click(object sender, EventArgs e);
        public abstract void AddMetricSettings(MetricSettings metricSettings);
    }
}
