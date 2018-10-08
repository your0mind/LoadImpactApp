using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Flows;

namespace LoadImpactApp.ExportLogic
{
    public static class GoogleSheets
    {
        public static int AuthorizeTimeoutSec { get; set; }

        private static SheetsService m_Service;

        static GoogleSheets()
        {
            AuthorizeTimeoutSec = 10;
        }

        public static async Task<SheetsService> GetSheetsService()
        {
            if (m_Service != null)
            {
                return m_Service;
            }
            else
            {
                UserCredential credential = null;

                var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(AuthorizeTimeoutSec));

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "google-token";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new string[] { SheetsService.Scope.Spreadsheets },
                        "user",
                        cts.Token,
                        new FileDataStore(credPath, true));
                }

                return new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    //ApplicationName = ApplicationName,
                });
            }
        }
    }
}
