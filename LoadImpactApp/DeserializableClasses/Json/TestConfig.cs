using System;
using System.Collections.Generic;

namespace LoadImpactApp.Api
{
    public class TestConfig : IComparable<TestConfig>
    {  
        public string Name { get; set; }
        public List<string> ServerMetricAgents { get; set; }
        public int UserScenarioId { get; set; }

        public TestConfig()
        {
            ServerMetricAgents = new List<string>();
        }

        public int CompareTo(TestConfig tc)
        {
            return Name.CompareTo(tc.Name);
        }
    }
}
