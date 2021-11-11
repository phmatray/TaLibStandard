using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleRickshawMan;

public record CandleRickshawManResult : IndicatorBase
{
    public CandleRickshawManResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}