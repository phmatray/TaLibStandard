using System.Numerics;
using TechnicalAnalysis.Candles.CandleShortLine;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleShortLineResult CdlShortLine<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleShortLine<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
