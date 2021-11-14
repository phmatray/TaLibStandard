using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionNatr;

/// <summary>
/// Normalized Average True Range Lookback
/// </summary>
public record NatrLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="NatrLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public NatrLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            /* The ATR lookback is the sum of:
             *    1 + (optInTimePeriod - 1)
             *
             * Where 1 is for the True Range, and
             * (optInTimePeriod-1) is for the simple
             * moving average.
             */
            Result = optInTimePeriod + (int)TACore.Globals.UnstablePeriods[FuncUnstId.Natr];
        }
    }
}
