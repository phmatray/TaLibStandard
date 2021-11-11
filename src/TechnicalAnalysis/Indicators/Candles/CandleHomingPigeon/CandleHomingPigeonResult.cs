using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHomingPigeon;

public record CandleHomingPigeonResult : IndicatorBase
{
    public CandleHomingPigeonResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}