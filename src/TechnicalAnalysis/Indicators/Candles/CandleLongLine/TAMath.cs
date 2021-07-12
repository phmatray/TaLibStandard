using TechnicalAnalysis.Candles.CandleLongLine;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleLongLineResult CdlLongLine(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleLongLine(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleLongLineResult CdlLongLine(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlLongLine(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
