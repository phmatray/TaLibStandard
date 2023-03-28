using System.Numerics;
using TechnicalAnalysis.Candles.Candle3LineStrike;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3LineStrikeResult Cdl3LineStrike<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new Candle3LineStrike<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
