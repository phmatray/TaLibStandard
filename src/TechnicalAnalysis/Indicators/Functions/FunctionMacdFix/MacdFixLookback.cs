using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;

namespace TechnicalAnalysis.Functions.FunctionMacdFix;

/// <summary>
/// Moving Average Convergence/Divergence Fix 12/26 Lookback
/// </summary>
public record MacdFixLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MacdFixLookback"/> record.
    /// </summary>
    /// <param name="optInSignalPeriod">Smoothing for the signal line (nb of period) (From 1 to 100000)</param>
    public MacdFixLookback(int optInSignalPeriod = 9)
    {
        if (optInSignalPeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            /* The lookback is driven by the signal line output.
             *
             * (must also account for the initial data consume 
             *  by the fix 26 period EMA).
             */
            Result = new EmaLookback(26).Result
                     + new EmaLookback(optInSignalPeriod).Result;
        }
    }
}
