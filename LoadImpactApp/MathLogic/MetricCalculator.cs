using LoadImpactApp.MathLogic;
using System;
using System.Linq;

namespace LoadImpactApp
{
    public class MetricCalculator
    {
        private double m_Median;
        private MetricPoint[] m_MetricPoints;
        private bool m_UseAnalisisWithStableSections;

        public MetricCalculator(MetricPoints mp, Tuple<long, long> borders, bool useAnalisisWithVusNumber, bool useAnalisisWithStableSections)
        {
            m_UseAnalisisWithStableSections = useAnalisisWithStableSections;

            if (useAnalisisWithVusNumber)
            {
                m_MetricPoints = mp.GetSectionByBorders(borders);
            }
            else
            {
                m_MetricPoints = mp.Points;
            }

            if (useAnalisisWithStableSections)
            {
                m_Median = GetMedian(m_MetricPoints);
            }
        }

        public double Min()
        {
            if (m_UseAnalisisWithStableSections)
            {
                var valuesLessThenMedian = m_MetricPoints.Where(p => p.Value < m_Median).ToArray();
                return (valuesLessThenMedian.Length > 0) ? GetMedian(valuesLessThenMedian) : m_Median;
            }
            else
            {
                return m_MetricPoints.Min(p => p.Value);
            }
        }

        public double Median()
        {
            if (m_UseAnalisisWithStableSections)
            {
                return m_Median;
            }
            else
            {
                return GetMedian(m_MetricPoints);
            }
        }

        public double Max()
        {
            if (m_UseAnalisisWithStableSections)
            {
                var valuesGreaterThenMedian = m_MetricPoints.Where(p => p.Value > m_Median).ToArray();
                return (valuesGreaterThenMedian.Length > 0) ? GetMedian(valuesGreaterThenMedian) : m_Median; 
            }
            else
            {
                return m_MetricPoints.Max(p => p.Value);
            }
        }

        public static Tuple<long, long> GetBordersByStableVusActive(MetricPoints metricPoints)
        {
            long leftBorderMax = 0;
            long rightBorderMax = 0;
            long currentLeftBorder = 0;
            long currentRightBorder = 0;
            bool isFindingRightBorder = false;

            for (int i = 0; i < metricPoints.Points.Length; i++)
            {
                if (!isFindingRightBorder)
                {
                    currentLeftBorder = metricPoints.Points[i].Timestamp;
                    isFindingRightBorder = true;
                }
                else
                {
                    if (metricPoints.Points[i].Value == metricPoints.Points[i - 1].Value)
                    {
                        currentRightBorder = metricPoints.Points[i].Timestamp;
                    }
                    else
                    {
                        currentRightBorder = metricPoints.Points[i-- - 1].Timestamp;
                        if ((currentRightBorder - currentLeftBorder) > (rightBorderMax - leftBorderMax))
                        {
                            leftBorderMax = currentLeftBorder;
                            rightBorderMax = currentRightBorder;
                        }
                        isFindingRightBorder = false;
                    }
                }
            }

            if (currentRightBorder == metricPoints.Points[metricPoints.Points.Length - 1].Timestamp)
            {
                if ((currentRightBorder - currentLeftBorder) > (rightBorderMax - leftBorderMax))
                {
                    leftBorderMax = currentLeftBorder;
                    rightBorderMax = currentRightBorder;
                }
            }

            return Tuple.Create(leftBorderMax, rightBorderMax);
        }

        private double GetMedian(MetricPoint[] metricPoints)
        {
            double[] tempPoints = metricPoints.Select(p => p.Value).ToArray();
            int count = tempPoints.Length;

            Array.Sort(tempPoints);

            if (count % 2 == 0)
            {
                double middleElement1 = tempPoints[(count / 2) - 1];
                double middleElement2 = tempPoints[(count / 2)];
                return (middleElement1 + middleElement2) / 2;
            }
            else
            {
                return tempPoints[(count / 2)];
            }
        }
    }
}
