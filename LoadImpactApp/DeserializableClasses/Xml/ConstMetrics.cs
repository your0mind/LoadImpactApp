using System.Collections.Generic;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class ConstMetrics
    {
        public List<ConstMetricInfo> StandartMetrics { get; set; }
        public List<ConstMetricInfo> ServerAgentMetrics { get; set; }

        public ConstMetrics()
        {
            StandartMetrics = new List<ConstMetricInfo>();
            ServerAgentMetrics = new List<ConstMetricInfo>();
        }
    }
}
