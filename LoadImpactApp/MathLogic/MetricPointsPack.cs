using System;
using System.Collections.Generic;

namespace LoadImpactApp.MathLogic
{
    public class MetricPointsPack
    {
        public string AttrName { get; set; }
        public List<MetricPoint> Points { get; set; }

        public MetricPointsPack(string attrName, int length)
        {
            AttrName = attrName;
            Points = new List<MetricPoint>() { Capacity = length };
        }

        public MetricPointsPack(MetricPointsPack mp)
        {
            AttrName = mp.AttrName;
            Points = new List<MetricPoint>(mp.Points);
        }

        public MetricPointsPack GetPartByTimeBorders(Tuple<long, long> borders)
        {
            int indexOfLeftBorder = Points.BinarySearch(new MetricPoint(borders.Item1, 0));
            indexOfLeftBorder = (indexOfLeftBorder < 0) ? Math.Abs(indexOfLeftBorder) - 1 : indexOfLeftBorder;

            int indexOfRightBorder = Points.BinarySearch(new MetricPoint(borders.Item2, 0));
            indexOfRightBorder = (indexOfRightBorder < 0) ? Math.Abs(indexOfRightBorder) - 2 : indexOfRightBorder;

            var resultPart = new MetricPointsPack(AttrName, indexOfRightBorder - indexOfLeftBorder + 1);
            for (int i = 0; i < resultPart.Points.Capacity; i++)
            {
                resultPart.Points.Add(new MetricPoint(Points[i + indexOfLeftBorder]));
            }
            return resultPart;
        }

        public MetricPointsPack GetAvgChunkPoints(int nChunks)
        {
            int chunkLength = Points.Count / nChunks;
            if (chunkLength == 0)
            {
                return new MetricPointsPack(this);
            }

            var result = new MetricPointsPack(AttrName, nChunks);

            double sum;
            for (int i = 0; i < nChunks; i++)
            {
                sum = 0.0;
                for (int j = 0; j < chunkLength; j++)
                {
                    sum += Points[j + i * chunkLength].Value;
                }
                result.Points.Add(new MetricPoint(0, sum / chunkLength));
            }
            return result;
        }
    }
}
