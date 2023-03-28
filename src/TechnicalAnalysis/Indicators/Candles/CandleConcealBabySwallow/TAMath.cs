using System.Numerics;
using TechnicalAnalysis.Candles.CandleConcealBabySwallow;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleConcealBabySwallowResult CdlConcealBabySwallow<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleConcealBabySwallow<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
