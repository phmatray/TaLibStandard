using TechnicalAnalysis.Candles.CandleCounterAttack;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleCounterAttackResult CdlCounterAttack(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleCounterAttack(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleCounterAttackResult CdlCounterAttack(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlCounterAttack(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
