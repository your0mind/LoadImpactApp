using System;
using System.Collections.Generic;

namespace LoadImpactApp.MathLogic
{
    public class MetricPoint : IComparable<MetricPoint>
    {
        public long Timestamp { get; set; }
        public double Value { get; set; }

        public int CompareTo(MetricPoint mp)
        {
            return Timestamp.CompareTo(mp.Timestamp);
        }
    }

    public class MetricPointsPack
    {
        public string AttributeName { get; set; }
        public List<MetricPoint> Points { get; set; }

        public MetricPointsPack(string atrName, int length)
        {
            AttributeName = atrName;
            Points = new List<MetricPoint>();
        }

        public double[] GetSectionByTimeBorders(Tuple<long, long> borders)
        {
            int indexOfLeftBorder = Points.BinarySearch(new MetricPoint() { Timestamp = borders.Item1 });
            indexOfLeftBorder = (indexOfLeftBorder < 0) ? Math.Abs(indexOfLeftBorder) - 1 : indexOfLeftBorder;

            int indexOfRightBorder = Points.BinarySearch(new MetricPoint() { Timestamp = borders.Item2 });
            indexOfRightBorder = (indexOfRightBorder < 0) ? Math.Abs(indexOfRightBorder) - 2 : indexOfRightBorder;

            double[] sectionArray = new double[indexOfRightBorder - indexOfLeftBorder + 1];
            for (int i = 0; i < sectionArray.Length; i++)
            {
                sectionArray[i] = Points[i + indexOfLeftBorder].Value;
            }
            return sectionArray;
        }
    }
}
