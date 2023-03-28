using System.Numerics;
using TechnicalAnalysis.Candles.CandleLongLeggedDoji;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleLongLeggedDojiResult CdlLongLeggedDoji<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleLongLeggedDoji<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
