using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle2Crows;

/// <summary>
/// Represents the result of the Two Crows candlestick pattern indicator.
/// </summary>
public record Candle2CrowsResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the Candle2CrowsResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integer">An array of integers indicating the presence of the Two Crows pattern.</param>
    public Candle2CrowsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    /// <summary>
    /// Gets the array of integers indicating the presence of the Two Crows pattern.
    /// </summary>
    public int[] Integer { get; }
}
