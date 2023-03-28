using System.Numerics;
using TechnicalAnalysis.Candles.CandleClosingMarubozu;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleClosingMarubozuResult CdlClosingMarubozu<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleClosingMarubozu<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
