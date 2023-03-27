using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleInNeck;

public record CandleInNeckResult : IndicatorBase
{
    public CandleInNeckResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
