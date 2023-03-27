using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleKickingByLength;

public record CandleKickingByLengthResult : IndicatorBase
{
    public CandleKickingByLengthResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
