using System.Numerics;
using TechnicalAnalysis.Candles.CandleHangingMan;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHangingManResult CdlHangingMan<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleHangingMan<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
