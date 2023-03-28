using System.Numerics;
using TechnicalAnalysis.Candles.CandleHarami;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHaramiResult CdlHarami<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleHarami<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
