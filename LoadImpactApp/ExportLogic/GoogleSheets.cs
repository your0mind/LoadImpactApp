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

namespace LoadImpactApp.ExportLogic
{
    public static class GoogleSheets
    {
        public static int AuthorizationTimeout { get; set; }

        public static SheetsService Service;

        static GoogleSheets()
        {
            AuthorizationTimeout = 10000;
            Service = GetSheetsService();
        }

        private static async Task<SheetsService> GetSheetsService()
        {
            UserCredential credential = null;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "google-token";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { SheetsService.Scope.Spreadsheets },
                    "user",
                    CancellationToken.None,
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
