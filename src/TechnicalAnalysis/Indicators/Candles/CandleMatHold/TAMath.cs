using TechnicalAnalysis.Candles.CandleMatHold;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleMatHoldResult CdlMatHold(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            return new CandleMatHold(open, high, low, close)
                .Compute(startIdx, endIdx, penetration);
        }

        public static CandleMatHoldResult CdlMatHold(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlMatHold(startIdx, endIdx, open, high, low, close, 0.5);
        }

        public static CandleMatHoldResult CdlMatHold(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlMatHold(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CandleMatHoldResult CdlMatHold(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlMatHold(startIdx, endIdx, open, high, low, close, 0.5);
        }
    }
}
