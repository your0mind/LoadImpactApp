using Google;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using LoadImpactApp.ExportLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

            if (UserSettings.LoadImpactService.User.ExportSettings.ExportFormat == "FLS QA")
            {
                exportFormatComboBox.SelectedIndex = 1;
            }

            linkTextBox.Text = UserSettings.LoadImpactService.User.ExportSettings.SpreadsheetLink;
            sprintTextBox.Text = UserSettings.LoadImpactService.User.ExportSettings.Sprint;

            exportButton.Select();
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
            UserSettings.LoadImpactService.User.ExportSettings.SpreadsheetLink = linkTextBox.Text;
            UserSettings.LoadImpactService.User.ExportSettings.ExportFormat = exportFormatComboBox.SelectedItem.ToString();
            UserSettings.LoadImpactService.User.ExportSettings.Sprint = sprintTextBox.Text;
            UserSettings.Update();
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
                    await ExportResultsWithFlsFormatAsync(sheet, spreadSheetId, service);
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
                else if ((ex is GoogleApiException) || (ex is TokenResponseException))
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
            Close();
        }

        private GridRange GetMergedRangeByCell(int column, int row, IList<GridRange> merges)
        {
            foreach (var merge in merges)
            {
                if ((column >= merge.StartColumnIndex) && (column < merge.EndColumnIndex) &&
                    (row >= merge.StartRowIndex) && (row < merge.EndRowIndex))
                {
                    return merge;
                }
            }
            return null;
        }

        private async Task ExportResultsWithFlsFormatAsync(Sheet sheet, string spreadSheetId, SheetsService service)
        {
            // The range of values which we will be writed
            var valueRange = new ValueRange();
            valueRange.Values = new List<IList<object>>();
            valueRange.Values.Add(new List<object>());

            // Getting results from table
            valueRange.Values[0].Add("");
            valueRange.Values[0].Add(sprintTextBox.Text);
            valueRange.Values[0].Add(m_InfoGrid.Rows[0].Cells[3].Value);

            var metricNames = new List<object>
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

            foreach (var metricName in metricNames)
            {
                int i;
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
            for (int i = pageMetricsIndex; i < m_ResultsGrid.Rows.Count; i++)
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
            var getDataRequest = service.Spreadsheets.Values.Get(spreadSheetId, $"{sheet.Properties.Title}!A1:B");
            getDataRequest.MajorDimension = GetRequest.MajorDimensionEnum.COLUMNS;
            var response = await getDataRequest.ExecuteAsync();

            if ((response.Values == null) || (response.Values.Count < 2))
            {
                throw new ApplicationException("Can't recognize Google spreadsheet.");
            }

            // Alignment of arrived data
            int lastRow = response.Values[0].Count;
            while ((lastRow - 1 >= 0) && (response.Values[0][lastRow-- - 1].Equals(""))) ;
            var lastTestTitleMergedRange = GetMergedRangeByCell(0, lastRow, sheet.Merges);
            if (lastTestTitleMergedRange != null)
            {
                lastRow = lastTestTitleMergedRange.EndRowIndex - 1 ?? default(int);
            }

            if (lastRow + 1 < response.Values[0].Count)
            {
                for (int i = response.Values[0].Count - 1; i >= lastRow + 1; i--)
                {
                    response.Values[0].RemoveAt(i);
                }
            }
            else
            {
                for (int i = response.Values[0].Count; i < lastRow + 1; i++)
                {
                    response.Values[0].Add("");
                }
            }

            if (lastRow + 1 < response.Values[1].Count)
            {
                for (int i = response.Values[1].Count - 1; i >= lastRow + 1; i--)
                {
                    response.Values[1].RemoveAt(i);
                }
            }
            else
            {
                for (int i = response.Values[1].Count; i < lastRow + 1; i++)
                {
                    response.Values[1].Add("");
                }
            }

            // First step - find row index of our test
            int rowIndexOfTestTitle = -1;
            for (int i = 0; i < response.Values[0].Count; i++)
            {
                if (response.Values[0][i].ToString().Contains(m_InfoGrid.Rows[0].Cells[1].Value.ToString()))
                {
                    rowIndexOfTestTitle = i;
                    break;
                }
            }

            // Steps
            Request addRowsRequest = null;
            Request copyFormattingRequest = null;
            Request clearFormattingRequest = null;
            Request mergeTestTitleRequest = null;
            Request mergeSprintCellsRequest = null;
            var paintSprintCellsRequests = new List<Request>();

            // If we didn't find our test then create
            int rowIndexToInsertData;
            if (rowIndexOfTestTitle == -1)
            {
                rowIndexOfTestTitle = rowIndexToInsertData = lastRow + 2;

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

                // Updating the arrived data
                response.Values[0].Add("");
                response.Values[1].Add("");
                response.Values[0].Add(valueRange.Values[0][0]);
                response.Values[1].Add(valueRange.Values[0][1]);
            }
            else
            {
                // Searching a row which will be processed
                var mergedRange = GetMergedRangeByCell(0, rowIndexOfTestTitle, sheet.Merges);
                rowIndexToInsertData = (mergedRange != null) ?
                    mergedRange.EndRowIndex ?? default(int) : rowIndexOfTestTitle + 1;

                // Creating some formatting requests
                mergeTestTitleRequest = new Request
                {
                    MergeCells = new MergeCellsRequest
                    {
                        MergeType = "MERGE_ALL",
                        Range = new GridRange
                        {
                            SheetId = sheet.Properties.SheetId,
                            StartColumnIndex = 0,
                            EndColumnIndex = 1,
                            StartRowIndex = rowIndexOfTestTitle,
                            EndRowIndex = rowIndexToInsertData + 1
                        }
                    }
                };

                // Updating the arrived data
                response.Values[0].Insert(rowIndexToInsertData, "");
                response.Values[1].Insert(rowIndexToInsertData, "");

                // If results with this sprint is already exists then merge sprint cells
                int rowIndexOfPrevSprint = (rowIndexToInsertData > response.Values[1].Count) ?
                    response.Values[1].Count : rowIndexToInsertData;

                while ((--rowIndexOfPrevSprint > 0) && (response.Values[1][rowIndexOfPrevSprint].Equals(""))) ;
                if (response.Values[1][rowIndexOfPrevSprint].Equals(valueRange.Values[0][1]))
                {
                    mergeSprintCellsRequest = new Request
                    {
                        MergeCells = new MergeCellsRequest
                        {
                            MergeType = "MERGE_ALL",
                            Range = new GridRange
                            {
                                SheetId = sheet.Properties.SheetId,
                                StartColumnIndex = 1,
                                EndColumnIndex = 2,
                                StartRowIndex = rowIndexOfPrevSprint,
                                EndRowIndex = rowIndexToInsertData + 1
                            }
                        }
                    };
                }
                else
                {
                    response.Values[1][rowIndexToInsertData] = valueRange.Values[0][1];
                }
            }

            addRowsRequest = new Request();
            if (rowIndexToInsertData < sheet.Properties.GridProperties.RowCount)
            {
                addRowsRequest.InsertDimension = new InsertDimensionRequest
                {
                    Range = new DimensionRange
                    {
                        Dimension = "ROWS",
                        SheetId = sheet.Properties.SheetId,
                        StartIndex = rowIndexToInsertData,
                        EndIndex = rowIndexToInsertData + 1
                    }
                };
            }
            else
            {
                addRowsRequest.AppendDimension = new AppendDimensionRequest
                {
                    SheetId = sheet.Properties.SheetId,
                    Dimension = "ROWS",
                    Length = rowIndexToInsertData - sheet.Properties.GridProperties.RowCount + 1
                };
            }

            copyFormattingRequest = new Request
            {
                CopyPaste = new CopyPasteRequest
                {
                    Source = new GridRange
                    {
                        SheetId = sheet.Properties.SheetId,
                        StartColumnIndex = 0,
                        EndColumnIndex = 12,
                        StartRowIndex = 2,
                        EndRowIndex = 3
                    },
                    Destination = new GridRange
                    {
                        SheetId = sheet.Properties.SheetId,
                        StartColumnIndex = 0,
                        EndColumnIndex = 12,
                        StartRowIndex = rowIndexToInsertData,
                        EndRowIndex = rowIndexToInsertData + 1
                    },
                    PasteType = "PASTE_FORMAT"
                }
            };

            var batchRequests = new BatchUpdateSpreadsheetRequest();
            batchRequests.Requests = new List<Request>
                    {
                        addRowsRequest,
                        copyFormattingRequest
                    };

            // Clear formatting in row that will be created by append request
            if ((addRowsRequest.AppendDimension != null) && (addRowsRequest.AppendDimension.Length == 2))
            {
                clearFormattingRequest = new Request
                {
                    UpdateCells = new UpdateCellsRequest
                    {
                        Range = new GridRange
                        {
                            SheetId = sheet.Properties.SheetId,
                            StartColumnIndex = 0,
                            StartRowIndex = rowIndexToInsertData - 1,
                            EndRowIndex = rowIndexToInsertData
                        },
                        Fields = "*"
                    }
                };
                batchRequests.Requests.Add(clearFormattingRequest);
            }

            if (mergeTestTitleRequest != null)
            {
                batchRequests.Requests.Add(mergeTestTitleRequest);
            }

            if (mergeSprintCellsRequest != null)
            {
                batchRequests.Requests.Add(mergeSprintCellsRequest);
            }

            // Select the cells that will be repainted
            var sprintsGridRanges = new List<GridRange>();
            int lastEndRowIndex = rowIndexToInsertData + 1;
            for (int i = rowIndexToInsertData; i >= rowIndexOfTestTitle; i--)
            {
                if (!response.Values[1][i].Equals(""))
                {
                    sprintsGridRanges.Add(new GridRange
                    {
                        SheetId = sheet.Properties.SheetId,
                        StartColumnIndex = 1,
                        EndColumnIndex = 2,
                        StartRowIndex = i,
                        EndRowIndex = lastEndRowIndex
                    });

                    if (sprintsGridRanges.Count == 3)
                    {
                        break;
                    }

                    lastEndRowIndex = i;
                }
            }

            // Getting cell positions from which the style will be copied
            var rowIndexesOfSprintCells = new List<int>();
            var finalRowIndexesOfSprintCells = new List<int>();
            for (int i = response.Values[1].Count - 1; i > 1; i--)
            {
                if ((i >= rowIndexOfTestTitle) && (i <= rowIndexToInsertData))
                {
                    continue;
                }

                if (!response.Values[1][i].Equals(""))
                {
                    rowIndexesOfSprintCells.Add(i);

                    if (rowIndexesOfSprintCells.Count == sprintsGridRanges.Count)
                    {
                        finalRowIndexesOfSprintCells = new List<int>(rowIndexesOfSprintCells);
                        break;
                    }
                }

                if (!response.Values[0][i].Equals(""))
                {
                    if (rowIndexesOfSprintCells.Count > finalRowIndexesOfSprintCells.Count)
                    {
                        finalRowIndexesOfSprintCells = new List<int>(rowIndexesOfSprintCells);
                    }
                    rowIndexesOfSprintCells.Clear();
                }
            }

            // Creating requests of copying sprint cells formatting
            for (int i = 0; i < (sprintsGridRanges.Count) && (i < finalRowIndexesOfSprintCells.Count); i++)
            {
                paintSprintCellsRequests.Add(new Request
                {
                    CopyPaste = new CopyPasteRequest
                    {
                        Source = new GridRange
                        {
                            SheetId = sheet.Properties.SheetId,
                            StartColumnIndex = 1,
                            EndColumnIndex = 2,
                            StartRowIndex = finalRowIndexesOfSprintCells[i],
                            EndRowIndex = finalRowIndexesOfSprintCells[i] + 1
                        },
                        Destination = sprintsGridRanges[i],
                        PasteType = "PASTE_FORMAT"
                    }
                });
            }

            foreach (var request in paintSprintCellsRequests)
            {
                batchRequests.Requests.Add(request);
            }

            var batchRequestsTask = service.Spreadsheets.BatchUpdate(batchRequests, spreadSheetId).ExecuteAsync();
            // Sending our test's results
            var appendValuesRequest = service.Spreadsheets.Values.Update(valueRange, spreadSheetId,
                $"{sheet.Properties.Title}!A{rowIndexToInsertData + 1}");
            appendValuesRequest.ValueInputOption = UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var appendValuesTask = appendValuesRequest.ExecuteAsync();

            batchRequestsTask.Wait();
            appendValuesTask.Wait();
        }
    }
}
