using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleLongLeggedDoji;

public record CandleLongLeggedDojiResult : IndicatorBase
{
    public CandleLongLeggedDojiResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
