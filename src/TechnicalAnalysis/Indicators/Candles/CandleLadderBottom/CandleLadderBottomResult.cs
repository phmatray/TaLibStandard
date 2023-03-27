using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleLadderBottom;

public record CandleLadderBottomResult : IndicatorBase
{
    public CandleLadderBottomResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
