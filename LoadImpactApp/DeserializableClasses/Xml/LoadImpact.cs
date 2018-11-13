using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class LoadImpact
    {
        [XmlAttribute]
        public string BaseUrl { get; set; }
        public AppUser User { get; set; }
        public ConstMetrics ConstMetrics { get; set; }

        public LoadImpact()
        {
            ConstMetrics = new ConstMetrics();
        }
    }
}
