using System.Numerics;
using TechnicalAnalysis.Candles.CandleSeparatingLines;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleSeparatingLinesResult CdlSeparatingLines<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleSeparatingLines<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
