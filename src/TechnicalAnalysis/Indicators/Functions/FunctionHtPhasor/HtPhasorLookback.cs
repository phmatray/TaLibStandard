using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMama;

namespace TechnicalAnalysis.Functions.FunctionHtPhasor;

/// <summary>
/// Hilbert Transform - Phasor Components Lookback
/// </summary>
public record HtPhasorLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="HtPhasorLookback"/> record.
    /// </summary>
    /// <remarks>
    /// See <see cref="MamaLookback"/> for an explanation of these
    /// </remarks>
    public HtPhasorLookback()
    {
        Result = 32 + (int)TACore.Globals.unstablePeriod[8];
    }
}
