using TechnicalAnalysis.Candles.CandleKicking;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleKickingResult CdlKicking(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleKicking(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleKickingResult CdlKicking(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlKicking(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
