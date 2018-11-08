﻿using LoadImpactApp.Api;
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
            if (UserSettings.LoadImpactService.User.Token != "")
            {
                rememeberCheck.Checked = true;
                tokenBox.Text = UserSettings.LoadImpactService.User.Token;
            }
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (await ApiLoadImpact.CheckTokenAsync(tokenBox.Text))
                {
                    UserSettings.LoadImpactService.User.Token = (rememeberCheck.Checked) ? tokenBox.Text : "";

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
