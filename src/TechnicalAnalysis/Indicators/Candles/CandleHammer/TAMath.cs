using System.Numerics;
using TechnicalAnalysis.Candles.CandleHammer;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHammerResult CdlHammer<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleHammer<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
