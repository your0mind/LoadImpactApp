namespace LoadImpactApp.MathLogic
{
    public interface IMetricCalcStrategy
    {
        MetricStats CalcStats(MetricPointsPack mp);
    }
}
