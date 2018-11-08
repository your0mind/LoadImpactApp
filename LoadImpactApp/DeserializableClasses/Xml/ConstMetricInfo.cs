using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class ConstMetricInfo
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Unit { get; set; }
        [XmlAttribute]
        public string MetricId { get; set; }
    }
}
