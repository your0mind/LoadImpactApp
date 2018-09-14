using System.Collections.Generic;
using System.Windows.Forms;

namespace LoadImpactApp
{
    internal sealed class MetricSettingsTableWithLabels : TableLayoutPanel
    {
        private List<string> m_Metrics;

        public List<string> Metrics
        {
            get
            {
                return m_Metrics;
            }
            set
            {
                m_Metrics = new List<string>(value);
            }
        }

        public MetricSettingsTableWithLabels()
        {
        }
    }
}
