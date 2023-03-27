using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHaramiCross;

public record CandleHaramiCrossResult : IndicatorBase
{
    public CandleHaramiCrossResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
