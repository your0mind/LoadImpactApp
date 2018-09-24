using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.IO;
using System.Xml.Serialization;

namespace LoadImpactApp
{
    public static class Settings
    {
        public static LoadImpact LoadImpactService;

        static Settings()
        {
            //LoadImpactService = new LoadImpact();
            //LoadImpactService.BaseUrl = "https://api.loadimpact.com/v2";
            //LoadImpactService.User = new User();
            //LoadImpactService.User.Token = "";
            //LoadImpactService.User.FavoritesTests = new List<Test>();
            //LoadImpactService.TimelessMetrics = new TimelessMetrics();
            //LoadImpactService.TimelessMetrics.StandartMetricsInfo = new List<TimelessMetricInfo>();
            //LoadImpactService.TimelessMetrics.StandartMetricsInfo.Add(new TimelessMetricInfo() { Name = "Requests/second", UnitType = "r/sec", MetricId = "__li_requests_per_second" });
            //LoadImpactService.TimelessMetrics.ServerAgentMetricsInfo = new List<TimelessMetricInfo>();
            //LoadImpactService.TimelessMetrics.ServerAgentMetricsInfo.Add(new TimelessMetricInfo() { Name = "CPU", UnitType = "percent", MetricId = "" });
        }

        public static void Update()
        {
            LoadImpactService.User.FavoritesTests.RemoveAll(test => CurrentContextData.FavoritesTitles.IndexOf(test.Name) < 0);
            foreach (var title in CurrentContextData.FavoritesTitles)
            {
                bool isPresent = false;
                foreach (var test in LoadImpactService.User.FavoritesTests)
                {
                    if (title == test.Name)
                    {
                        isPresent = true;
                    }
                }

                if (!isPresent)
                {
                    LoadImpactService.User.FavoritesTests.Add(new TestSettings() { Name = title });
                }
            }
        }
    
        public static void GetFromFile(string settingsFileName)
        {
            using (var reader = new StreamReader(settingsFileName))
            {
                var serializer = new XmlSerializer(typeof(LoadImpact));
                LoadImpactService = (LoadImpact)serializer.Deserialize(reader);
            }
        }

        public static void SaveToFile(string settingsFileName)
        {
            using (var writter = new StreamWriter(settingsFileName))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);

                var serializer = new XmlSerializer(typeof(LoadImpact));
                serializer.Serialize(writter, LoadImpactService, ns);
            }
        }
    }
}
