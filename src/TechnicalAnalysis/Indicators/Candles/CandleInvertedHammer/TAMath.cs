using System.Numerics;
using TechnicalAnalysis.Candles.CandleInvertedHammer;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleInvertedHammerResult CdlInvertedHammer<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleInvertedHammer<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
