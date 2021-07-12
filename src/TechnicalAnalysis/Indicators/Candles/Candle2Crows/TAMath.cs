using TechnicalAnalysis.Candles.Candle2Crows;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Candle2CrowsResult Cdl2Crows(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new Candle2Crows(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static Candle2CrowsResult Cdl2Crows(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl2Crows(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
