using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMama;

/// <summary>
/// MESA Adaptive Moving Average Lookback
/// </summary>
public record MamaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MamaLookback"/> record.
    /// </summary>
    public MamaLookback()
    {
        /* Lookback is a fix amount + the unstable period.
         *
         *
         * The fix lookback is 32 and is establish as follow:
         *    
         *         12 price bar to be compatible with the implementation
         *            of TradeStation found in John Ehlers book.
         *          6 price bars for the Detrender
         *          6 price bars for Q1
         *          3 price bars for jI
         *          3 price bars for jQ
         *          1 price bar for Re/Im
         *          1 price bar for the Delta Phase
         *        -------
         *         32 Total
         */

        Result = 32 + (int)TACore.Globals.unstablePeriod[13];
    }
}
