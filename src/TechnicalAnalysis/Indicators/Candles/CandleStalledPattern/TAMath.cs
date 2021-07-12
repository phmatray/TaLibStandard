using TechnicalAnalysis.Candles.CandleStalledPattern;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleStalledPatternResult CdlStalledPattern(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleStalledPattern(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleStalledPatternResult CdlStalledPattern(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlStalledPattern(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
