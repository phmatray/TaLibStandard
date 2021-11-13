using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMama;

namespace TechnicalAnalysis.Functions.FunctionHtDcPhase;

/// <summary>
/// Hilbert Transform - Dominant Cycle Phase Lookback
/// </summary>
public record HtDcPhaseLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="HtDcPhaseLookback"/> record.
    /// </summary>
    /// <remarks>
    /// See <see cref="MamaLookback"/> for an explanation of the "32"
    /// </remarks>
    public HtDcPhaseLookback()
    {
        /*  31 input are skip 
         * +32 output are skip to account for misc lookback
         * ---
         *  63 Total Lookback
         *
         * 31 is for being compatible with Tradestation.
         */
        Result = 63 + (int)TACore.Globals.unstablePeriod[7];
    }
}
