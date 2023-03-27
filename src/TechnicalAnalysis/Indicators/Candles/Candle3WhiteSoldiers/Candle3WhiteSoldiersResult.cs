using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3WhiteSoldiers;

public record Candle3WhiteSoldiersResult : IndicatorBase
{
    public Candle3WhiteSoldiersResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
