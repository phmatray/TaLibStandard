using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleDragonflyDoji;

public record CandleDragonflyDojiResult : IndicatorBase
{
    public CandleDragonflyDojiResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
