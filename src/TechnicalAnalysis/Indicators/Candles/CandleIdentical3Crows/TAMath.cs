using System.Numerics;
using TechnicalAnalysis.Candles.CandleIdentical3Crows;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleIdentical3CrowsResult CdlIdentical3Crows<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleIdentical3Crows<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
