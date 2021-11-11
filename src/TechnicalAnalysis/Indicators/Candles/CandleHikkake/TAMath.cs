using TechnicalAnalysis.Candles.CandleHikkake;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHikkakeResult CdlHikkake(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleHikkake(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleHikkakeResult CdlHikkake(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlHikkake(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}