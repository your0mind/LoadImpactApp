using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class AddMetricFormWithTextBox : Form
    {
        private string m_MetricName;

        public AddMetricFormWithTextBox()
        {
            InitializeComponent();
        }

        public string GetMetric()
        {
            return m_MetricName;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            m_MetricName = metricNameTextBox.Text;
            Close();
        }
    }
}
