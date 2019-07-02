
using System.Collections.Generic;

namespace LoadImpactApp.Consts
{
    public static class GlobalConsts
    {
        public static readonly int CHUNKS_COUNT = 25;
        public static readonly string LOST_METRIC_ATTR = "Not found";
        public static readonly string PAGE_METRIC_UNIT = "sec";
        public static readonly List<string> PAGE_METRIC_ATTR_LIST = new List<string>()  { "min", "avg", "max" };
    }
}
