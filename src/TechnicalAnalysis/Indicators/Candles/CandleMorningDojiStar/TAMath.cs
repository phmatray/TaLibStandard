using System.Numerics;
using TechnicalAnalysis.Candles.CandleMorningDojiStar;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMorningDojiStarResult CdlMorningDojiStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
        where T : IFloatingPoint<T>
    {
        return new CandleMorningDojiStar<T>(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    public static CandleMorningDojiStarResult CdlMorningDojiStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return CdlMorningDojiStar<T>(startIdx, endIdx, open, high, low, close, T.CreateChecked(0.3));
    }
}
