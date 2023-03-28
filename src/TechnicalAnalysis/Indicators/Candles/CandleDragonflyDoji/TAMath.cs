using System.Numerics;
using TechnicalAnalysis.Candles.CandleDragonflyDoji;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDragonflyDojiResult CdlDragonflyDoji<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleDragonflyDoji<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
