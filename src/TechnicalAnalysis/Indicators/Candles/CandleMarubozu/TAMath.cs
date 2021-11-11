using TechnicalAnalysis.Candles.CandleMarubozu;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMarubozuResult CdlMarubozu(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleMarubozu(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleMarubozuResult CdlMarubozu(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlMarubozu(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}