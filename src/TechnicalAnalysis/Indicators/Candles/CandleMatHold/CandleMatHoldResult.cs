using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleMatHold;

public record CandleMatHoldResult : IndicatorBase
{
    public CandleMatHoldResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
