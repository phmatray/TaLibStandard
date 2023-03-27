using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHikkake;

public record CandleHikkakeResult : IndicatorBase
{
    public CandleHikkakeResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
