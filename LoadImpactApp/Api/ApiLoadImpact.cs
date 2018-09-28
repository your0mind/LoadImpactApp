using LoadImpactApp.MathLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoadImpactApp.Api
{
    public static class ApiLoadImpact
    {
        private static HttpClient m_HttpClient;
        private static string m_BaseUrl;
        private static string m_Token;

        public static string BaseUrl
        {
            get { return m_BaseUrl; }
            set
            {
                m_BaseUrl = value;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var servicePoint = ServicePointManager.FindServicePoint(new Uri(value));
                servicePoint.ConnectionLeaseTimeout = 60 * 1000;
            }
        }

        public static string Token
        {
            get { return m_Token; }
            set
            {
                m_Token = value;
                m_HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{value}:")));
            }
        }

        static ApiLoadImpact()
        {
            m_HttpClient = new HttpClient();
            BaseUrl = Settings.LoadImpactService.BaseUrl;
            Token = Settings.LoadImpactService.User.Token;
        }

        public static async Task<HttpResponseMessage> MakeRequestAsync(string path = "/")
        {
            string requestUrl = BaseUrl + path;
            return await m_HttpClient.GetAsync(requestUrl);
        }

        public static async Task<bool> CheckRememberedTokenAsync()
        {
            return await CheckTokenAsync(Token);
        }

        public static async Task<bool> CheckTokenAsync(string verifiableToken)
        {
            Token = verifiableToken;
            var response = await MakeRequestAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static async Task<List<TestRun>> GetFinishedTestsRunsAsync()
        {
            var response = await MakeRequestAsync("/tests");
            var jsonContent = await response.Content.ReadAsStringAsync();
            return await Task.Run(() =>
            {
                var allTestRuns = JsonConvert.DeserializeObject<List<TestRun>>(jsonContent);
                allTestRuns.RemoveAll(testRun => testRun.Status != 3);
                return allTestRuns;
            });
        }

        public static async Task<List<TestConfig>> GetTestConfigsAsync()
        {
            var response = await MakeRequestAsync("/test-configs");
            var jsonContent = await response.Content.ReadAsStringAsync();
            var jArray = JArray.Parse(jsonContent);
            var testConfings = new List<TestConfig>();

            foreach (var config in jArray)
            {
                var testConfig = new TestConfig();
                testConfig.Name = config.SelectToken("name").Value<string>();
                testConfig.ServerMetricAgents = config.SelectToken("config.server_metric_agents").ToObject<List<string>>();
                testConfig.UserScenarioId = config.SelectToken("config.tracks[0].clips[0].user_scenario_id").Value<int>();
                testConfings.Add(testConfig);
            }

            return testConfings;
        }

        public static async Task<List<MetricPoints>> GetStandartMetricPointsAsync(int testRunId, string metricName)
        {
            string ids = Settings.LoadImpactService.TimelessMetrics.StandartMetricsInfo
                .FirstOrDefault(metricInfo => metricInfo.Name == metricName).MetricId;

            var response = await MakeRequestAsync($"/tests/{testRunId}/results?ids={ids}");
            var jsonContent = await response.Content.ReadAsStringAsync();
            return ParseMetricPointsJson(jsonContent, ids);
        }

        public static async Task<List<MetricPoints>> GetServerAgentMetricPointsAsync(int testRunId, string serverAgentName, string serverLabelName)
        {
            string ids = "__server_metric_";

            byte[] hash = Encoding.ASCII.GetBytes(serverAgentName + serverLabelName);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] hashEnc = md5.ComputeHash(hash);
                foreach (var b in hashEnc)
                {
                    ids += b.ToString("x2");
                }
            }

            var response = await MakeRequestAsync($"/tests/{testRunId}/results?ids={ids}");
            var jsonContent = await response.Content.ReadAsStringAsync();
            return ParseMetricPointsJson(jsonContent, ids);
        }

        public static async Task<List<MetricPoints>> GetPageMetricPointsAsync(int testRunId, string metricName, int scenarioId)
        {
            string ids = "__li_page_";

            byte[] hash = Encoding.ASCII.GetBytes(metricName);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] hashEnc = md5.ComputeHash(hash);
                foreach (var b in hashEnc)
                {
                    ids += b.ToString("x2");
                }
            }
            
            var response = await MakeRequestAsync($"/tests/{testRunId}/results?ids={ids += $":1:{scenarioId}"}");
            var jsonContent = await response.Content.ReadAsStringAsync();
            return ParseMetricPointsJson(jsonContent, ids);
        }

        private static List<MetricPoints> ParseMetricPointsJson(string jsonContent, string metricId)
        {
            var jObject = JObject.Parse(jsonContent);
            var jTokens = jObject.SelectToken(metricId).ToArray();

            if (jTokens.Length == 0)
            {
                return null;
            }

            var atrList = new List<string>() { "value", "min", "avg", "max" };
            var parsedMetricPointsList = new List<MetricPoints>();
            foreach (var atr in atrList)
            {
                if (jTokens[0].SelectToken(atr) != null)
                {
                    parsedMetricPointsList.Add(new MetricPoints(atr, jTokens.Length));
                }
            }

            for (int i = 0; i < jTokens.Length; i++)
            {
                long timeStamp = jTokens[i].SelectToken("timestamp").Value<long>();
                foreach (var metricPoints in parsedMetricPointsList)
                {
                    metricPoints.Points[i] = new MetricPoint()
                    {
                        Timestamp = timeStamp,
                        Value = jTokens[i].SelectToken(metricPoints.AttributeName).Value<double>()
                    };
                }
            }
            return parsedMetricPointsList;
        }
    }
}
