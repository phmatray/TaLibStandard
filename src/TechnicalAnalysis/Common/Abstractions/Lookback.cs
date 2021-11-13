namespace TechnicalAnalysis.Common;

/// <summary>
/// Lookback
/// </summary>
public abstract record Lookback
{
    /// <summary>
    /// The result of the lookback
    /// </summary>
    public int Result { get; init; }
}
