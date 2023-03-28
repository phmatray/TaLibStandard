using System.Numerics;
using TechnicalAnalysis.Candles.CandleStickSandwich;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleStickSandwichResult CdlStickSandwich<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleStickSandwich<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
