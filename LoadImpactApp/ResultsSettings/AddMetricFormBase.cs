using System.Windows.Forms;

namespace LoadImpactApp.ResultsSettings
{
    public class AddMetricFormBase : Form
    {
        protected string m_MetricName;

        public AddMetricFormBase()
        {
            m_MetricName = null;
        }

        public string GetMetric()
        {
            return m_MetricName;
        }
    }
}
