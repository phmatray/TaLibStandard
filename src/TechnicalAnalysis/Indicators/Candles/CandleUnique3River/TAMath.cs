using System.Numerics;
using TechnicalAnalysis.Candles.CandleUnique3River;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleUnique3RiverResult CdlUnique3River<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleUnique3River<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
