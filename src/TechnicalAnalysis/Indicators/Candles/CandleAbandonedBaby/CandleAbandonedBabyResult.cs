using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleAbandonedBaby;

public record CandleAbandonedBabyResult : IndicatorBase
{
    public CandleAbandonedBabyResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}