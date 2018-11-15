using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class MetricSettings
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool Smoothed { get; set; }
        [XmlAttribute]
        public int Precision { get; set; }
    }
}
