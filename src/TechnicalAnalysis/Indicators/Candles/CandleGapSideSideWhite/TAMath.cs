using TechnicalAnalysis.Candles.CandleGapSideSideWhite;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleGapSideSideWhiteResult CdlGapSideSideWhite(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleGapSideSideWhite(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleGapSideSideWhiteResult CdlGapSideSideWhite(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlGapSideSideWhite(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}