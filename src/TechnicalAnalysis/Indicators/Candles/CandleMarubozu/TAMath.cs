using System.Numerics;
using TechnicalAnalysis.Candles.CandleMarubozu;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMarubozuResult CdlMarubozu<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleMarubozu<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
