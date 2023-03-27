using TechnicalAnalysis.Candles.CandleLongLeggedDoji;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleLongLeggedDojiResult CdlLongLeggedDoji(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleLongLeggedDoji(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleLongLeggedDojiResult CdlLongLeggedDoji(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlLongLeggedDoji(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
