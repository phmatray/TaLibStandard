using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionSarExt;

/// <summary>
/// Parabolic SAR - Extended Lookback
/// </summary>
public record SarExtLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="SarExtLookback"/> record.
    /// </summary>
    public SarExtLookback()
    {
        /* SAR always sacrifices one price bar to establish the
         * initial extreme price.
         */
        Result = 1;
    }
}
