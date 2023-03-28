using System.Numerics;
using TechnicalAnalysis.Candles.CandleThrusting;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleThrustingResult CdlThrusting<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleThrusting<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
