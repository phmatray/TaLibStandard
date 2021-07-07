using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleCounterAttack
{
    public record CandleCounterAttackResult : IndicatorBase
    {
        public CandleCounterAttackResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
