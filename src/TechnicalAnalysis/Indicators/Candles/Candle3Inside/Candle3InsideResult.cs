using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3Inside;

public record Candle3InsideResult : IndicatorBase
{
    public Candle3InsideResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
