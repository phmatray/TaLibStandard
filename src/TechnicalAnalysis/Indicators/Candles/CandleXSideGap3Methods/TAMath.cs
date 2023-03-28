using System.Numerics;
using TechnicalAnalysis.Candles.CandleXSideGap3Methods;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleXSideGap3MethodsResult CdlXSideGap3Methods<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleXSideGap3Methods<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
