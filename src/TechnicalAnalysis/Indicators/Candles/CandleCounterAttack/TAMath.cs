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
            RetCode retCode = new CandleCounterAttack(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleCounterAttackResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleCounterAttackResult CdlCounterAttack(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlCounterAttack(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
