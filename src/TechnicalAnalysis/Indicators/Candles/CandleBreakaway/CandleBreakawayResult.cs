using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleBreakaway
{
    public record CandleBreakawayResult : IndicatorBase
    {
        public CandleBreakawayResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
