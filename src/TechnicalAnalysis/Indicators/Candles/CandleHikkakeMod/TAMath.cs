using TechnicalAnalysis.Candles.CandleHikkakeMod;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleHikkakeModResult CdlHikkakeMod(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleHikkakeMod(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleHikkakeModResult CdlHikkakeMod(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlHikkakeMod(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
