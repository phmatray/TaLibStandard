using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleUnique3River;

public record CandleUnique3RiverResult : IndicatorBase
{
    public CandleUnique3RiverResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}