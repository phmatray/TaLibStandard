using System.Numerics;
using TechnicalAnalysis.Candles.CandleAdvanceBlock;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleAdvanceBlockResult CdlAdvanceBlock<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleAdvanceBlock<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
