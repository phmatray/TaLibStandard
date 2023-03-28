using System.Numerics;
using TechnicalAnalysis.Candles.Candle3Outside;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3OutsideResult Cdl3Outside<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new Candle3Outside<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
