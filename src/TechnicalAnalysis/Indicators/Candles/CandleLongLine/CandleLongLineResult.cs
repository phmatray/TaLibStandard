using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleLongLine
{
    public record CandleLongLineResult : IndicatorBase
    {
        public CandleLongLineResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
