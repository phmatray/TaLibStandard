using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleUpsideGap2Crows;

public record CandleUpsideGap2CrowsResult : IndicatorBase
{
    public CandleUpsideGap2CrowsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}