using TechnicalAnalysis.Candles.CandleClosingMarubozu;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleClosingMarubozuResult CdlClosingMarubozu(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleClosingMarubozu(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleClosingMarubozuResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleClosingMarubozuResult CdlClosingMarubozu(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlClosingMarubozu(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
