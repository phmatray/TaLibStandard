using TechnicalAnalysis.Candles.CandleConcealBabySwallow;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleConcealBabySwallowResult CdlConcealBabySwallow(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleConcealBabySwallow(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleConcealBabySwallowResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleConcealBabySwallowResult CdlConcealBabySwallow(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlConcealBabySwallow(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
