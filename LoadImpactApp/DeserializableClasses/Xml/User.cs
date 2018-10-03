using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoadImpactApp.DeserializableClasses.Xml
{
    public class User
    {
        [XmlAttribute]
        public string Token { get; set; }
        public List<TestSettings> FavoritesTests { get; set; }
        public ExportSettings ExportSettings { get; set; }

        public User()
        {
            FavoritesTests = new List<TestSettings>();
        }
    }
}
