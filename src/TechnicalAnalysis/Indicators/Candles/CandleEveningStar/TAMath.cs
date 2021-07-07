using TechnicalAnalysis.Candles.CandleEveningStar;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleEveningStarResult CdlEveningStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleEveningStar(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleEveningStarResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleEveningStarResult CdlEveningStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlEveningStar(startIdx, endIdx, open, high, low, close, 0.3);
        }

        public static CandleEveningStarResult CdlEveningStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlEveningStar(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CandleEveningStarResult CdlEveningStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlEveningStar(startIdx, endIdx, open, high, low, close, 0.3);
        }
    }
}
