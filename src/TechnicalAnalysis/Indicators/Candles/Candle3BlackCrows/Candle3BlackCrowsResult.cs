using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3BlackCrows;

public record Candle3BlackCrowsResult : IndicatorBase
{
    public Candle3BlackCrowsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
