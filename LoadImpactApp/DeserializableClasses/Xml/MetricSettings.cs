using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class MetricSettings
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool Min { get; set; }
        [XmlAttribute]
        public bool Median { get; set; }
        [XmlAttribute]
        public bool Max { get; set; }
        [XmlAttribute]
        public bool LookForStability { get; set; }
        [XmlAttribute]
        public int Precision { get; set; }

        public MetricSettings() { }
    }
}
