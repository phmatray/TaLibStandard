using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleEveningDojiStar
{
    public record CandleEveningDojiStarResult : IndicatorBase
    {
        public CandleEveningDojiStarResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
