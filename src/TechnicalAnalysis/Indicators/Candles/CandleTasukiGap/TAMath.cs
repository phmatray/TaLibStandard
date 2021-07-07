using TechnicalAnalysis.Candles.CandleTasukiGap;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleTasukiGapResult CdlTasukiGap(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleTasukiGap(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleTasukiGapResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleTasukiGapResult CdlTasukiGap(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlTasukiGap(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
