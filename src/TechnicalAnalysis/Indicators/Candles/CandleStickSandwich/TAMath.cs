using TechnicalAnalysis.Candles.CandleStickSandwich;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleStickSandwichResult CdlStickSandwich(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleStickSandwich(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleStickSandwichResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleStickSandwichResult CdlStickSandwich(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlStickSandwich(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
