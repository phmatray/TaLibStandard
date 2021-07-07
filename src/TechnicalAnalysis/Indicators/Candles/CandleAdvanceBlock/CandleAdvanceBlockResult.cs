using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleAdvanceBlock
{
    public record CandleAdvanceBlockResult : IndicatorBase
    {
        public CandleAdvanceBlockResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
