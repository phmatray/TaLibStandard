using TechnicalAnalysis.Candles.CandleShortLine;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleShortLineResult CdlShortLine(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleShortLine(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleShortLineResult CdlShortLine(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlShortLine(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
