using TechnicalAnalysis.Candles.CandleAbandonedBaby;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleAbandonedBabyResult CdlAbandonedBaby(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleAbandonedBaby(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleAbandonedBabyResult(retCode, begIdx, nbElement, ints);
        }
        
        public static CandleAbandonedBabyResult CdlAbandonedBaby(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlAbandonedBaby(startIdx, endIdx, open, high, low, close, 0.3);
        }

        public static CandleAbandonedBabyResult CdlAbandonedBaby(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlAbandonedBaby(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CandleAbandonedBabyResult CdlAbandonedBaby(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlAbandonedBaby(startIdx, endIdx, open, high, low, close, 0.3);
        }
    }
}
