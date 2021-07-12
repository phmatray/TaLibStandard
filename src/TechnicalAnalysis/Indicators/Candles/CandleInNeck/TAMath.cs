using TechnicalAnalysis.Candles.CandleInNeck;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleInNeckResult CdlInNeck(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleInNeck(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleInNeckResult CdlInNeck(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlInNeck(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
