using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleEngulfing;

public record CandleEngulfingResult : IndicatorBase
{
    public CandleEngulfingResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}