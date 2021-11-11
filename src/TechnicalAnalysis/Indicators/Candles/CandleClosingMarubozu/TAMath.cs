using TechnicalAnalysis.Candles.CandleClosingMarubozu;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleClosingMarubozuResult CdlClosingMarubozu(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleClosingMarubozu(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleClosingMarubozuResult CdlClosingMarubozu(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlClosingMarubozu(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}