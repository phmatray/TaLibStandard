using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleEveningStar;

public record CandleEveningStarResult : IndicatorBase
{
    public CandleEveningStarResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
