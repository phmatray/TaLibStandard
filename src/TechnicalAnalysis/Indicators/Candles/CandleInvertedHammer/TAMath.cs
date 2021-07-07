using TechnicalAnalysis.Candles.CandleInvertedHammer;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleInvertedHammerResult CdlInvertedHammer(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleInvertedHammer(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleInvertedHammerResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleInvertedHammerResult CdlInvertedHammer(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlInvertedHammer(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
