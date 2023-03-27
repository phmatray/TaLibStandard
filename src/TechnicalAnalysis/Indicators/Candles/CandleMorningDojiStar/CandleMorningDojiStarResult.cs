using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleMorningDojiStar;

public record CandleMorningDojiStarResult : IndicatorBase
{
    public CandleMorningDojiStarResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}
