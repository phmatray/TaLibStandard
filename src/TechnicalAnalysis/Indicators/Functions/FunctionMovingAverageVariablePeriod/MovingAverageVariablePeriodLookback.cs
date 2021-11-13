using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis.Functions.FunctionMovingAverageVariablePeriod;

/// <summary>
/// Moving average with variable period Lookback
/// </summary>
public record MovingAverageVariablePeriodLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MovingAverageVariablePeriodLookback"/> record.
    /// </summary>
    /// <param name="optInMinPeriod">Value less than minimum will be changed to Minimum period (From 2 to 100000)</param>
    /// <param name="optInMaxPeriod">Value higher than maximum will be changed to Maximum period (From 2 to 100000)</param>
    /// <param name="optInMAType">Type of Moving Average</param>
    public MovingAverageVariablePeriodLookback(
        int optInMinPeriod = 2,
        int optInMaxPeriod = 30,
        MAType optInMAType = MAType.Sma)
    {
        if (optInMinPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInMaxPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = new MovingAverageLookback(optInMaxPeriod, optInMAType).Result;
        }
    }
}
