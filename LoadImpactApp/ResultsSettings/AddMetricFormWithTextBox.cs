using LoadImpactApp.ResultsSettings;

namespace LoadImpactApp
{
    public partial class AddMetricFormWithTextBox : AddMetricFormBase
    {
        public AddMetricFormWithTextBox()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            m_MetricName = metricNameTextBox.Text;
            Close();
        }
    }
}
