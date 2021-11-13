using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverage;

namespace TechnicalAnalysis.Functions.FunctionBollingerBands;

/// <summary>
/// Bollinger Bands Lookback
/// </summary>
public record BollingerBandsLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="BollingerBandsLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    /// <param name="optInMAType">Type of Moving Average</param>
    public BollingerBandsLookback(
        int optInTimePeriod = 5,
        MAType optInMAType = MAType.Sma)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if ((int)optInMAType is < 0 or > 8)
        {
            Result = -1;
        }
        else
        {
            Result = new MovingAverageLookback(optInTimePeriod, optInMAType).Result;
        }
    }
}
