using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandlePiercing;

public record CandlePiercingResult : IndicatorBase
{
    public CandlePiercingResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}