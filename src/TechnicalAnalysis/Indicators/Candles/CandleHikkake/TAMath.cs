using System.Numerics;
using TechnicalAnalysis.Candles.CandleHikkake;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHikkakeResult CdlHikkake<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleHikkake<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
