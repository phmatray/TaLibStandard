using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3StarsInSouth
{
    public record Candle3StarsInSouthResult : IndicatorBase
    {
        public Candle3StarsInSouthResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
