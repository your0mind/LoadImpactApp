using LoadImpactApp.Api;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadImpactApp
{
    public static class CurrentContextData
    {
        public static List<TestConfig> TestConfigs { get; private set; }
        public static List<TestRun> Runs { get; private set; }       
        public static List<string> Titles { get; private set; }
        public static List<string> FavoritesTitles { get; private set; }

        static CurrentContextData()
        {
            TestConfigs = new List<TestConfig>();
            Runs = new List<TestRun>();
            Titles = new List<string>();
            FavoritesTitles = new List<string>();
        }

        public static List<TestRun> GetRunsOfTest(string testName)
        {
            return Runs.FindAll(run => run.Title == testName);
        }

        public async static Task RefreshAsync()
        {
            TestConfigs = await ApiLoadImpact.GetTestConfigsAsync();
            TestConfigs.Sort();

            Runs = await ApiLoadImpact.GetFinishedTestsRunsAsync();

            Titles.Clear();
            Titles.AddRange(Runs.Select(run => run.Title).Distinct().ToList());
            Titles.Sort();

            FavoritesTitles.RemoveAll(title => Titles.IndexOf(title) < 0);
        }
    }
}
