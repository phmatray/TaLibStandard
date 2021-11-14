using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMama;

namespace TechnicalAnalysis.Functions.FunctionHtSine;

/// <summary>
/// Hilbert Transform - SineWave Lookback
/// </summary>
public record HtSineLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="HtSineLookback"/> record.
    /// </summary>
    /// <remarks>
    /// See <see cref="MamaLookback"/> for an explanation of the "32"
    /// </remarks>
    public HtSineLookback()
    {
        /*  31 input are skip 
         * +32 output are skip to account for misc lookback
         * ---
         *  63 Total Lookback
         *
         * 31 is for being compatible with Tradestation.
         */
        Result = 63 + (int)TACore.Globals.UnstablePeriods[FuncUnstId.HtSine];
    }
}
