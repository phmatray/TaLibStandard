using System.Numerics;
using TechnicalAnalysis.Candles.CandleGravestoneDoji;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleGravestoneDojiResult CdlGravestoneDoji<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleGravestoneDoji<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
