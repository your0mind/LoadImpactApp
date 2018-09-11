using System;
using System.Globalization;

namespace LoadImpactApp.Api
{
    public class TestRun
    {
        private string m_Ended;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Ended
        {
            get { return m_Ended; }
            set
            {
                if (value != null)
                {
                    var utcDate = DateTimeOffset.Parse(value);
                    var loadImpactDate = utcDate.ToOffset(TimeSpan.FromHours(-5));
                    m_Ended = loadImpactDate.ToString("MMM dd HH:mm (yyyy)", new CultureInfo("en-Us"));
                }
            }
        }
        public int Status { get; set; }
        public string PublicUrl { get; set; }
    }
}
