using System.Numerics;
using TechnicalAnalysis.Candles.CandleDojiStar;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDojiStarResult CdlDojiStar<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleDojiStar<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
