using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3LineStrike;

/// <summary>
/// Represents the result of the Three Line Strike candlestick pattern indicator.
/// </summary>
public record Candle3LineStrikeResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the Candle3LineStrikeResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integer">An array of integers indicating the presence of the Three Line Strike pattern.</param>
    public Candle3LineStrikeResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    /// <summary>
    /// Gets the array of integers indicating the presence of the Three Line Strike pattern.
    /// </summary>
    public int[] Integer { get; }
}
