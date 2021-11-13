using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionRsi;

/// <summary>
/// Relative Strength Index Lookback
/// </summary>
public record RsiLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="RsiLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public RsiLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            int retValue = optInTimePeriod + (int)TACore.Globals.unstablePeriod[20];
            if (TACore.Globals.compatibility == TACore.Compatibility.Metastock)
            {
                retValue--;
            }

            Result = retValue;
        }
    }
}
