using LoadImpactApp.ResultsSettings;
using System.Collections.Generic;

namespace LoadImpactApp
{
    public partial class AddMetricFormWithComboBox : AddMetricFormBase
    {
        public AddMetricFormWithComboBox(List<string> metricList)
        {
            InitializeComponent();
            metricNameComboBox.DataSource = metricList;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            m_MetricName = metricNameComboBox.SelectedItem.ToString();
            Close();
        }
    }
}