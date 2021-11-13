using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionTrueRange;

/// <summary>
/// True Range Lookback
/// </summary>
public record TrueRangeLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="TrueRangeLookback"/> record.
    /// </summary>
    public TrueRangeLookback()
    {
        Result = 1;
    }
}
