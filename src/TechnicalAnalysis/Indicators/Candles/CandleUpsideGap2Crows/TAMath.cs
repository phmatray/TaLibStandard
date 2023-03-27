using TechnicalAnalysis.Candles.CandleUpsideGap2Crows;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleUpsideGap2CrowsResult CdlUpsideGap2Crows(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleUpsideGap2Crows(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleUpsideGap2CrowsResult CdlUpsideGap2Crows(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlUpsideGap2Crows(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
