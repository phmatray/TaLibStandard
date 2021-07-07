using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleMatchingLow
{
    public record CandleMatchingLowResult : IndicatorBase
    {
        public CandleMatchingLowResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
