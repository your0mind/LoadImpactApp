using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Windows.Forms;

namespace LoadImpactApp.ResultsSettings
{
    public class MetricSettingsTableWithTextBoxes : MetricSettingsTableBase
    {
        protected override void RemoveMetricSettingsRow_Click(object sender, EventArgs e)
        {
            RemoveMetricSettingsRow(GetRow((Button)sender));
        }

        protected override void AddMetricButton_Click(object sender, EventArgs e)
        {
            var addMetricForm = new AddMetricFormWithTextBox();
            addMetricForm.FormClosing += AddMetricForm_FormClosing;
            addMetricForm.ShowDialog();
        }

        public override void AddMetricSettings(MetricSettings metricSettings)
        {
            AddDefaultControlsForSettings(metricSettings);
            Controls.Add(new TextBox() { Dock = DockStyle.Fill, Text = metricSettings.Name }, 0, RowCount - 2);
        }
    }
}
