using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleTasukiGap;

public record CandleTasukiGapResult : IndicatorBase
{
    public CandleTasukiGapResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
