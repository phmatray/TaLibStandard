using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionSma;

namespace TechnicalAnalysis.Functions.FunctionUltOsc;

/// <summary>
/// Ultimate Oscillator Lookback
/// </summary>
public record UltOscLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="UltOscLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod1">Number of bars for 1st period. (From 1 to 100000)</param>
    /// <param name="optInTimePeriod2">Number of bars for 2nd period. (From 1 to 100000)</param>
    /// <param name="optInTimePeriod3">Number of bars for 3rd period. (From 1 to 100000)</param>
    public UltOscLookback(
        int optInTimePeriod1 = 7,
        int optInTimePeriod2 = 14,
        int optInTimePeriod3 = 28)
    {
        if (optInTimePeriod1 is < 1 or > 100000)
        {
            Result = -1;
        }
        else if (optInTimePeriod2 is < 1 or > 100000)
        {
            Result = -1;
        }
        else if (optInTimePeriod3 is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            /* Lookback for the Ultimate Oscillator is the lookback of the SMA with the longest
             * time period, plus 1 for the True Range.
             */
            int maxPeriod = Math.Max(Math.Max(optInTimePeriod1, optInTimePeriod2), optInTimePeriod3);
            Result = new SmaLookback(maxPeriod).Result + 1;
        }
    }
}
