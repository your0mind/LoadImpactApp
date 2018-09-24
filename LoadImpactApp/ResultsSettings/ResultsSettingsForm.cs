using LoadImpactApp.Api;
using LoadImpactApp.DeserializableClasses.Xml;
using LoadImpactApp.ResultsSettings;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class ResultsSettingsForm : Form
    {
        private MetricSettingsTableWithLabels m_StandardMetricsTable;
        private MetricSettingsTableWithLabels m_ServerAgentMetricsTable;
        private MetricSettingsTableWithTextBoxes m_PageMetricsTable;
        private TestSettings m_ReturnTestSettings;
        private string m_TestName;

        public ResultsSettingsForm(string testName)
        {
            InitializeComponent();

            m_StandardMetricsTable = new MetricSettingsTableWithLabels()
            {
                Metrics = Settings.LoadImpactService.TimelessMetrics.StandartMetricsInfo.Select(i => i.Name).ToList(),
                BackColor = Color.LemonChiffon
            };
            m_ServerAgentMetricsTable = new MetricSettingsTableWithLabels()
            {
                Metrics = Settings.LoadImpactService.TimelessMetrics.ServerAgentMetricsInfo.Select(i => i.Name).ToList(),
                BackColor = Color.LightCyan
            };
            m_PageMetricsTable = new MetricSettingsTableWithTextBoxes()
            {
                BackColor = Color.PaleGreen
            };

            metricSettingsPanel.Controls.Add(m_StandardMetricsTable, 0, 3);
            metricSettingsPanel.Controls.Add(m_ServerAgentMetricsTable, 0, 6);
            metricSettingsPanel.Controls.Add(m_PageMetricsTable, 0, 9);

            var savedTestSettings = Settings.LoadImpactService.User.FavoritesTests.Find(t => t.Name == testName);

            if (savedTestSettings != null)
            {
                vusNumberAnalisisCheckBox.Checked = savedTestSettings.UseAnalisisWithVusNumber;
                m_StandardMetricsTable.AddMetricSettingsRange(savedTestSettings.StandartMetrics);
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

        public TestSettings ExtractTestSettings()
        {
            return new TestSettings()
            {
                Name = m_TestName,
                UseAnalisisWithVusNumber = vusNumberAnalisisCheckBox.Checked,
                StandartMetrics = m_StandardMetricsTable.GetMetricsSettings(),
                ServerAgentMetrics = m_ServerAgentMetricsTable.GetMetricsSettings(),
                PageMetrics = m_PageMetricsTable.GetMetricsSettings()
            };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var testSettingsToSave = ExtractTestSettings();
            int indexToDelete = Settings.LoadImpactService.User.FavoritesTests.FindIndex(test => test.Name == testSettingsToSave.Name);
            Settings.LoadImpactService.User.FavoritesTests.RemoveAt(indexToDelete);
            Settings.LoadImpactService.User.FavoritesTests.Insert(indexToDelete, testSettingsToSave);
        }

        public TestSettings GetTestSettings()
        {
            return m_ReturnTestSettings;
        }

        private void ResultsSettingsForm_Load(object sender, EventArgs e)
        {
            finalGetResultsButton.Select();
        }
    }
}
