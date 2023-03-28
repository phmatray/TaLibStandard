using System.Numerics;
using TechnicalAnalysis.Candles.CandleGapSideSideWhite;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleGapSideSideWhiteResult CdlGapSideSideWhite<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleGapSideSideWhite<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
