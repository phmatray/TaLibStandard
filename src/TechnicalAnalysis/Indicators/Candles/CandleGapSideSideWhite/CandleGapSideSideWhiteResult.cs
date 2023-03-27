using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleGapSideSideWhite;

public record CandleGapSideSideWhiteResult : IndicatorBase
{
    public CandleGapSideSideWhiteResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
