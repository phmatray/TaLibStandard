using System.Numerics;
using TechnicalAnalysis.Candles.CandleKickingByLength;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleKickingByLengthResult CdlKickingByLength<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleKickingByLength<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
