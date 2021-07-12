using TechnicalAnalysis.Candles.CandleBeltHold;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleBeltHoldResult CdlBeltHold(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleBeltHold(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleBeltHoldResult CdlBeltHold(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlBeltHold(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
