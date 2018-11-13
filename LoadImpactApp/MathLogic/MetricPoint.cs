using System;

namespace LoadImpactApp.MathLogic
{
    public class MetricPoint : IComparable<MetricPoint>
    {
        public long Timestamp { get; set; }
        public double Value { get; set; }

        public MetricPoint(long timestamp, double value)
        {
            Timestamp = timestamp;
            Value = value;
        }

        public MetricPoint(MetricPoint mp)
        {
            Timestamp = mp.Timestamp;
            Value = mp.Value;
        }

        public int CompareTo(MetricPoint mp)
        {
            return Timestamp.CompareTo(mp.Timestamp);
        }
    }
}
