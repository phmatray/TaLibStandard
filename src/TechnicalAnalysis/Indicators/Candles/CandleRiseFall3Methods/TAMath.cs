using System.Numerics;
using TechnicalAnalysis.Candles.CandleRiseFall3Methods;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleRiseFall3MethodsResult CdlRiseFall3Methods<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleRiseFall3Methods<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
