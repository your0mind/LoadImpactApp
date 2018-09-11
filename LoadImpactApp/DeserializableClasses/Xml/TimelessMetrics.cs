using System.Collections.Generic;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class TimelessMetrics
    {
        public List<TimelessMetricInfo> StandartMetricsInfo { get; set; }
        public List<TimelessMetricInfo> ServerAgentMetricsInfo { get; set; }

        public TimelessMetrics()
        {
            StandartMetricsInfo = new List<TimelessMetricInfo>();
            ServerAgentMetricsInfo = new List<TimelessMetricInfo>();
        }
    }
}
