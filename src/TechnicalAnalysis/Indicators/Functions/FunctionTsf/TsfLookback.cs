using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionTsf;

/// <summary>
/// Time Series Forecast Lookback
/// </summary>
public record TsfLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="TsfLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public TsfLookback(int optInTimePeriod = 14)
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
