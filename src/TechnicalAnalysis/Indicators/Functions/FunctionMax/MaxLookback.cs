using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMax;

/// <summary>
/// Highest value over a specified period Lookback
/// </summary>
public record MaxLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MaxLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MaxLookback(int optInTimePeriod = 30)
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
