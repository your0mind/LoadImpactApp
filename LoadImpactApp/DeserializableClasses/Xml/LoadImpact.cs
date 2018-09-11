using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class LoadImpact
    {
        [XmlAttribute]
        public string BaseUrl { get; set; }
        public User User { get; set; }
        public TimelessMetrics TimelessMetrics { get; set; }

        public LoadImpact()
        {
            TimelessMetrics = new TimelessMetrics();
        }
    }
}
