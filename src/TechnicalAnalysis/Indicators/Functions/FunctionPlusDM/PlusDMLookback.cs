using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionPlusDM;

/// <summary>
/// Plus Directional Movement Lookback
/// </summary>
public record PlusDMLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="PlusDMLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public PlusDMLookback(int optInTimePeriod = 14)
    {
        Result = optInTimePeriod switch
        {
            < 1 or > 100000 => -1,
            > 1 => optInTimePeriod + (int)TACore.Globals.unstablePeriod[19] - 1,
            _ => 1
        };
    }
}
