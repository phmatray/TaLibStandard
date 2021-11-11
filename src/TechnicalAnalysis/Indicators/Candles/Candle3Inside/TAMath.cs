using TechnicalAnalysis.Candles.Candle3Inside;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3InsideResult Cdl3Inside(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new Candle3Inside(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static Candle3InsideResult Cdl3Inside(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return Cdl3Inside(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
