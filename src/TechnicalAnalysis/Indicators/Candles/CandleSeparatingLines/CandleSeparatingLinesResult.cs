using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleSeparatingLines
{
    public record CandleSeparatingLinesResult : IndicatorBase
    {
        public CandleSeparatingLinesResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
