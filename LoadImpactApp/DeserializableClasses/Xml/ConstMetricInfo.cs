using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class TimelessMetricInfo
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Unit { get; set; }
        [XmlAttribute]
        public string MetricId { get; set; }
    }
}
