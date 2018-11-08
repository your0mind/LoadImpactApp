using System.Collections.Generic;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class ConstMetrics
    {
        public List<ConstMetricInfo> Standard { get; set; }
        public List<ConstMetricInfo> ServerAgents { get; set; }

        public ConstMetrics()
        {
            Standard = new List<ConstMetricInfo>();
            ServerAgents = new List<ConstMetricInfo>();
        }
    }
}
