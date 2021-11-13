using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionSar;

/// <summary>
/// Parabolic SAR Lookback
/// </summary>
public record SarLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="SarLookback"/> record.
    /// </summary>
    public SarLookback()
    {
        /* SAR always sacrifices one price bar to establish the
         * initial extreme price.
         */
        Result = 1;
    }
}
