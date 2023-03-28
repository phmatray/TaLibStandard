using System.Numerics;
using TechnicalAnalysis.Candles.Candle3Inside;
// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3InsideResult Cdl3Inside<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new Candle3Inside<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
