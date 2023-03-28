using System.Numerics;
using TechnicalAnalysis.Candles.CandleShootingStar;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleShootingStarResult CdlShootingStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleShootingStar<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
