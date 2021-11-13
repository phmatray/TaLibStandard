using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionWma;

/// <summary>
/// Weighted Moving Average Lookback
/// </summary>
public record WmaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="WmaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public WmaLookback(int optInTimePeriod = 14)
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
