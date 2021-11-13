using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis.Functions.FunctionPpo;

/// <summary>
/// Percentage Price Oscillator Lookback
/// </summary>
public record PpoLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="PpoLookback"/> record.
    /// </summary>
    /// <param name="optInFastPeriod">Number of period for the fast MA (From 2 to 100000)</param>
    /// <param name="optInSlowPeriod">Number of period for the slow MA (From 2 to 100000)</param>
    /// <param name="optInMAType">Type of Moving Average</param>
    public PpoLookback(
        int optInFastPeriod = 12,
        int optInSlowPeriod = 26,
        MAType optInMAType = MAType.Sma)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInSlowPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            // Lookback is driven by the slowest MA.
            Result = new MovingAverageLookback(
                Math.Max(optInSlowPeriod, optInFastPeriod), optInMAType).Result;
        }
    }
}
