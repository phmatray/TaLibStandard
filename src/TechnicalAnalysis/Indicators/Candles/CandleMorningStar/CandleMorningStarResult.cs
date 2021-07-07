using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleMorningStar
{
    public record CandleMorningStarResult : IndicatorBase
    {
        public CandleMorningStarResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
