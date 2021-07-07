using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleInvertedHammer
{
    public record CandleInvertedHammerResult : IndicatorBase
    {
        public CandleInvertedHammerResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
