using System;
using System.Windows.Forms;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using LoadImpactApp.ExportLogic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

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
                var title = sheets.Sheets.FirstOrDefault(s => s.Properties.SheetId == sheetId)?.Properties.Title;

                if (title == null)
                {
                    throw new ArgumentException("Gid in link isn't valid.");
                }

                if (exportFormatComboBox.SelectedIndex == 1)
                {
                    var request = service.Spreadsheets.Values.Get(spreadSheetId, title + "!A");
                    var response = request.Execute();

                    /*var valueRange = new ValueRange();
                    List<object> values = new List<object>() { 3, 3 };
                    valueRange.Values = new List<IList<object>> { values };

                    var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadSheetId, range);
                    appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    var appendReponse = appendRequest.Execute();*/
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
