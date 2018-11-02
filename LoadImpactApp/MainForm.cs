using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoadImpactApp.Api;
using LoadImpactApp.DeserializableClasses.Xml;
using LoadImpactApp.MathLogic;

namespace LoadImpactApp
{
    public partial class MainForm : Form
    {
        private ConnectionForm m_ConnectionForm;
        private BindingSource m_BindingAllTitlesListBox;
        private BindingSource m_BindingFavTitlesListBox;
        private BindingSource m_BindingAllTitlesComboBox;
        private BindingSource m_BindingFavTitlesComboBox;

        public MainForm(ConnectionForm form)
        {
            m_ConnectionForm = form;
            InitializeComponent();

            // These var's are just for fixing visual border's glitch in TabControls
            var fix = new TabPadding(tabControl1);
            var fix2 = new TabPadding(tabControl2);
            var fix3 = new TabPadding(testsTabControl);

            testInfoDataGridView.RowsAdded += TestInfoDataGridView_RowsAdded;

            allTestsComboBox.SelectedIndexChanged += TestsComboBoxSelectionIndexChanged;
            favoritesTestsComboBox.SelectedIndexChanged += TestsComboBoxSelectionIndexChanged;

            m_BindingAllTitlesListBox = new BindingSource(CurrentContextData.Titles, null);
            m_BindingAllTitlesComboBox = new BindingSource(CurrentContextData.Titles, null);
            m_BindingFavTitlesListBox = new BindingSource(CurrentContextData.FavoritesTitles, null);
            m_BindingFavTitlesComboBox = new BindingSource(CurrentContextData.FavoritesTitles, null);

            CurrentContextData.FavoritesTitles.AddRange(Settings.LoadImpactService.User.FavoritesTests.
                Select(test => test.Name).ToList());

            RefreshContainersAsync();
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
            refreshButton.Enabled = false;

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

            refreshButton.Enabled = true;
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

            var resultsSettingsForm = new ResultsSettingsForm(((TestRun)runsListBox.SelectedItem).Title);
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
            ((ComboBox)testsTabControl.SelectedTab.Controls[0]).SelectedItem = null;
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
            getResultsButton.Enabled = (runsListBox.SelectedItem != null) ? true : false;
        }

        private async void ResultsSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var testSettingsToUse = ((ResultsSettingsForm)sender).GetTestSettings();
            if (testSettingsToUse != null)
            {
                await ShowTestResultsAsync(testSettingsToUse);
            }
        }

        private async Task ShowTestResultsAsync(TestSettings testSettingsToUse)
        {
            Enabled = false;

            testInfoDataGridView.Rows.Clear();
            testResultsDataGridView.Rows.Clear();

            //while (testResultsDataGridView.RowCount > 0)
            //{
            //    testResultsDataGridView.Rows.RemoveAt(0);
            //}

            //if (testInfoDataGridView.RowCount > 0)
            //{
            //    testInfoDataGridView.Rows.RemoveAt(0);
            //}

            var indexOfConfig = CurrentContextData.TestConfigs.BinarySearch(new TestConfig()
            {
                Name = ((ComboBox)testsTabControl.SelectedTab.Controls[0]).SelectedItem.ToString()
            });

            int runId = ((TestRun)runsListBox.SelectedItem).Id;
            var vusActivePointsPacks = await ApiLoadImpact.GetStandartMetricPointsAsync(runId, "VU active");
            var vusActivePoints = vusActivePointsPacks[0].Points;

            var borders = MetricCalculator.GetBordersByStableVusActive(vusActivePointsPacks[0]);
            long durationOfStablePart = borders.Item2 - borders.Item1;
            long allRunDuration = vusActivePoints[vusActivePoints.Count - 1].Timestamp - vusActivePoints[0].Timestamp;

            object testName = ((ComboBox)testsTabControl.SelectedTab.Controls[0]).SelectedItem;
            int testId = CurrentContextData.TestConfigs[indexOfConfig].TestId;
            string runDate = ((TestRun)runsListBox.SelectedItem).Ended.Substring(0, 12);
            int vusMax = (int)vusActivePoints.Max(u => u.Value);
            double areaOfStableVusActive = 100.0 * durationOfStablePart / allRunDuration;

            var areaCellColor = (areaOfStableVusActive > 50)
                ? Color.Green
                : (areaOfStableVusActive > 10)
                    ? Color.Orange
                    : Color.Red;

            testInfoDataGridView.Rows.Add(
                testName,
                testId,
                runDate,
                vusMax,
                areaOfStableVusActive
            );
            testInfoDataGridView.Rows[0].Cells[4].Style.ForeColor = areaCellColor;

            var lostMetrics = new List<String>();

            foreach (var standardMetric in testSettingsToUse.StandartMetrics)
            {
                try
                {
                    var pointsPacks = await ApiLoadImpact.GetStandartMetricPointsAsync(runId, standardMetric.Name);
                    foreach (var pointsPack in pointsPacks)
                    {
                        var processedPointsPack = pointsPack;
                        if (testSettingsToUse.UseAnalisisWithVusNumber)
                        {
                            processedPointsPack = processedPointsPack.GetPartByTimeBorders(borders);
                        }

                        IMetricCalcStrategy calcStrategy = new MetricClassicCalcStrategy();
                        if (standardMetric.LookForStability)
                        {
                            processedPointsPack = processedPointsPack.GetAvgChunkPoints(25);
                            calcStrategy = new MetricStrangeCalcStrategy();
                        }
                        else
                        {
                            calcStrategy = new MetricClassicCalcStrategy();
                        }

                        var metricCalculator = new MetricCalculator(processedPointsPack, calcStrategy);
                        var stats = metricCalculator.GetStats();

                        AddRowResultsToDataGridView(stats, standardMetric, pointsPack.AttributeName, MetricColor.StandardType, 
                            Settings.LoadImpactService.TimelessMetrics.StandartMetrics
                                .FirstOrDefault(info => info.Name == standardMetric.Name).Unit);
                    }
                }
                catch (InvalidOperationException)
                {
                    lostMetrics.Add(standardMetric.Name);
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
                            attribute = testSettingsToUse.UseAnalisisWithVusNumber
                            var metricCalculator = new MetricCalculator(attribute, bordersOfAnalisis,
                                testSettingsToUse.UseAnalisisWithVusNumber, serverAgentMetric.LookForStability);

                            AddRowResultsToDataGridView(serverAgentMetric, attribute.AttributeName, metricCalculator,
                                MetricColor.ServerAgentType, Settings.LoadImpactService.TimelessMetrics.ServerAgentMetrics
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
                            testSettingsToUse.UseAnalisisWithVusNumber, pageMetric.LookForStability);

                        AddRowResultsToDataGridView(pageMetric, attribute.AttributeName, metricCalculator, MetricColor.PageType, "sec");
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

            exportResultsButton.Select();
            Enabled = true;
        }

        private void AddRowResultsToDataGridView(MetricStats ms, MetricSettings metricSettings, string attributeName, Color color, string unit)
        {
            testResultsDataGridView.Rows.Add();
            int index = testResultsDataGridView.Rows.Count - 1;

            testResultsDataGridView.Rows[index].DefaultCellStyle.BackColor = color;
            testResultsDataGridView.Rows[index].Cells[0].Value = metricSettings.Name + $" ({attributeName})";
            testResultsDataGridView.Rows[index].Cells[1].Value = (metricSettings.Min)
                ? (object)Math.Round(mc.Min(), metricSettings.Precision)
                : (object)"-";
            testResultsDataGridView.Rows[index].Cells[2].Value = (metricSettings.Median)
                ? (object)Math.Round(mc.Median(), metricSettings.Precision)
                : (object)"-";
            testResultsDataGridView.Rows[index].Cells[3].Value = (metricSettings.Max)
                ? (object)Math.Round(mc.Max(), metricSettings.Precision)
                : (object)"-";
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

        private void TestInfoDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            exportResultsButton.Enabled = true;
        }

        private void exportResultsButton_Click(object sender, EventArgs e)
        {
            var exportResultsForm = new ExportResultsForm(testInfoDataGridView, testResultsDataGridView);
            exportResultsForm.ShowDialog();
        }
    }
}
