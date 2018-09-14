using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class AddMetricForm : Form
    {
        private TableLayoutPanel m_Tlp;

        public string MetricName { get; set; }

        public AddMetricForm(List<string> metricList, TableLayoutPanel tlp)
        {
            InitializeComponent();
            m_Tlp = tlp;
            comboBox1.DataSource = metricList;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //
            Close();
        }
    }
}
