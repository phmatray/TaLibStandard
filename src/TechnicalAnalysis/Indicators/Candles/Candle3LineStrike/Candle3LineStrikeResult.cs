using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3LineStrike;

public record Candle3LineStrikeResult : IndicatorBase
{
    public Candle3LineStrikeResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
