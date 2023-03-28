using System.Numerics;
using TechnicalAnalysis.Candles.CandleKicking;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleKickingResult CdlKicking<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleKicking<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
