using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleConcealBabySwallow;

public record CandleConcealBabySwallowResult : IndicatorBase
{
    public CandleConcealBabySwallowResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}