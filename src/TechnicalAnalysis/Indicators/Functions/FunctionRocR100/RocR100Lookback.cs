using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionRocR100;

/// <summary>
/// Rate of change ratio: (price/prevPrice) Lookback
/// </summary>
public record RocR100Lookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="RocR100Lookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public RocR100Lookback(int optInTimePeriod = 10)
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
