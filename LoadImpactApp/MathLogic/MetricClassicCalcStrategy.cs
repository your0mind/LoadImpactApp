using System;
using System.Collections.Generic;

namespace LoadImpactApp.MathLogic
{
    public class MetricClassicCalcStrategy : IMetricCalcStrategy
    {
        public MetricStats CalcStats(MetricPointsPack mp)
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
            tempPoints.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));
            double median = (count % 2 == 0)
                ? (tempPoints[count / 2].Value + tempPoints[count / 2 - 1].Value) / 2
                : tempPoints[count / 2].Value;

            return new MetricStats
            {
                Min = tempPoints[0].Value,
                Median = median,
                Max = tempPoints[count - 1].Value
            };
        }
    }
}
