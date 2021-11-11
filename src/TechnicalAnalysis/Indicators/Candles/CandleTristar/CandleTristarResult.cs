using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleTristar;

public record CandleTristarResult : IndicatorBase
{
    public CandleTristarResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}