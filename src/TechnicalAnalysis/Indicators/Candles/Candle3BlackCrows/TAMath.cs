using System.Numerics;
using TechnicalAnalysis.Candles.Candle3BlackCrows;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3BlackCrowsResult Cdl3BlackCrows<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new Candle3BlackCrows<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
