using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleKicking;

public record CandleKickingResult : IndicatorBase
{
    public CandleKickingResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}