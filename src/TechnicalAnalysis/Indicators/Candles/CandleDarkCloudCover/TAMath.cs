using System.Numerics;
using TechnicalAnalysis.Candles.CandleDarkCloudCover;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDarkCloudCoverResult CdlDarkCloudCover<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
        where T : IFloatingPoint<T>
    {
        return new CandleDarkCloudCover<T>(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    public static CandleDarkCloudCoverResult CdlDarkCloudCover<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, T.CreateChecked(0.5));
    }
}
