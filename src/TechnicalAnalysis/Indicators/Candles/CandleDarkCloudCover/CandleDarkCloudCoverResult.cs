using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleDarkCloudCover
{
    public record CandleDarkCloudCoverResult : IndicatorBase
    {
        public CandleDarkCloudCoverResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
