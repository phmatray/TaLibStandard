using System.Numerics;
using TechnicalAnalysis.Candles.Candle3WhiteSoldiers;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Candle3WhiteSoldiersResult Cdl3WhiteSoldiers<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new Candle3WhiteSoldiers<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
