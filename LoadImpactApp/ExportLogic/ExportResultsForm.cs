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

                var service = await GoogleSheets.GetSheetsService();
                var sheets = service.Spreadsheets.Get(spreadSheetId).Execute();

                // Getting sheet title by sheet id
                var sheetTitle = sheets.Sheets.FirstOrDefault(s => s.Properties.SheetId == sheetId)?.Properties.Title;
                if (sheetTitle == null)
                {
                    throw new ArgumentException("Gid in link isn't valid.");
                }

                if (exportFormatComboBox.SelectedIndex == 1)
                {
                    // Getting results from table
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
                           (m_ResultsGrid.Rows[pageMetricsIndex++].Cells[0].Style.BackColor != MetricColor.PageType))
                        ;

                    int i;
                    foreach (var metricName in metricNames)
                    {
                        for (i = 0; i < pageMetricsIndex; i++)
                        {
                            if (m_ResultsGrid.Rows[i].Cells[0].Value == metricName)
                            {
                                break;
                            }
                        }
                        valueRange.Values[0].Add((i < pageMetricsIndex) ? m_ResultsGrid.Rows[i].Cells[2].Value : "-");
                    }



                    var request = service.Spreadsheets.Values.Get(spreadSheetId, $"{sheetTitle}!A1:B");
                    var response = request.Execute();

                    // First step - find row index of our test
                    int rowIndex = -1;
                    for (int i = 0; i < response.Values.Count; i++)
                    {
                        if ((response.Values[i].Count > 0) && (response.Values[i][0].ToString().Contains("SETd34_ss_Login")))
                        {
                            rowIndex = i;
                            break;
                        }
                    }

                    // If we didn't find our test then create
                    if (rowIndex == -1)
                    {

                        var copyFormatRequest = new Request
                        {
                            CopyPaste = new CopyPasteRequest
                            {
                                Source = new GridRange
                                {
                                    SheetId = sheetId,
                                    StartColumnIndex = 0,
                                    EndColumnIndex = 12,
                                    StartRowIndex = response.Values.Count - 1,
                                    EndRowIndex = response.Values.Count
                                },
                                Destination = new GridRange
                                {
                                    SheetId = sheetId,
                                    StartColumnIndex = 0,
                                    EndColumnIndex = 12,
                                    StartRowIndex = response.Values.Count + 1,
                                    EndRowIndex = response.Values.Count + 2
                                },
                                PasteType = "PASTE_FORMAT"
                            }
                        };
                        var batch = new BatchUpdateSpreadsheetRequest();
                        batch.Requests = new List<Request> { copyFormatRequest };
                        service.Spreadsheets.BatchUpdate(batch, spreadSheetId).Execute();


                        /*valueRange.Values[0].Add("fsdf");
                        var a = service.Spreadsheets.Values.Append(valueRange, spreadSheetId, $"{sheetTitle}!A124");
                        a.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
                        a.Execute();*/
                    }
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
