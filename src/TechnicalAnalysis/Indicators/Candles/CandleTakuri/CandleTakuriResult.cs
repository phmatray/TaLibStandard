using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleTakuri;

public record CandleTakuriResult : IndicatorBase
{
    public CandleTakuriResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}