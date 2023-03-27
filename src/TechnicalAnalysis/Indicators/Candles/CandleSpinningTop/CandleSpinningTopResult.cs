using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleSpinningTop;

public record CandleSpinningTopResult : IndicatorBase
{
    public CandleSpinningTopResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
