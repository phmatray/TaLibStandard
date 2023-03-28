using System.Numerics;
using TechnicalAnalysis.Candles.CandleDoji;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDojiResult CdlDoji<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleDoji<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
