using LoadImpactApp.MathLogic;
using System;
using System.Linq;

namespace LoadImpactApp
{
    public class MetricCalculator
    {
        private double m_Median;
        private double[] m_MetricValues;
        private bool m_UseAnalisisWithStableSections;

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
                return (m_MetricValues.Length > 0) ? m_MetricValues.Min() : 0.0;
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
                return (valuesGreaterThenMedian.Length > 0) ? GetMedian(valuesGreaterThenMedian) : m_Median; 
            }
            else
            {
                return (m_MetricValues.Length > 0) ? m_MetricValues.Max() : 0.0;
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

        private double GetMedian(double[] values)
        {
            double[] tempPoints = (double[])values.Clone();
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
