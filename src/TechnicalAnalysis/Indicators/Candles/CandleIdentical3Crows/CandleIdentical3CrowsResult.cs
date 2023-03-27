using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleIdentical3Crows;

public record CandleIdentical3CrowsResult : IndicatorBase
{
    public CandleIdentical3CrowsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
