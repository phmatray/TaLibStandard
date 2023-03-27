using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHarami;

public record CandleHaramiResult : IndicatorBase
{
    public CandleHaramiResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
