using LoadImpactApp.Api;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace LoadImpactApp
{
    public partial class ConnectionForm : Form
    {
        private MainForm m_MainForm;

        public ConnectionForm()
        {
            InitializeComponent();
            if (Settings.LoadImpactService.User.Token != "")
            {
                rememeberCheck.Checked = true;
                tokenBox.Text = Settings.LoadImpactService.User.Token;
            }
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (await ApiLoadImpact.CheckTokenAsync(tokenBox.Text))
                {
                    if (rememeberCheck.Checked)
                    {
                        Settings.LoadImpactService.User.Token = tokenBox.Text;
                    }
                    else
                    {
                        Settings.LoadImpactService.User.Token = "";
                    }

                    if (m_MainForm == null)
                    {
                        m_MainForm = new MainForm(this) { Visible = true };
                    }
                    else
                    {
                        m_MainForm.Visible = true;
                    }
                    Visible = false;
                }
                else
                {
                    connectionStatusLabel.Text = "Bad token.";
                    connectionStatusLabel.Visible = true;
                }
            }
            catch (HttpRequestException)
            {
                connectionStatusLabel.Text = "Connection problems :/";
                connectionStatusLabel.Visible = true;
            }
        }

        private void tokenBox_TextChanged(object sender, EventArgs e)
        {
            connectionStatusLabel.Visible = false;
        }

        private void ConnectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            connectButton.Select();
        }
    }
}
