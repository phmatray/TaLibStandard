using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMama;

namespace TechnicalAnalysis.Functions.FunctionHtTrendline;

/// <summary>
/// Hilbert Transform - Instantaneous Trendline Lookback
/// </summary>
public record HtTrendlineLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="HtTrendlineLookback"/> record.
    /// </summary>
    /// <remarks>
    /// See <see cref="MamaLookback"/> for an explanation of the "32"
    /// </remarks>
    public HtTrendlineLookback()
    {
        /*  31 input are skip 
         * +32 output are skip to account for misc lookback
         * ---
         *  63 Total Lookback
         *
         * 31 is for being compatible with Tradestation.
         */
        Result = 63 + (int)TACore.Globals.UnstablePeriods[FuncUnstId.HtTrendline];
    }
}
