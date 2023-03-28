using System.Numerics;
using TechnicalAnalysis.Candles.CandleBreakaway;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleBreakawayResult CdlBreakaway<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleBreakaway<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
