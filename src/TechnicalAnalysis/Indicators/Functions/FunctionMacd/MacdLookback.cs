using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;

namespace TechnicalAnalysis.Functions.FunctionMacd;

/// <summary>
/// Moving Average Convergence/Divergence Lookback
/// </summary>
public record MacdLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MacdLookback"/> record.
    /// </summary>
    /// <param name="optInFastPeriod">Number of period for the fast MA (From 2 to 100000)</param>
    /// <param name="optInSlowPeriod">Number of period for the slow MA (From 2 to 100000)</param>
    /// <param name="optInSignalPeriod">Smoothing for the signal line (nb of period) (From 1 to 100000)</param>
    public MacdLookback(
        int optInFastPeriod = 12,
        int optInSlowPeriod = 26,
        int optInSignalPeriod = 9)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInSlowPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInSignalPeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            /* The lookback is driven by the signal line output.
             *
             * (must also account for the initial data consume 
             *  by the slow period).
             */

            /* Make sure slow is really slower than
             * the fast period! if not, swap...
             */
            if (optInSlowPeriod < optInFastPeriod)
            {
                (optInSlowPeriod, _) = (optInFastPeriod, optInSlowPeriod);
            }

            Result = new EmaLookback(optInSlowPeriod).Result +
                     new EmaLookback(optInSignalPeriod).Result;
        }
    }
}
