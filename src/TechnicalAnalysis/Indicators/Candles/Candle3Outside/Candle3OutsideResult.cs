using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.Candle3Outside
{
    public record Candle3OutsideResult : IndicatorBase
    {
        public Candle3OutsideResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
