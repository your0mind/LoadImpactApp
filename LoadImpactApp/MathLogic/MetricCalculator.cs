using LoadImpactApp.MathLogic;
using System;
using System.Linq;

namespace LoadImpactApp
{
    public class MetricCalculator
    {
        private double m_Median;
        private MetricPointsPack m_MetricPointsPack;
        private bool m_UseAnalisisWithStableSections;

        public MetricCalculator(MetricPointsPack mp)
        {
            m_MetricPointsPack = mp;
        }

        public void 

        public MetricCalculator(MetricPointsPack mp, Tuple<long, long> borders, bool useAnalisisWithVusNumber, bool useAnalisisWithStableSections)
        {
            m_UseAnalisisWithStableSections = useAnalisisWithStableSections;

            if (useAnalisisWithVusNumber)
            {
                var valuesInBorders = mp.GetSectionByTimeBorders(borders);

                // Hardcoded value
                int nChunks = 25;
                int chunkLength = valuesInBorders.Length / nChunks;

                if (valuesInBorders.Length >= chunkLength)
                {
                    double sum = 0.0;
                    m_MetricValues = new double[nChunks];
                    for (int i = 0; i < nChunks * chunkLength; i++)
                    {
                        sum += valuesInBorders[i];
                        if ((i + 1) % chunkLength == 0)
                        {
                            m_MetricValues[i / chunkLength] = sum / chunkLength;
                            sum = 0.0;
                        }
                    }
                }
                else
                {
                    m_MetricValues = valuesInBorders;
                }
            }
            else
            {
                m_MetricValues = mp.Points.Select(p => p.Value).ToArray();
            }

            if (useAnalisisWithStableSections)
            {
                m_Median = (m_MetricValues.Length > 0) ? GetMedian(m_MetricValues) : 0.0;
            }
        }

        public double Min()
        {
            if (m_UseAnalisisWithStableSections)
            {
                var valuesLessThenMedian = m_MetricValues.Where(p => p < m_Median).ToArray();
                return (valuesLessThenMedian.Length > 0) ? GetMedian(valuesLessThenMedian) : m_Median;
            }
            else
            {
                m_MetricValues.
                return m_MetricValues.DefaultIfEmpty(0.0).Min();
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
                return (m_MetricValues.Length > 0) ? GetMedian(m_MetricValues) : 0.0;
            }
        }

        public double Max()
        {
            if (m_UseAnalisisWithStableSections)
            {
                var valuesGreaterThenMedian = m_MetricValues.Where(p => p > m_Median).ToArray();
                return valuesGreaterThenMedian.DefaultIfEmpty(0.0).Median()
            }
            else
            {
                return m_MetricValues.DefaultIfEmpty(0.0).Max();
            }
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
