using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleConcealBabySwallow;

/// <summary>
/// Represents the result of the Conceal Baby Swallow candlestick pattern indicator.
/// </summary>
public record CandleConcealBabySwallowResult : IndicatorBase
{
    /// <summary>
    /// Initializes a new instance of the CandleConcealBabySwallowResult class.
    /// </summary>
    /// <param name="retCode">The return code of the indicator calculation.</param>
    /// <param name="begIdx">The index of the first element in the result.</param>
    /// <param name="nbElement">The number of elements in the result.</param>
    /// <param name="integer">An array of integers indicating the presence of the Conceal Baby Swallow pattern.</param>
    public CandleConcealBabySwallowResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    /// <summary>
    /// Gets the array of integers indicating the presence of the Conceal Baby Swallow pattern.
    /// </summary>
    public int[] Integer { get; }
}
