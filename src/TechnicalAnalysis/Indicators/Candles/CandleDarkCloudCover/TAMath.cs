using TechnicalAnalysis.Candles.CandleDarkCloudCover;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleDarkCloudCoverResult CdlDarkCloudCover(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleDarkCloudCover(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleDarkCloudCoverResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleDarkCloudCoverResult CdlDarkCloudCover(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, 0.5);
        }

        public static CandleDarkCloudCoverResult CdlDarkCloudCover(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlDarkCloudCover(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CandleDarkCloudCoverResult CdlDarkCloudCover(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, 0.5);
        }
    }
}
