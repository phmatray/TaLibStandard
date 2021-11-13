using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionCmo;

/// <summary>
/// Chande Momentum Oscillator Lookback
/// </summary>
public record CmoLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="CmoLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public CmoLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            int retValue = optInTimePeriod + (int)TACore.Globals.unstablePeriod[3];
            if (TACore.Globals.compatibility == TACore.Compatibility.Metastock)
            {
                retValue--;
            }

            Result = retValue;
        }
    }
}
