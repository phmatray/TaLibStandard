using TechnicalAnalysis.Candles.CandleMatchingLow;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMatchingLowResult CdlMatchingLow(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleMatchingLow(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleMatchingLowResult CdlMatchingLow(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlMatchingLow(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
