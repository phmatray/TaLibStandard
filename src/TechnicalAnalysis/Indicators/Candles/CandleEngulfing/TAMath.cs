using TechnicalAnalysis.Candles.CandleEngulfing;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleEngulfingResult CdlEngulfing(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleEngulfing(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleEngulfingResult CdlEngulfing(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlEngulfing(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
