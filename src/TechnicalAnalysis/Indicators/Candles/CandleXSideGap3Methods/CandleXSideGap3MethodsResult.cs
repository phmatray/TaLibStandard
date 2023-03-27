using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleXSideGap3Methods;

public record CandleXSideGap3MethodsResult : IndicatorBase
{
    public CandleXSideGap3MethodsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
