using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoadImpactApp.ResultsSettings
{
    public sealed class MetricSettingsTableWithLabels : MetricSettingsTableBase
    {
        public List<string> Metrics { get; set; }

        public MetricSettingsTableWithLabels()
        {
            Metrics = new List<string>();
        }

        protected override void RemoveMetricSettingsRow_Click(object sender, EventArgs e)
        {
            int rowToDelete = GetRow((Button)sender);
            Metrics.Add(((Label)GetControlFromPosition(0, rowToDelete)).Text);
            if (Metrics.Count == 1)
            {
                m_AddMetricButton.Enabled = true;
            }
            RemoveMetricSettingsRow(rowToDelete);
        }

        protected override void AddMetricButton_Click(object sender, EventArgs e)
        {
            var addMetricForm = new AddMetricFormWithComboBox(Metrics);
            addMetricForm.FormClosing += AddMetricForm_FormClosing;
            addMetricForm.ShowDialog();
        }

        public override void AddMetricSettings(MetricSettings metricSettings)
        {
            AddDefaultControlsForSettings(metricSettings);
            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = metricSettings.Name }, 0, RowCount - 2);

            Metrics.Remove(metricSettings.Name);
            if (Metrics.Count == 0)
            {
                m_AddMetricButton.Enabled = false;
            }
        }

    }
}
