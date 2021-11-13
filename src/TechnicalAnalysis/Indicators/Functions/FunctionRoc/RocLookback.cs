using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionRoc;

/// <summary>
/// Rate of change : ((price/prevPrice)-1)*100 Lookback
/// </summary>
public record RocLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="RocLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public RocLookback(int optInTimePeriod = 10)
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
