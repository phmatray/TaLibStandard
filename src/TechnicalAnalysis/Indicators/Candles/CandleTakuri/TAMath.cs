using System.Numerics;
using TechnicalAnalysis.Candles.CandleTakuri;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleTakuriResult CdlTakuri<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleTakuri<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
