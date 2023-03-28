using System.Numerics;
using TechnicalAnalysis.Candles.CandleMatchingLow;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMatchingLowResult CdlMatchingLow<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleMatchingLow<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
