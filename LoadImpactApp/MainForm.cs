using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoadImpactApp.Api;
using LoadImpactApp.DeserializableClasses.Xml;

namespace LoadImpactApp
{
    public partial class MainForm : Form
    {
        private ConnectionForm m_ConnectionForm;
        private BindingSource m_BindingAllTitlesListBox;
        private BindingSource m_BindingFavTitlesListBox;
        private BindingSource m_BindingAllTitlesComboBox;
        private BindingSource m_BindingFavTitlesComboBox;
        private List<string> m_MetricsList = new List<string>() { "CPU", "Memusage" };

        public MainForm(ConnectionForm form)
        {
            m_ConnectionForm = form;
            InitializeComponent();

            // These var's are just for fixing visual border's glitch in TabControls
            var fix = new TabPadding(tabControl1);
            var fix2 = new TabPadding(tabControl2);
            var fix3 = new TabPadding(tabControl3);

            allTestsComboBox.SelectedIndexChanged += TestsComboBoxSelectionIndexChanged;
            favoritesTestsComboBox.SelectedIndexChanged += TestsComboBoxSelectionIndexChanged;

            m_BindingAllTitlesListBox = new BindingSource(CurrentContextData.Titles, null);
            m_BindingAllTitlesComboBox = new BindingSource(CurrentContextData.Titles, null);
            m_BindingFavTitlesListBox = new BindingSource(CurrentContextData.FavoritesTitles, null);
            m_BindingFavTitlesComboBox = new BindingSource(CurrentContextData.FavoritesTitles, null);


            CurrentContextData.FavoritesTitles.AddRange(Settings.LoadImpactService.User.FavoritesTests.
                Select(test => test.Name).ToList());

            //RefreshContainersAsync();
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            await RefreshContainersAsync();
        }

        private void addToFavButton_Click(object sender, EventArgs e)
        {
            foreach (var item in allTestsListBox.SelectedItems)
            {
                if (CurrentContextData.FavoritesTitles.IndexOf(item.ToString()) < 0)
                {
                    CurrentContextData.FavoritesTitles.Add(item.ToString());
                }
            }
            CurrentContextData.FavoritesTitles.Sort();

            favoritesTestsListBox.DataSource = null;
            favoritesTestsComboBox.DataSource = null;
            favoritesTestsListBox.DataSource = m_BindingFavTitlesListBox;
            favoritesTestsComboBox.DataSource = m_BindingFavTitlesComboBox;

            allTestsListBox.ClearSelected();
            SetOptimalComboBoxWidth(favoritesTestsComboBox);
        }

        private void removeFromFavButton_Click(object sender, EventArgs e)
        {
            foreach (var item in favoritesTestsListBox.SelectedItems)
            {
                CurrentContextData.FavoritesTitles.Remove(item.ToString());
            }

            favoritesTestsListBox.DataSource = null;
            favoritesTestsComboBox.DataSource = null;
            favoritesTestsListBox.DataSource = m_BindingFavTitlesListBox;
            favoritesTestsComboBox.DataSource = m_BindingFavTitlesComboBox;

            favoritesTestsListBox.ClearSelected();
            SetOptimalComboBoxWidth(favoritesTestsComboBox);
        }

        private async Task RefreshContainersAsync()
        {
            allTestsListBox.DataSource = null;
            allTestsComboBox.DataSource = null;
            favoritesTestsListBox.DataSource = null;
            favoritesTestsComboBox.DataSource = null;

            await CurrentContextData.RefreshAsync();

            allTestsListBox.DataSource = m_BindingAllTitlesListBox;
            allTestsComboBox.DataSource = m_BindingAllTitlesComboBox;
            favoritesTestsListBox.DataSource = m_BindingFavTitlesListBox;
            favoritesTestsComboBox.DataSource = m_BindingFavTitlesComboBox;

            SetOptimalComboBoxWidth(allTestsComboBox);
            SetOptimalComboBoxWidth(favoritesTestsComboBox);
        }

        private void SetOptimalComboBoxWidth(ComboBox comboBox)
        {
            using (var g = comboBox.CreateGraphics())
            {
                foreach (var item in comboBox.Items)
                {
                    if (g.MeasureString(item.ToString(), comboBox.Font).Width > comboBox.DropDownWidth)
                    {
                        comboBox.DropDownWidth = (int)g.MeasureString(item.ToString(), comboBox.Font).Width;
                    }
                }
            }
        }

        private void getResultsButton_Click(object sender, EventArgs e)
        {
            Settings.Update();

            TestSettings test = null;
            if (Settings.LoadImpactService.User.FavoritesTests != null)
            {
                test = Settings.LoadImpactService.User.FavoritesTests
                    .Find(t => t.Name == ((TestRun)runsListBox.SelectedItem).Title);
            }

            var resultsSettingsForm = new ResultsSettingsForm(test);
            resultsSettingsForm.FormClosing += ResultsSettingsForm_FormClosing;
            resultsSettingsForm.ShowDialog();
        }

        private void ShowRunsOfTest(string testName)
        {
            runsListBox.DataSource = CurrentContextData.GetRunsOfTest(testName);
            runsListBox.DisplayMember = "Ended";
        }

        private void tabControl3_Selecting(object sender, TabControlCancelEventArgs e)
        {
            runsListBox.DataSource = null;
            ((ComboBox)tabControl3.SelectedTab.Controls[0]).SelectedItem = null;
        }

        private void TestsComboBoxSelectionIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem == null)
            {
                runsListBox.DataSource = null;
            }
            else
            {
                ShowRunsOfTest((sender as ComboBox).SelectedItem.ToString());
            }
        }

        private void runsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runsListBox.SelectedItem != null)
            {
                getResultsButton.Enabled = true;
            }
            else
            {
                getResultsButton.Enabled = false;
            }
        }

        private async void ResultsSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var testSettingsToUse = ((ResultsSettingsForm)sender).TestSettings;
            if (testSettingsToUse != null)
            {
                await ShowTestResultsAsync(testSettingsToUse);
            }
        }

        private async Task ShowTestResultsAsync(TestSettings testSettingsToUse)
        {
            while (testResultsDataGridView.RowCount > 0)
            {
                testResultsDataGridView.Rows.RemoveAt(0);
            }

            if (testInfoDataGridView.RowCount > 0)
            {
                testInfoDataGridView.Rows.RemoveAt(0);
            }

            var indexOfConfig = CurrentContextData.TestConfigs.BinarySearch(new TestConfig()
            {
                Name = ((ComboBox)tabControl3.SelectedTab.Controls[0]).SelectedItem.ToString()
            });

            int runId = ((TestRun)runsListBox.SelectedItem).Id;

            testInfoDataGridView.Rows.Add();
            testInfoDataGridView.Rows[0].Cells[0].Value = ((ComboBox)tabControl3.SelectedTab.Controls[0]).SelectedItem.ToString();
            string selectedRunDate = ((TestRun)runsListBox.SelectedItem).Ended;
            testInfoDataGridView.Rows[0].Cells[1].Value = selectedRunDate.Remove(selectedRunDate.Length - 6);

            var vusActiveMetricPoints = await ApiLoadImpact.GetStandartMetricPointsAsync(runId, "VU active");
            int maxVus = (int)vusActiveMetricPoints.First().Points.Max(u => u.Value);
            testInfoDataGridView.Rows[0].Cells[2].Value = maxVus;

            Tuple<long, long> bordersOfAnalisis = null;

            if (testSettingsToUse.UseAnalisisWithVusNumber)
            {
                bordersOfAnalisis = MetricCalculator.GetBordersByStableVusActive(vusActiveMetricPoints.First());
            }

            var notFoundedMetrics = new List<String>();

            foreach (var standartMetric in testSettingsToUse.StandartMetrics)
            {
                var attributes = await ApiLoadImpact.GetStandartMetricPointsAsync(runId, standartMetric.Name);
                if (attributes != null)
                {
                    foreach (var attribute in attributes)
                    {
                        var metricCalculator = new MetricCalculator(attribute, bordersOfAnalisis, 
                            testSettingsToUse.UseAnalisisWithVusNumber, testSettingsToUse.UseAnalisisWithStableSections);

                        AddRowResultsToDataGridView(standartMetric, attribute.AttributeName, metricCalculator,
                            Color.LemonChiffon, Settings.LoadImpactService.TimelessMetrics.StandartMetricsInfo
                                .FirstOrDefault(info => info.Name == standartMetric.Name).Unit);
                    }
                }
                else
                {
                    notFoundedMetrics.Add(standartMetric.Name);
                }
            }

            foreach (var serverAgentMetric in testSettingsToUse.ServerAgentMetrics)
            {
                string serverAgentLabelName = serverAgentMetric.Name;

                foreach (var serverAgent in CurrentContextData.TestConfigs[indexOfConfig].ServerMetricAgents)
                {
                    var attributes = await ApiLoadImpact.GetServerAgentMetricPointsAsync(runId, serverAgent, serverAgentLabelName);
                    if (attributes != null)
                    {
                        serverAgentMetric.Name = serverAgentLabelName + " " + serverAgent;
                        foreach (var attribute in attributes)
                        {
                            var metricCalculator = new MetricCalculator(attribute, bordersOfAnalisis,
                                testSettingsToUse.UseAnalisisWithVusNumber, testSettingsToUse.UseAnalisisWithStableSections);

                            AddRowResultsToDataGridView(serverAgentMetric, attribute.AttributeName, metricCalculator,
                                Color.LightCyan, Settings.LoadImpactService.TimelessMetrics.ServerAgentMetricsInfo
                                    .FirstOrDefault(info => info.Name == serverAgentLabelName).Unit);
                        }
                    }
                    else
                    {
                        notFoundedMetrics.Add(serverAgentLabelName + " " + serverAgent);
                    }
                }
            }

            foreach (var pageMetric in testSettingsToUse.PageMetrics)
            {
                var attributes = await ApiLoadImpact.GetPageMetricPointsAsync(runId, pageMetric.Name, 
                    CurrentContextData.TestConfigs[indexOfConfig].UserScenarioId);

                if (attributes != null)
                {
                    foreach (var attribute in attributes)
                    {
                        var metricCalculator = new MetricCalculator(attribute, bordersOfAnalisis,
                            testSettingsToUse.UseAnalisisWithVusNumber, testSettingsToUse.UseAnalisisWithStableSections);

                        AddRowResultsToDataGridView(pageMetric, attribute.AttributeName, metricCalculator, Color.PaleGreen, "sec");
                    }
                }
                else
                {
                    notFoundedMetrics.Add(pageMetric.Name);
                }
            }

            foreach (var metric in notFoundedMetrics)
            {
                testResultsDataGridView.Rows.Add();
                testResultsDataGridView.Rows[testResultsDataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Silver;
                testResultsDataGridView.Rows[testResultsDataGridView.Rows.Count - 1].Cells[0].Value = metric + " (Not found)";
            }
        }

        private void AddRowResultsToDataGridView(MetricSettings metricSettings, string attributeName, MetricCalculator mc, Color color, string unit)
        {
            testResultsDataGridView.Rows.Add();
            int index = testResultsDataGridView.Rows.Count - 1;

            testResultsDataGridView.Rows[index].DefaultCellStyle.BackColor = color;
            testResultsDataGridView.Rows[index].Cells[0].Value = metricSettings.Name + $" ({attributeName})";

            if (metricSettings.Min)
            {
                testResultsDataGridView.Rows[index].Cells[1].Value = Math.Round(mc.Min(), metricSettings.Precision);
            }
            else
            {
                testResultsDataGridView.Rows[index].Cells[1].Value = "-";
            }

            if (metricSettings.Avg)
            {
                testResultsDataGridView.Rows[index].Cells[2].Value = Math.Round(mc.Median(), metricSettings.Precision);
            }
            else
            {
                testResultsDataGridView.Rows[index].Cells[2].Value = "-";
            }

            if (metricSettings.Max)
            {
                testResultsDataGridView.Rows[index].Cells[3].Value = Math.Round(mc.Max(), metricSettings.Precision);
            }
            else
            {
                testResultsDataGridView.Rows[index].Cells[3].Value = "-";
            }

            testResultsDataGridView.Rows[index].Cells[4].Value = unit;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Settings.Update();
            Settings.SaveToFile("UserSettings.xml");
            this.Visible = false;
            m_ConnectionForm.Visible = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Update();
            Settings.SaveToFile("UserSettings.xml");
            Application.Exit();
        }
    }
}
