using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleStickSandwich;

public record CandleStickSandwichResult : IndicatorBase
{
    public CandleStickSandwichResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}