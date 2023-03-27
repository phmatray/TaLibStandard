using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3WhiteSoldiers;

/// <summary>
/// Represents the result of the Three White Soldiers candlestick pattern indicator.
/// </summary>
public record Candle3WhiteSoldiersResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the Candle3WhiteSoldiersResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integer">An array of integers indicating the presence of the Three White Soldiers pattern.</param>
    public Candle3WhiteSoldiersResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    /// <summary>
    /// Gets the array of integers indicating the presence of the Three White Soldiers pattern.
    /// </summary>
    public int[] Integer { get; }
}
