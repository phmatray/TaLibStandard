using System.Numerics;
using TechnicalAnalysis.Candles.CandleHaramiCross;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHaramiCrossResult CdlHaramiCross<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleHaramiCross<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
