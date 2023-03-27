using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleDoji;

public record CandleDojiResult : IndicatorBase
{
    public CandleDojiResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
