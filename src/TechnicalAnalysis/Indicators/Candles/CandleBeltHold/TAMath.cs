using System.Numerics;
using TechnicalAnalysis.Candles.CandleBeltHold;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleBeltHoldResult CdlBeltHold<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleBeltHold<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
