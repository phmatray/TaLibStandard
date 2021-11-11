using TechnicalAnalysis.Candles.CandleHangingMan;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHangingManResult CdlHangingMan(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleHangingMan(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleHangingManResult CdlHangingMan(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlHangingMan(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}