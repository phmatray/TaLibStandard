using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleBeltHold;

public record CandleBeltHoldResult : IndicatorBase
{
    public CandleBeltHoldResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
