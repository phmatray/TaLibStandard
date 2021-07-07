using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle2Crows
{
    public record Candle2CrowsResult : IndicatorBase
    {
        public Candle2CrowsResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
