using System.Numerics;
using TechnicalAnalysis.Candles.CandleLongLine;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleLongLineResult CdlLongLine<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleLongLine<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
