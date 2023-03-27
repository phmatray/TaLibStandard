using TechnicalAnalysis.Candles.CandleBreakaway;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleBreakawayResult CdlBreakaway(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleBreakaway(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleBreakawayResult CdlBreakaway(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlBreakaway(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
