using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleOnNeck;

public record CandleOnNeckResult : IndicatorBase
{
    public CandleOnNeckResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}