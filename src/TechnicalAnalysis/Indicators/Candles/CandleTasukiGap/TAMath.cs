using System.Numerics;
using TechnicalAnalysis.Candles.CandleTasukiGap;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleTasukiGapResult CdlTasukiGap<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleTasukiGap<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
