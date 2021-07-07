using TechnicalAnalysis.Candles.CandleInNeck;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleInNeckResult CdlInNeck(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleInNeck(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleInNeckResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleInNeckResult CdlInNeck(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlInNeck(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
