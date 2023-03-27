using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHangingMan;

public record CandleHangingManResult : IndicatorBase
{
    public CandleHangingManResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
