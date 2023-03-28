using System.Numerics;
using TechnicalAnalysis.Candles.CandleTristar;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleTristarResult CdlTristar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleTristar<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
