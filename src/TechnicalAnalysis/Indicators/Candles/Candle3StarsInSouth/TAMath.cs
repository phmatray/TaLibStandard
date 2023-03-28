using System.Numerics;
using TechnicalAnalysis.Candles.Candle3StarsInSouth;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3StarsInSouthResult Cdl3StarsInSouth<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new Candle3StarsInSouth<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
