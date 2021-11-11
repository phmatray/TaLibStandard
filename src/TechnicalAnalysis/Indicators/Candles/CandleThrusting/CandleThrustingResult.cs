using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleThrusting;

public record CandleThrustingResult : IndicatorBase
{
    public CandleThrustingResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}