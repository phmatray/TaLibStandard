using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleMarubozu;

public record CandleMarubozuResult : IndicatorBase
{
    public CandleMarubozuResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}