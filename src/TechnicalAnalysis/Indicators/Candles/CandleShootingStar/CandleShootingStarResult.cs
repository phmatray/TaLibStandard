using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleShootingStar;

public record CandleShootingStarResult : IndicatorBase
{
    public CandleShootingStarResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
