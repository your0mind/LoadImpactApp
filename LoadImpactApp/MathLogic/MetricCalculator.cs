using LoadImpactApp.MathLogic;
using System;

namespace LoadImpactApp
{
    public class MetricCalculator
    {
        private MetricPointsPack m_MetricPointsPack;
        public IMetricCalcStrategy ContextCalcStrategy;

        public MetricCalculator(MetricPointsPack mp, IMetricCalcStrategy contextCalcStrategy)
        {
            m_MetricPointsPack = mp;
            ContextCalcStrategy = contextCalcStrategy;
        }

        public MetricStats CalcStats()
        {
            return ContextCalcStrategy.CalcStats(m_MetricPointsPack);
        }

        public static Tuple<long, long> GetBordersByStableVusActive(MetricPointsPack metricPointsOfVusActive)
        {
            long leftBorderMax = 0;
            long rightBorderMax = 0;
            long currentLeftBorder = 0;
            long currentRightBorder = 0;
            bool isFindingRightBorder = false;

            for (int i = 0; i < metricPointsOfVusActive.Points.Count; i++)
            {
                if (!isFindingRightBorder)
                {
                    currentLeftBorder = metricPointsOfVusActive.Points[i].Timestamp;
                    isFindingRightBorder = true;
                }
                else
                {
                    if (metricPointsOfVusActive.Points[i].Value == metricPointsOfVusActive.Points[i - 1].Value)
                    {
                        currentRightBorder = metricPointsOfVusActive.Points[i].Timestamp;
                    }
                    else
                    {
                        currentRightBorder = metricPointsOfVusActive.Points[i-- - 1].Timestamp;
                        if ((currentRightBorder - currentLeftBorder) > (rightBorderMax - leftBorderMax))
                        {
                            leftBorderMax = currentLeftBorder;
                            rightBorderMax = currentRightBorder;
                        }
                        isFindingRightBorder = false;
                    }
                }
            }

            if (currentRightBorder == metricPointsOfVusActive.Points[metricPointsOfVusActive.Points.Count - 1].Timestamp)
            {
                if ((currentRightBorder - currentLeftBorder) > (rightBorderMax - leftBorderMax))
                {
                    leftBorderMax = currentLeftBorder;
                    rightBorderMax = currentRightBorder;
                }
            }

            return Tuple.Create(leftBorderMax, rightBorderMax);
        }
    }
}
