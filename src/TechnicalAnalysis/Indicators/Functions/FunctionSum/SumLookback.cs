using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionSum;

/// <summary>
/// Summation Lookback
/// </summary>
public record SumLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="SumLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public SumLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod - 1;
        }
    }
}
