using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;

namespace LoadImpactApp.ExportLogic
{
    public static class GoogleSheets
    {
        public static SheetsService Service;

        static GoogleSheets()
        {
            Service = GetSheetsService();
        }

        private static SheetsService GetSheetsService()
        {
            UserCredential credential;
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
    }
}
