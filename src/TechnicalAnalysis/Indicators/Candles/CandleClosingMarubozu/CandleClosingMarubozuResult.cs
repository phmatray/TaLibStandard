using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleClosingMarubozu;

public record CandleClosingMarubozuResult : IndicatorBase
{
    public CandleClosingMarubozuResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}