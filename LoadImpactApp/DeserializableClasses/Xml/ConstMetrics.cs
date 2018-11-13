using System.Collections.Generic;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class ConstMetrics
    {
        public List<ConstMetricInfo> Standard { get; set; }
        public List<ConstMetricInfo> ServerAgent { get; set; }

        public ConstMetrics()
        {
            Standard = new List<ConstMetricInfo>();
            ServerAgent = new List<ConstMetricInfo>();
        }
    }
}
