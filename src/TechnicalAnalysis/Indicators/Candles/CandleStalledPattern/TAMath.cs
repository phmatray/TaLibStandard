using System.Numerics;
using TechnicalAnalysis.Candles.CandleStalledPattern;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleStalledPatternResult CdlStalledPattern<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleStalledPattern<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
