using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class ExportSettings
    {
        [XmlAttribute]
        public string SpreadsheetLink { get; set; }
        [XmlAttribute]
        public string ExportFormat { get; set; }
        [XmlAttribute]
        public string Sprint { get; set; }
    }
}
