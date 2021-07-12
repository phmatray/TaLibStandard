using TechnicalAnalysis.Candles.CandleOnNeck;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleOnNeckResult CdlOnNeck(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleOnNeck(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleOnNeckResult CdlOnNeck(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlOnNeck(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
