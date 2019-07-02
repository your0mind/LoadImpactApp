using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class TestSettings
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool CheckVusActivity { get; set; }
        public List<MetricSettings> StandardMetrics { get; set; }
        public List<MetricSettings> ServerAgentMetrics { get; set; }
        public List<MetricSettings> PageMetrics { get; set; }

        public TestSettings()
        {
            StandardMetrics = new List<MetricSettings>();
            ServerAgentMetrics = new List<MetricSettings>();
            PageMetrics = new List<MetricSettings>();
        }
    }
}
