using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHikkakeMod
{
    public record CandleHikkakeModResult : IndicatorBase
    {
        public CandleHikkakeModResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
