using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleDojiStar
{
    public record CandleDojiStarResult : IndicatorBase
    {
        public CandleDojiStarResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
