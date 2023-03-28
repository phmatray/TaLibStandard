using System.Numerics;
using TechnicalAnalysis.Candles.CandleLadderBottom;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleLadderBottomResult CdlLadderBottom<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleLadderBottom<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
