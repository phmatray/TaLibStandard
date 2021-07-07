using TechnicalAnalysis.Candles.CandleIdentical3Crows;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleIdentical3CrowsResult CdlIdentical3Crows(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleIdentical3Crows(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleIdentical3CrowsResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleIdentical3CrowsResult CdlIdentical3Crows(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlIdentical3Crows(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
