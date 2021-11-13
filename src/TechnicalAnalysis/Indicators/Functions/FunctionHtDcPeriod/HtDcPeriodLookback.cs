using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMama;

namespace TechnicalAnalysis.Functions.FunctionHtDcPeriod;

/// <summary>
/// Hilbert Transform - Dominant Cycle Period Lookback
/// </summary>
public record HtDcPeriodLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="HtDcPeriodLookback"/> record.
    /// </summary>
    /// <remarks>
    /// See <see cref="MamaLookback"/> for an explanation of these
    /// </remarks>
    public HtDcPeriodLookback()
    {
        Result = 32 + (int)TACore.Globals.unstablePeriod[6];
    }
}
