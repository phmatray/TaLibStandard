using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis.Functions.FunctionStochF;

/// <summary>
/// Stochastic Fast Lookback
/// </summary>
public record StochFLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="StochFLookback"/> record.
    /// </summary>
    /// <param name="optInFastK_Period">Time period for building the Fast-K line (From 1 to 100000)</param>
    /// <param name="optInFastD_Period">Smoothing for making the Fast-D line. Usually set to 3 (From 1 to 100000)</param>
    /// <param name="optInFastD_MAType">Type of Moving Average for Fast-D</param>
    public StochFLookback(
        int optInFastK_Period = 5,
        int optInFastD_Period = 3,
        MAType optInFastD_MAType = MAType.Sma)
    {
        if (optInFastK_Period is < 1 or > 100000)
        {
            Result = -1;
        }
        else if (optInFastD_Period is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            // Account for the initial data needed for Fast-K. 
            int retValue = (optInFastK_Period - 1);

            // Add the smoothing being done for Fast-D 
            retValue += new MovingAverageLookback(optInFastD_Period, optInFastD_MAType).Result;

            Result = retValue;
        }
    }
}
