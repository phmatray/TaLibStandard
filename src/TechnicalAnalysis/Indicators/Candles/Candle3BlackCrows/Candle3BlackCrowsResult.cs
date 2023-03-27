using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3BlackCrows;

/// <summary>
/// Represents the result of the Three Black Crows candlestick pattern indicator.
/// </summary>
public record Candle3BlackCrowsResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the Candle3BlackCrowsResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integer">An array of integers indicating the presence of the Three Black Crows pattern.</param>
    public Candle3BlackCrowsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    /// <summary>
    /// Gets the array of integers indicating the presence of the Three Black Crows pattern.
    /// </summary>
    public int[] Integer { get; }
}
