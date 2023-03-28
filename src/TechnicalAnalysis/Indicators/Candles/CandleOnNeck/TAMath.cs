using System.Numerics;
using TechnicalAnalysis.Candles.CandleOnNeck;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleOnNeckResult CdlOnNeck<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleOnNeck<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
