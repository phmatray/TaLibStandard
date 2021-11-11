using TechnicalAnalysis.Candles.CandleTasukiGap;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleTasukiGapResult CdlTasukiGap(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleTasukiGap(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleTasukiGapResult CdlTasukiGap(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlTasukiGap(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}