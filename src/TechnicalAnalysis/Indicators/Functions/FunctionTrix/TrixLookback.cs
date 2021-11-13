using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;
using TechnicalAnalysis.Functions.FunctionRocR;

namespace TechnicalAnalysis.Functions.FunctionTrix;

/// <summary>
/// 1-day Rate-Of-Change (ROC) of a Triple Smooth EMA Lookback
/// </summary>
public record TrixLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="TrixLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public TrixLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = new EmaLookback(optInTimePeriod).Result * 3 +
                     new RocRLookback(1).Result;
        }
    }
}
