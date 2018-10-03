using System;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace LoadImpactApp
{
    public partial class ExportResultsForm : Form
    {
        private static SheetsService m_SheetsService = GetSheetsService();
        private List<string> m_ExtractFormatList;

        public ExportResultsForm()
        {
            InitializeComponent();
            m_ExtractFormatList = new List<string>() { "Default", "FLS QA" };
            extractFormatComboBox.DataSource = m_ExtractFormatList;

            if (Settings.LoadImpactService.User.ExportSettings.ExportFormat == "FLS QA")
            {
                extractFormatComboBox.SelectedIndex = 1;
            }

            linkTextBox.Text = Settings.LoadImpactService.User.ExportSettings.SpreadsheetLink;
            sprintTextBox.Text = Settings.LoadImpactService.User.ExportSettings.Sprint;
        }

        private static SheetsService GetSheetsService()
        {
            UserCredential credential;
            try
            {
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new string[] { SheetsService.Scope.Spreadsheets },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                return new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    //ApplicationName = ApplicationName,
                });
            }
            catch (FileNotFoundException)
            {

            }

        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            String spreadsheetId = "1iZpXC6I1aJFAmqA1k9QCtpkDIa80t2w1xAjUAlhl32E";
            String range = "Main metrics!A9:B9";

            var valueRange = new ValueRange();
            List<object> values = new List<object>() { 3, 3 };
            valueRange.Values = new List<IList<object>> { values };

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        private void extractFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
            Settings.LoadImpactService.User.ExportSettings.ExportFormat = extractFormatComboBox.SelectedItem.ToString();
            Settings.LoadImpactService.User.ExportSettings.Sprint = sprintTextBox.Text;
            Settings.Update();
        }
    }
}
