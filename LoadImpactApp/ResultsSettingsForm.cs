using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class ResultsSettingsForm : Form
    {
        private TestSettings m_TestMetrics;
        private MetricsTableLayoutPanel m_StandartMetricsTable;
        private MetricsTableLayoutPanel m_ServerAgentMetricsTable;
        private MetricsTableLayoutPanel m_PageMetricsTable;
        public TestSettings TestSettings { get; set; }

        public ResultsSettingsForm(TestSettings testSettings)
        {
            InitializeComponent();

            m_TestMetrics = testSettings;

            var saveSettingsButton = new Button() { Location = new Point(22, 4), Text = "Save", Enabled = false, BackColor = Color.Transparent };
            saveSettingsButton.Click += SaveSettingsButton_Click;
            panel2.Controls.Add(saveSettingsButton);

            List<string> standartMetrics = null;
            List<string> serverAgentMetrics = null;

            if (testSettings != null)
            {
                saveSettingsButton.Enabled = true;
                analisisCheckBox1.Checked = testSettings.UseAnalisisWithVusNumber;
                analisisCheckBox2.Checked = testSettings.UseAnalisisWithStableSections;

                if (testSettings.StandartMetrics != null)
                {
                    var savedStandartMetricsNames = testSettings.StandartMetrics.Select(metric => metric.Name).ToList();
                    standartMetrics = Settings.LoadImpactService.TimelessMetrics.StandartMetricsInfo
                        .Select(metric => metric.Name).ToList().Except(savedStandartMetricsNames).ToList();
                }

                if (testSettings.ServerAgentMetrics != null)
                {
                    var savedServerAgentMetricsNames = testSettings.ServerAgentMetrics.Select(metric => metric.Name).ToList();
                    serverAgentMetrics = Settings.LoadImpactService.TimelessMetrics.ServerAgentMetricsInfo
                        .Select(metric => metric.Name).ToList().Except(savedServerAgentMetricsNames).ToList();
                }
            }
            else
            {
                standartMetrics = new List<string>(Settings.LoadImpactService.TimelessMetrics.StandartMetricsInfo
                    .Select(metric => metric.Name).ToList());
                serverAgentMetrics = new List<string>(Settings.LoadImpactService.TimelessMetrics.ServerAgentMetricsInfo
                    .Select(metric => metric.Name).ToList());
            }


            m_StandartMetricsTable = new MetricsTableLayoutPanel(MetricsTlpMode.WithLabels, standartMetrics) { BackColor = Color.LemonChiffon };
            m_ServerAgentMetricsTable = new MetricsTableLayoutPanel(MetricsTlpMode.WithLabels, serverAgentMetrics) { BackColor = Color.LightCyan };
            m_PageMetricsTable = new MetricsTableLayoutPanel(MetricsTlpMode.WithTextBoxes) { BackColor = Color.PaleGreen };

            if (testSettings != null)
            {
                m_StandartMetricsTable.AddRangeMetricSettings(testSettings.StandartMetrics);
                m_ServerAgentMetricsTable.AddRangeMetricSettings(testSettings.ServerAgentMetrics);
                m_PageMetricsTable.AddRangeMetricSettings(testSettings.PageMetrics);
            }

            tableLayoutPanel1.Controls.Add(m_StandartMetricsTable, 0, 4);
            tableLayoutPanel1.Controls.Add(m_ServerAgentMetricsTable, 0, 7);
            tableLayoutPanel1.Controls.Add(m_PageMetricsTable, 0, 10);
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
            this.Close();
        }

        private TestSettings GetTestSettings()
        {
            return new TestSettings()
            {
                Name = m_TestMetrics.Name,
                UseAnalisisWithVusNumber = analisisCheckBox1.Checked,
                UseAnalisisWithStableSections = analisisCheckBox2.Checked,
                StandartMetrics = m_StandartMetricsTable.GetMetricsSettings(),
                ServerAgentMetrics = m_ServerAgentMetricsTable.GetMetricsSettings(),
                PageMetrics = m_PageMetricsTable.GetMetricsSettings()
            };
        }
    }
}
