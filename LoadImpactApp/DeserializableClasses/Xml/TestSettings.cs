using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class Test
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool CheckVusActivity { get; set; }
        public List<MetricSettings> StandardMetrics { get; set; }
        public List<MetricSettings> ServerAgentMetrics { get; set; }
        public List<MetricSettings> PageMetrics { get; set; }

        public Test()
        {
            StandardMetrics = new List<MetricSettings>();
            ServerAgentMetrics = new List<MetricSettings>();
            PageMetrics = new List<MetricSettings>();
        }
    }
}
