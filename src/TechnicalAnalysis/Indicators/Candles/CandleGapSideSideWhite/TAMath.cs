using TechnicalAnalysis.Candles.CandleGapSideSideWhite;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleGapSideSideWhiteResult CdlGapSideSideWhite(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleGapSideSideWhite(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleGapSideSideWhiteResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleGapSideSideWhiteResult CdlGapSideSideWhite(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlGapSideSideWhite(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
