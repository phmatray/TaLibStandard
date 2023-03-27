using TechnicalAnalysis.Candles.Candle3BlackCrows;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3BlackCrowsResult Cdl3BlackCrows(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new Candle3BlackCrows(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static Candle3BlackCrowsResult Cdl3BlackCrows(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return Cdl3BlackCrows(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
