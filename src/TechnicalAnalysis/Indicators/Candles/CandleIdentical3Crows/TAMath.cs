using TechnicalAnalysis.Candles.CandleIdentical3Crows;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleIdentical3CrowsResult CdlIdentical3Crows(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleIdentical3Crows(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleIdentical3CrowsResult CdlIdentical3Crows(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlIdentical3Crows(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
