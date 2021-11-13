using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionT3;

/// <summary>
/// Triple Exponential Moving Average (T3) Lookback
/// </summary>
public record T3Lookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="T3Lookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public T3Lookback(int optInTimePeriod = 5)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = (optInTimePeriod - 1) * 6 + (int)TACore.Globals.unstablePeriod[22];
        }
    }
}
