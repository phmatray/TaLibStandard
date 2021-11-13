using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionRocR;

/// <summary>
/// Rate of change ratio: (price/prevPrice) Lookback
/// </summary>
public record RocRLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="RocRLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public RocRLookback(int optInTimePeriod = 10)
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
