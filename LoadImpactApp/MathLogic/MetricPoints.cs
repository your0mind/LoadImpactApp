using System;

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

    public class MetricPoints
    {
        public string AttributeName { get; set; }
        public MetricPoint[] Points { get; set; }

        public MetricPoints(string atrName, int length)
        {
            AttributeName = atrName;
            Points = new MetricPoint[length];
        }

        public MetricPoint[] GetSectionByBorders(Tuple<long, long> borders)
        {
            int indexOfLeftBorder = Array.BinarySearch(Points, new MetricPoint() { Timestamp = borders.Item1 });
            indexOfLeftBorder = (indexOfLeftBorder < 0) ? Math.Abs(indexOfLeftBorder) - 1 : indexOfLeftBorder;

            int indexOfRightBorder = Array.BinarySearch(Points, new MetricPoint() { Timestamp = borders.Item2 });
            indexOfRightBorder = (indexOfRightBorder < 0) ? Math.Abs(indexOfRightBorder) - 2 : indexOfRightBorder;

            MetricPoint[] sectionArray = new MetricPoint[indexOfRightBorder - indexOfLeftBorder + 1];
            Array.Copy(Points, indexOfLeftBorder, sectionArray, 0, sectionArray.Length);

            return sectionArray;
        }
    }
}
