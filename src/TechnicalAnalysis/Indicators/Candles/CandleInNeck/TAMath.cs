using System.Numerics;
using TechnicalAnalysis.Candles.CandleInNeck;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleInNeckResult CdlInNeck<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleInNeck<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
