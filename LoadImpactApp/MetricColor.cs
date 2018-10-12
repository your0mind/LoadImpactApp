using System.Drawing;

namespace LoadImpactApp
{
    internal static class MetricColor
    {
        public static Color StandardType { get; set; }
        public static Color ServerAgentType { get; set; }
        public static Color PageType { get; set; }

        static MetricColor()
        {
            StandardType = Color.LemonChiffon;
            ServerAgentType = Color.LightCyan;
            PageType = Color.PaleGreen;
        }
    }
}
