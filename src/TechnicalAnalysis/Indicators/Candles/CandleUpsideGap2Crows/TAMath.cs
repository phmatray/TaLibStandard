using TechnicalAnalysis.Candles.CandleUpsideGap2Crows;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleUpsideGap2CrowsResult CdlUpsideGap2Crows(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleUpsideGap2Crows(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleUpsideGap2CrowsResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleUpsideGap2CrowsResult CdlUpsideGap2Crows(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlUpsideGap2Crows(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
