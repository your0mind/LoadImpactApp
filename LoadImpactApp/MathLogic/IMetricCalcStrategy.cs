namespace LoadImpactApp.MathLogic
{
    public interface IMetricCalcStrategy
    {
        MetricStats GetStats(MetricPointsPack mp);
    }
}
