using System;
using System.Collections.Generic;

namespace LoadImpactApp.MathLogic
{
    public class MetricPointsPack
    {
        public string AttributeName { get; set; }
        public List<MetricPoint> Points { get; set; }

        public MetricPointsPack(string atrName, int length)
        {
            AttributeName = atrName;
            Points = new List<MetricPoint>(length);
        }

        public MetricPointsPack(MetricPointsPack mp)
        {
            AttributeName = mp.AttributeName;
            Points = new List<MetricPoint>(mp.Points);
        }

        public MetricPointsPack GetPartByTimeBorders(Tuple<long, long> borders)
        {
            int indexOfLeftBorder = Points.BinarySearch(new MetricPoint() { Timestamp = borders.Item1 });
            indexOfLeftBorder = (indexOfLeftBorder < 0) ? Math.Abs(indexOfLeftBorder) - 1 : indexOfLeftBorder;

            int indexOfRightBorder = Points.BinarySearch(new MetricPoint() { Timestamp = borders.Item2 });
            indexOfRightBorder = (indexOfRightBorder < 0) ? Math.Abs(indexOfRightBorder) - 2 : indexOfRightBorder;

            var resultPart = new MetricPointsPack(AttributeName, indexOfRightBorder - indexOfLeftBorder + 1);
            for (int i = 0; i < resultPart.Points.Count; i++)
            {
                resultPart.Points[i] = Points[i + indexOfLeftBorder];
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

            var result = new MetricPointsPack(AttributeName, nChunks);

            double sum;
            for (int i = 0; i < nChunks; i++)
            {
                sum = 0.0;
                for (int j = 0; j < chunkLength; j++)
                {
                    sum += Points[j + i * chunkLength].Value;
                }
                result.Points[i].Value = sum / chunkLength;
            }
            return result;
        }
    }
}
