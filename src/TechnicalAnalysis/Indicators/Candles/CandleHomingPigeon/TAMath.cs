using System.Numerics;
using TechnicalAnalysis.Candles.CandleHomingPigeon;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHomingPigeonResult CdlHomingPigeon<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleHomingPigeon<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
