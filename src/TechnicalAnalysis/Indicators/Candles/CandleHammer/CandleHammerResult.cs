using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHammer
{
    public record CandleHammerResult : IndicatorBase
    {
        public CandleHammerResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
