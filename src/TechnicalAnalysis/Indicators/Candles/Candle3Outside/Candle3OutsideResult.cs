using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3Outside;

/// <summary>
/// Represents the result of the Three Outside Up/Down candlestick pattern indicator.
/// </summary>
public record Candle3OutsideResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the Candle3OutsideResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integer">An array of integers indicating the presence of the Three Outside Up/Down pattern.</param>
    public Candle3OutsideResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    /// <summary>
    /// Gets the array of integers indicating the presence of the Three Outside Up/Down pattern.
    /// </summary>
    public int[] Integer { get; }
}
