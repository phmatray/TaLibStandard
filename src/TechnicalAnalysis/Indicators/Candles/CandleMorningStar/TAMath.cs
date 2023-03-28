using System.Numerics;
using TechnicalAnalysis.Candles.CandleMorningStar;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMorningStarResult CdlMorningStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
        where T : IFloatingPoint<T>
    {
        return new CandleMorningStar<T>(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    public static CandleMorningStarResult CdlMorningStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return CdlMorningStar(startIdx, endIdx, open, high, low, close, T.CreateChecked(0.3));
    }
}
