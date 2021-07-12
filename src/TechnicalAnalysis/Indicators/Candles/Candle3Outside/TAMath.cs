using TechnicalAnalysis.Candles.Candle3Outside;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Candle3OutsideResult Cdl3Outside(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new Candle3Outside(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static Candle3OutsideResult Cdl3Outside(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3Outside(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
