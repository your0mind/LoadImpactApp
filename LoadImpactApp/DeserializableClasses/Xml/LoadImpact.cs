using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class LoadImpact
    {
        [XmlAttribute]
        public string BaseUrl { get; set; }
        public AppUser User { get; set; }
        public ConstMetrics TimelessMetrics { get; set; }

        public LoadImpact()
        {
            TimelessMetrics = new ConstMetrics();
        }
    }
}
