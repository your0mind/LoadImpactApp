using LoadImpactApp.DeserializableClasses.Xml;
using LoadImpactApp.ResultsSettings;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class ResultsSettingsForm : Form
    {
        private MetricSettingsTableWithLabels m_StandardMetricsTable;
        private MetricSettingsTableWithLabels m_ServerAgentMetricsTable;
        private MetricSettingsTableWithTextBoxes m_PageMetricsTable;
        private Test m_ReturnTestSettings;
        private string m_TestName;

        public ResultsSettingsForm(string testName)
        {
            InitializeComponent();

            m_StandardMetricsTable = new MetricSettingsTableWithLabels()
            {
                Metrics = UserSettings.LoadImpactService.ConstMetrics.Standard.Select(i => i.Name).ToList(),
                BackColor = ColorConsts.STANDARD_METRIC
            };
            m_ServerAgentMetricsTable = new MetricSettingsTableWithLabels()
            {
                Metrics = UserSettings.LoadImpactService.ConstMetrics.ServerAgent.Select(i => i.Name).ToList(),
                BackColor = ColorConsts.SERVER_AGENT_METRIC
            };
            m_PageMetricsTable = new MetricSettingsTableWithTextBoxes()
            {
                BackColor = ColorConsts.PAGE_METRIC
            };

            metricSettingsPanel.Controls.Add(m_StandardMetricsTable, 0, 3);
            metricSettingsPanel.Controls.Add(m_ServerAgentMetricsTable, 0, 6);
            metricSettingsPanel.Controls.Add(m_PageMetricsTable, 0, 9);

            var savedTestSettings = UserSettings.LoadImpactService.User.FavoritesTests.Find(t => t.Name == testName);

            if (savedTestSettings != null)
            {
                vusNumberAnalisisCheckBox.Checked = savedTestSettings.CheckVusActivity;
                m_StandardMetricsTable.AddMetricSettingsRange(savedTestSettings.StandardMetrics);
                m_ServerAgentMetricsTable.AddMetricSettingsRange(savedTestSettings.ServerAgentMetrics);
                m_PageMetricsTable.AddMetricSettingsRange(savedTestSettings.PageMetrics);
                saveButton.Enabled = true;
            }

            m_ReturnTestSettings = null;
            m_TestName = testName;
        }

        private void finalGetResultsButton_Click(object sender, EventArgs e)
        {
            m_ReturnTestSettings = ExtractTestSettings();
            Close();
        }

        public Test ExtractTestSettings()
        {
            return new Test()
            {
                Name = m_TestName,
                CheckVusActivity = vusNumberAnalisisCheckBox.Checked,
                StandardMetrics = m_StandardMetricsTable.GetMetricsSettings(),
                ServerAgentMetrics = m_ServerAgentMetricsTable.GetMetricsSettings(),
                PageMetrics = m_PageMetricsTable.GetMetricsSettings()
            };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var testSettingsToSave = ExtractTestSettings();
            int indexToDelete = UserSettings.LoadImpactService.User.FavoritesTests.FindIndex(test => test.Name == testSettingsToSave.Name);
            UserSettings.LoadImpactService.User.FavoritesTests.RemoveAt(indexToDelete);
            UserSettings.LoadImpactService.User.FavoritesTests.Insert(indexToDelete, testSettingsToSave);
        }

        public Test GetTestSettings()
        {
            return m_ReturnTestSettings;
        }

        private void ResultsSettingsForm_Load(object sender, EventArgs e)
        {
            finalGetResultsButton.Select();
        }
    }
}
