using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleStalledPattern
{
    public record CandleStalledPatternResult : IndicatorBase
    {
        public CandleStalledPatternResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
