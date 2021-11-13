using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionRsi;
using TechnicalAnalysis.Functions.FunctionStochF;

namespace TechnicalAnalysis.Functions.FunctionStochRsi;

/// <summary>
/// Stochastic Relative Strength Index Lookback
/// </summary>
public record StochRsiLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="StochRsiLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    /// <param name="optInFastK_Period">Time period for building the Fast-K line (From 1 to 100000)</param>
    /// <param name="optInFastD_Period">Smoothing for making the Fast-D line. Usually set to 3 (From 1 to 100000)</param>
    /// <param name="optInFastD_MAType">Type of Moving Average for Fast-D</param>
    public StochRsiLookback(
        int optInTimePeriod = 14,
        int optInFastK_Period = 5,
        int optInFastD_Period = 3,
        MAType optInFastD_MAType = MAType.Sma)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInFastK_Period is < 1 or > 100000)
        {
            Result = -1;
        }
        else if (optInFastD_Period is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = new RsiLookback(optInTimePeriod).Result +
                     new StochFLookback(
                         optInFastK_Period,
                         optInFastD_Period,
                         optInFastD_MAType).Result;
        }
    }
}