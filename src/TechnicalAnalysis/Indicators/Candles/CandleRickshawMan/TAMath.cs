using System.Numerics;
using TechnicalAnalysis.Candles.CandleRickshawMan;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleRickshawManResult CdlRickshawMan<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleRickshawMan<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
