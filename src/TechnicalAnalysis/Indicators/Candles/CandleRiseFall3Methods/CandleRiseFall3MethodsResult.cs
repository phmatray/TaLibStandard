using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleRiseFall3Methods;

public record CandleRiseFall3MethodsResult : IndicatorBase
{
    public CandleRiseFall3MethodsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}