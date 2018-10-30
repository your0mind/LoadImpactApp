using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadImpactApp.MathLogic
{
    public class MetricStrangeCalcStrategy : IMetricCalcStrategy
    {
        public MetricStats GetStats(MetricPointsPack mp)
        {
            if (mp == null)
            {
                throw new ArgumentNullException();
            }
            int count = mp.Points.Count;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty sequence.");
            }

            var tempPoints = new List<MetricPoint>(mp.Points);
            double median = Median(tempPoints);

            return new MetricStats
            {
                Min = Median(tempPoints.Where(p => p.Value <= median).ToList()),
                Median = median,
                Max = Median(tempPoints.Where(p => p.Value >= median).ToList())
            };
        }

        private double Median(List<MetricPoint> points)
        {
            var tempPoints = new List<MetricPoint>(points);
            tempPoints.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));
            int count = tempPoints.Count;
            return (count % 2 == 0)
                ? tempPoints[count / 2].Value
                : (tempPoints[count / 2].Value + tempPoints[count / 2 - 1].Value) / 2;
        }
    }
}
