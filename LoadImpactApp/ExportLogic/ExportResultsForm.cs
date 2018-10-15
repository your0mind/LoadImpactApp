using Google;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using LoadImpactApp.ExportLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace LoadImpactApp
{
    public partial class ExportResultsForm : Form
    {
        private List<string> m_ExtractFormatList;
        private DataGridView m_InfoGrid;
        private DataGridView m_ResultsGrid;

        public ExportResultsForm(DataGridView infoGrid, DataGridView resultsGrid)
        {
            InitializeComponent();
            m_InfoGrid = infoGrid;
            m_ResultsGrid = resultsGrid;
            m_ExtractFormatList = new List<string>() { "Default", "FLS QA" };
            exportFormatComboBox.DataSource = m_ExtractFormatList;

            if (Settings.LoadImpactService.User.ExportSettings.ExportFormat == "FLS QA")
            {
                exportFormatComboBox.SelectedIndex = 1;
            }

            linkTextBox.Text = Settings.LoadImpactService.User.ExportSettings.SpreadsheetLink;
            sprintTextBox.Text = Settings.LoadImpactService.User.ExportSettings.Sprint;
        }

        private void exportFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 1)
            {
                sprintLabel.Show();
                sprintTextBox.Show();
            }
            else
            {
                sprintLabel.Hide();
                sprintTextBox.Hide();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.LoadImpactService.User.ExportSettings.SpreadsheetLink = linkTextBox.Text;
            Settings.LoadImpactService.User.ExportSettings.ExportFormat = exportFormatComboBox.SelectedItem.ToString();
            Settings.LoadImpactService.User.ExportSettings.Sprint = sprintTextBox.Text;
            Settings.Update();
        }

        private async void exportButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                var spreadSheetReg = new Regex(@"/spreadsheets/d/([a-zA-Z0-9-_]+).*gid=(\d+)");
                var match = spreadSheetReg.Match(linkTextBox.Text);
                string spreadSheetId;
                int sheetId;

                // The range of values that we will write
                var valueRange = new ValueRange();
                valueRange.Values = new List<IList<object>>();
                valueRange.Values.Add(new List<object>());

                if (match.Success)
                {
                    spreadSheetId = match.Groups[1].Value;
                    sheetId = Int32.Parse(match.Groups[2].Value);
                }
                else
                {
                    throw new ArgumentException("Link to spreadsheet isn't valid.");
                }

                var service = await GoogleSheets.GetSheetsServiceAsync();
                var sheets = await service.Spreadsheets.Get(spreadSheetId).ExecuteAsync();

                // Getting sheet title by sheet id
                var sheet = sheets.Sheets.FirstOrDefault(s => s.Properties.SheetId == sheetId);
                if (sheet == null)
                {
                    throw new ArgumentException("Gid in link isn't valid.");
                }

                if (exportFormatComboBox.SelectedIndex == 1)
                {
                    // Getting results from table
                    valueRange.Values[0].Add("");
                    valueRange.Values[0].Add(sprintTextBox.Text);
                    valueRange.Values[0].Add(m_InfoGrid.Rows[0].Cells[3].Value);

                    var metricNames = new List<object>()
                    {
                        "Requests/second (avg)",
                        "CPU EPWEBCAP01 (avg)",
                        "CPU EPWEBCAP02 (avg)",
                        "CPU EPWEBCAP01 (max)",
                        "CPU EPWEBCAP02 (max)",
                        "Memusage EPWEBCAP01 (avg)",
                        "Memusage EPWEBCAP02 (avg)"
                    };

                    int pageMetricsIndex = 0;
                    while ((pageMetricsIndex < m_ResultsGrid.Rows.Count) &&
                           (m_ResultsGrid.Rows[pageMetricsIndex++].InheritedStyle.BackColor != MetricColor.PageType))
                        ;

                    int i;
                    foreach (var metricName in metricNames)
                    {
                        for (i = 0; i < pageMetricsIndex; i++)
                        {
                            if (m_ResultsGrid.Rows[i].Cells[0].Value.Equals(metricName))
                            {
                                break;
                            }
                        }
                        valueRange.Values[0].Add((i < pageMetricsIndex) ? m_ResultsGrid.Rows[i].Cells[2].Value : "-");
                    }

                    string testName;
                    string pageMetricResults = "";
                    var pageMetricsWithoutPrefix = new List<string>();
                    for (i = pageMetricsIndex; i < m_ResultsGrid.Rows.Count; i++)
                    {
                        testName = m_ResultsGrid.Rows[i].Cells[0].Value.ToString();
                        if (testName.Substring(testName.Length - 5) == "(avg)")
                        {
                            pageMetricsWithoutPrefix.Add(testName.Substring(6, testName.Length - 12));
                            pageMetricResults += m_ResultsGrid.Rows[i].Cells[2].Value.ToString() + " / ";
                        }
                    }
                    pageMetricResults = (pageMetricResults.Length > 2) ?
                        pageMetricResults.Substring(0, pageMetricResults.Length - 3) : "-";
                    valueRange.Values[0].Add(pageMetricResults);
                    valueRange.Values[0].Add(m_InfoGrid.Rows[0].Cells[2].Value);

                    // Getting 2 columns from our spreadsheet
                    var response = await service.Spreadsheets.Values.Get(spreadSheetId, $"{sheet.Properties.Title}!A1:B").ExecuteAsync();

                    // First step - find row index of our test
                    int rowIndex = -1;
                    for (i = 0; i < response.Values.Count; i++)
                    {
                        if ((response.Values[i].Count > 0) &&
                            (response.Values[i][0].ToString().Contains(m_InfoGrid.Rows[0].Cells[0].Value.ToString())))
                        {
                            rowIndex = i;
                            break;
                        }
                    }

                    // If we didn't find our test then create
                    var batch = new BatchUpdateSpreadsheetRequest();
                    batch.Requests = new List<Request>();
                    if (rowIndex == -1)
                    {
                        // Creating test title
                        string testTitle = $"{m_InfoGrid.Rows[0].Cells[0].Value}\n";
                        if (pageMetricsWithoutPrefix.Count > 1)
                        {
                            testTitle += "( ";
                            foreach (var metricName in pageMetricsWithoutPrefix)
                            {
                                testTitle += metricName + " / ";
                            }
                            testTitle = testTitle.Substring(0, testTitle.Length - 2);
                            testTitle += ")\n";
                        }
                        testTitle += $"\nID: {m_InfoGrid.Rows[0].Cells[1].Value}";
                        valueRange.Values[0][0] = testTitle;

                        rowIndex = response.Values.Count + 2;
                    }
                    else
                    {
                        // Searching a row which wiil be processed
                        int rowIndexOfTitle = rowIndex;
                        foreach (var merge in sheet.Merges)
                        {
                            if ((merge.StartColumnIndex == 0) && (merge.EndColumnIndex == 1) &&
                                (rowIndexOfTitle >= merge.StartRowIndex) && (rowIndexOfTitle < merge.EndRowIndex))
                            {
                                rowIndex = merge.EndRowIndex ?? default(int);
                                break;
                            }
                        }

                        if (rowIndex == rowIndexOfTitle)
                        {
                            rowIndex++;
                        }

                        // Creating some formatting requests
                        var insertRowRequest = new Request
                        {
                            InsertDimension = new InsertDimensionRequest
                            {
                                Range = new DimensionRange
                                {
                                    Dimension = "ROWS",
                                    SheetId = sheetId,
                                    StartIndex = rowIndex,
                                    EndIndex = rowIndex + 1
                                }
                            },
                        };
                        batch.Requests.Add(insertRowRequest);

                        var mergeTestTitleRequest = new Request
                        {
                            MergeCells = new MergeCellsRequest
                            {
                                MergeType = "MERGE_ALL",
                                Range = new GridRange
                                {
                                    SheetId = sheetId,
                                    StartColumnIndex = 0,
                                    EndColumnIndex = 1,
                                    StartRowIndex = rowIndexOfTitle,
                                    EndRowIndex = rowIndex + 1
                                }
                            }
                        };
                        batch.Requests.Add(mergeTestTitleRequest);

                        // If results with this sprint is already exists then merge sprint cells
                        //if (response.Values[rowIndex - 1][1].Equals(valueRange.Values[0][1]))
                        //{
                        //    var mergeSprintCellsRequest = new Request
                        //    {
                        //        MergeCells = new MergeCellsRequest
                        //        {
                        //            MergeType = "MERGE_ALL",
                        //            Range = new GridRange
                        //            {
                        //                SheetId = sheetId,
                        //                StartColumnIndex = 1,
                        //                EndColumnIndex = 2,
                        //                StartRowIndex = rowIndex - 1,
                        //                EndRowIndex = rowIndex + 1
                        //            }
                        //        }
                        //    };
                        //    batch.Requests.Add(mergeSprintCellsRequest);
                        //}
                    }

                    var copyFormatRequest = new Request
                    {
                        CopyPaste = new CopyPasteRequest
                        {
                            Source = new GridRange
                            {
                                SheetId = sheetId,
                                StartColumnIndex = 0,
                                EndColumnIndex = 12,
                                StartRowIndex = 2,
                                EndRowIndex = 3
                            },
                            Destination = new GridRange
                            {
                                SheetId = sheetId,
                                StartColumnIndex = 0,
                                EndColumnIndex = 12,
                                StartRowIndex = rowIndex,
                                EndRowIndex = rowIndex + 1
                            },
                            PasteType = "PASTE_FORMAT"
                        }
                    };

                    if (batch.Requests.Count > 0)
                    {
                        batch.Requests.Insert(1, copyFormatRequest);
                    }
                    else
                    {
                        batch.Requests.Add(copyFormatRequest);
                    }
                    service.Spreadsheets.BatchUpdate(batch, spreadSheetId).ExecuteAsync();

                    // Sending our test's results
                    var appendValuesRequest = service.Spreadsheets.Values.Append(valueRange, spreadSheetId,
                        $"{sheet.Properties.Title}!A{rowIndex}");
                    appendValuesRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
                    appendValuesRequest.ExecuteAsync();
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                string message = null;
                if (ex is OperationCanceledException)
                {
                    message = ex.Message + " Timeout of authorize.";
                }
                else if (ex is GoogleApiException)
                {
                    message = ((GoogleApiException)ex).Error.Message +
                        "\n\nIf you want to change your Google account, then delete the 'google-token' folder " +
                        "in the folder of executable file and try to export results again.";
                }
                else
                {
                    message = ex.Message;
                }

                MessageBox.Show(message, "Exporting results", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Enabled = true;
        }
    }
}
