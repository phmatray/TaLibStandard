namespace TechnicalAnalysis.Common;

internal class MoneyFlow
{
    public MoneyFlow()
    {
        Negative = default;
        Positive = default;
    }

    public double Negative { get; set; }
    public double Positive { get; set; }
}
