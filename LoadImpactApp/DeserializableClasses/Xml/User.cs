using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class AppUser
    {
        [XmlAttribute]
        public string Token { get; set; }
        public List<TestSettings> FavoritesTests { get; set; }
        public ExportSettings ExportSettings { get; set; }

        public AppUser()
        {
            FavoritesTests = new List<TestSettings>();
        }
    }
}
