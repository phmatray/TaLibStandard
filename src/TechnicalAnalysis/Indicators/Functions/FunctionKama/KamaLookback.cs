using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionKama;

/// <summary>
/// Kaufman Adaptive Moving Average Lookback
/// </summary>
public record KamaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="KamaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public KamaLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod + (int)TACore.Globals.unstablePeriod[12];
        }
    }
}
