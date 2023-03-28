using System.Numerics;
using TechnicalAnalysis.Candles.CandlePiercing;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandlePiercingResult CdlPiercing<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandlePiercing<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
