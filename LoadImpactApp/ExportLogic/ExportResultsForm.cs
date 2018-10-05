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

namespace LoadImpactApp
{
    public partial class ExportResultsForm : Form
    {
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

        private void extractButton_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                var spreadSheetIdReg = new Regex(@"/spreadsheets/d/([a-zA-Z0-9-_]+)");
                var match = spreadSheetIdReg.Match(linkTextBox.Text);
                string spreadSheetId;

                if (match.Success)
                {
                    spreadSheetId = match.Groups[1].Value;
                }
                else
                {
                    throw new ArgumentException("Link to spreadsheet isn't valid");
                }

                if (extractFormatComboBox.SelectedIndex == 0)
                {
                    String range = "0!A114:B114";

                    var valueRange = new ValueRange();
                    List<object> values = new List<object>() { 3, 3 };
                    valueRange.Values = new List<IList<object>> { values };

                    var appendRequest = GoogleSheets.Service.Spreadsheets.Values.Append(valueRange, spreadSheetId, range);
                    appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    var appendReponse = appendRequest.Execute();
                }
            }
            catch (ArgumentException e) when (e.Message == "Link to spreadsheet isn't valid")
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TypeInitializationException e) when (e.InnerException is FileNotFoundException)
            {
                MessageBox.Show(e.InnerException.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TypeInitializationException e) when (e.InnerException is TimeoutException)
            {
                MessageBox.Show(e.InnerException.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (GoogleApiException e)
            {
                var result = MessageBox.Show(e.Error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {

                }
            }
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
