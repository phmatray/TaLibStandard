using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionRocP;

/// <summary>
/// Rate of change Percentage: (price-prevPrice)/prevPrice Lookback
/// </summary>
public record RocPLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="RocPLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public RocPLookback(int optInTimePeriod = 10)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod;
        }
    }
}
