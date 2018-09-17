using System.Collections.Generic;
using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class AddMetricFormWithComboBox : Form
    {
        private string m_MetricName;

        public AddMetricFormWithComboBox(List<string> metricList)
        {
            InitializeComponent();
            metricNameComboBox.DataSource = metricList;
        }

        public string GetMetric()
        {
            return m_MetricName;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            m_MetricName = metricNameComboBox.SelectedItem.ToString();
            Close();
        }
    }
}
