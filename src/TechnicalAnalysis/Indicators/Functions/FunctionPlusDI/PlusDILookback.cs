using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionPlusDI;

/// <summary>
/// Plus Directional Indicator Lookback
/// </summary>
public record PlusDILookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="PlusDILookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public PlusDILookback(int optInTimePeriod = 14)
    {
        Result = optInTimePeriod switch
        {
            < 1 or > 100000 => -1,
            > 1 => optInTimePeriod + (int)TACore.Globals.unstablePeriod[18],
            _ => 1
        };
    }
}
