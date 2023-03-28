using System.Numerics;
using TechnicalAnalysis.Candles.CandleEngulfing;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleEngulfingResult CdlEngulfing<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleEngulfing<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
