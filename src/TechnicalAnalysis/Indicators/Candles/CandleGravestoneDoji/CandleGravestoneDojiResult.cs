using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleGravestoneDoji;

public record CandleGravestoneDojiResult : IndicatorBase
{
    public CandleGravestoneDojiResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}