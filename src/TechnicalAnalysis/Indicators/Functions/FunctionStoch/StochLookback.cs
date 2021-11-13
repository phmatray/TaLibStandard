using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis.Functions.FunctionStoch;

/// <summary>
/// Stochastic Lookback
/// </summary>
public record StochLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="StochLookback"/> record.
    /// </summary>
    /// <param name="optInFastK_Period">Time period for building the Fast-K line (From 1 to 100000)</param>
    /// <param name="optInSlowK_Period">Smoothing for making the Slow-K line. Usually set to 3 (From 1 to 100000)</param>
    /// <param name="optInSlowK_MAType">Type of Moving Average for Slow-K</param>
    /// <param name="optInSlowD_Period">Smoothing for making the Slow-D line</param>
    /// <param name="optInSlowD_MAType">Type of Moving Average for Slow-D</param>
    public StochLookback(
        int optInFastK_Period = 5,
        int optInSlowK_Period = 3,
        MAType optInSlowK_MAType = MAType.Sma,
        int optInSlowD_Period = 3,
        MAType optInSlowD_MAType = MAType.Sma)
    {
        if (optInFastK_Period is < 1 or > 100000)
        {
            Result = -1;
        }
        else if (optInSlowK_Period is < 1 or > 100000)
        {
            Result = -1;
        }
        else if (optInSlowD_Period is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            int retValue = optInFastK_Period - 1;
            retValue += new MovingAverageLookback(optInSlowK_Period, optInSlowK_MAType).Result;
            retValue += new MovingAverageLookback(optInSlowD_Period, optInSlowD_MAType).Result;

            Result = retValue;
        }
    }
}
