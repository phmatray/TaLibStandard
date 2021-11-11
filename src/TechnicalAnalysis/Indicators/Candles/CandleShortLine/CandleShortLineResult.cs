using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleShortLine;

public record CandleShortLineResult : IndicatorBase
{
    public CandleShortLineResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}