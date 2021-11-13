using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionEma;

/// <summary>
/// Exponential Moving Average Lookback
/// </summary>
public record EmaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="EmaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public EmaLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod - 1 + (int)TACore.Globals.unstablePeriod[5];
        }
    }
}
