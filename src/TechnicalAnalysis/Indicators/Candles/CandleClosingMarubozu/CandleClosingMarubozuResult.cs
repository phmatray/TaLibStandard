using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleClosingMarubozu;

/// <summary>
/// Represents the result of the Closing Marubozu candlestick pattern indicator.
/// </summary>
public record CandleClosingMarubozuResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the CandleClosingMarubozuResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integer">An array of integers indicating the presence of the Closing Marubozu pattern.</param>
    public CandleClosingMarubozuResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    /// <summary>
    /// Gets the array of integers indicating the presence of the Closing Marubozu pattern.
    /// </summary>
    public int[] Integer { get; }
}
