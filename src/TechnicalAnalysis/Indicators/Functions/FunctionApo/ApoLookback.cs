using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis.Functions.FunctionApo;

/// <summary>
/// Absolute Price Oscillator Lookback
/// </summary>
public record ApoLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="ApoLookback"/> record.
    /// </summary>
    /// <param name="optInFastPeriod">Number of period for the fast MA (From 2 to 100000)</param>
    /// <param name="optInSlowPeriod">Number of period for the slow MA (From 2 to 100000)</param>
    /// <param name="optInMAType">Type of Moving Average</param>
    public ApoLookback(int optInFastPeriod = 12, int optInSlowPeriod = 26, MAType optInMAType = MAType.Sma)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInSlowPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if ((int)optInMAType is < 0 or > 8)
        {
            Result = -1;
        }
        else
        {
            // The slow MA is the key factor determining the lookback period.
            Result = new MovingAverageLookback(
                Math.Max(optInSlowPeriod, optInFastPeriod), optInMAType).Result;
        }
    }
}
