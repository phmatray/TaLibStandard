using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis.Functions.FunctionMacdExt;

/// <summary>
/// MACD with controllable MA type Lookback
/// </summary>
public record MacdExtLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MacdExtLookback"/> record.
    /// </summary>
    /// <param name="optInFastPeriod">Number of period for the fast MA (From 2 to 100000)</param>
    /// <param name="optInFastMAType">Type of Moving Average for fast MA</param>
    /// <param name="optInSlowPeriod">Number of period for the slow MA (From 2 to 100000)</param>
    /// <param name="optInSlowMAType">Type of Moving Average for slow MA</param>
    /// <param name="optInSignalPeriod">Smoothing for the signal line (nb of period) (From 1 to 100000)</param>
    /// <param name="optInSignalMAType">Type of Moving Average for signal line</param>
    public MacdExtLookback(
        int optInFastPeriod = 12,
        MAType optInFastMAType = MAType.Sma,
        int optInSlowPeriod = 26,
        MAType optInSlowMAType = MAType.Sma,
        int optInSignalPeriod = 9,
        MAType optInSignalMAType = MAType.Sma)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInSlowPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInSignalPeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            // Find the MA with the largest lookback 
            int lookbackLargest = new MovingAverageLookback(optInFastPeriod, optInFastMAType).Result;
            int tempInteger = new MovingAverageLookback(optInSlowPeriod, optInSlowMAType).Result;
            if (tempInteger > lookbackLargest)
            {
                lookbackLargest = tempInteger;
            }

            // Add to the largest MA lookback the signal line lookback 
            Result = lookbackLargest + new MovingAverageLookback(optInSignalPeriod, optInSignalMAType).Result;
        }
    }
}
