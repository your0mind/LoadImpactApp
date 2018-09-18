using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class ResultsSettingsForm : Form
    {
        private TestSettings m_TestMetrics;
        public TestSettings TestSettings { get; set; }

        public ResultsSettingsForm(TestSettings testSettings)
        {
            InitializeComponent();

            m_TestMetrics = testSettings;

            var saveSettingsButton = new Button() { Location = new Point(22, 4), Text = "Save", Enabled = false, BackColor = Color.Transparent };
            saveSettingsButton.Click += SaveSettingsButton_Click;
            panel2.Controls.Add(saveSettingsButton);

            standardMetricSettingsTableWithLabels.Metrics = Settings.LoadImpactService
                .TimelessMetrics.ServerAgentMetricsInfo.Select(i => i.Name).ToList();
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            var testSettingsToSave = GetTestSettings();
            int indexToDelete = Settings.LoadImpactService.User.FavoritesTests.FindIndex(test => test.Name == testSettingsToSave.Name);
            Settings.LoadImpactService.User.FavoritesTests.RemoveAt(indexToDelete);
            Settings.LoadImpactService.User.FavoritesTests.Insert(indexToDelete, testSettingsToSave);
        }

        private void finalGetResultsButton_Click(object sender, EventArgs e)
        {
            TestSettings = GetTestSettings();
            Close();
        }

        private TestSettings GetTestSettings()
        {
            return new TestSettings()
            {
                Name = m_TestMetrics.Name,
                UseAnalisisWithVusNumber = analisisCheckBox1.Checked,
                //StandartMetrics = m_StandartMetricsTable.GetMetricsSettings(),
                //ServerAgentMetrics = m_ServerAgentMetricsTable.GetMetricsSettings(),
                //PageMetrics = m_PageMetricsTable.GetMetricsSettings()
            };
        }
    }
}
