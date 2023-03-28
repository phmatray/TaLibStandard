using System.Numerics;
using TechnicalAnalysis.Candles.CandleUpsideGap2Crows;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleUpsideGap2CrowsResult CdlUpsideGap2Crows<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleUpsideGap2Crows<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
