using TechnicalAnalysis.Candles.Candle3LineStrike;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3LineStrikeResult Cdl3LineStrike(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new Candle3LineStrike(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static Candle3LineStrikeResult Cdl3LineStrike(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return Cdl3LineStrike(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}