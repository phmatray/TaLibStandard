using System.Numerics;
using TechnicalAnalysis.Candles.CandleAbandonedBaby;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleAbandonedBabyResult CdlAbandonedBaby<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close, T penetration)
        where T : IFloatingPoint<T>
    {
        return new CandleAbandonedBaby<T>(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }
        
    public static CandleAbandonedBabyResult CdlAbandonedBaby<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return CdlAbandonedBaby<T>(startIdx, endIdx, open, high, low, close, T.CreateChecked(0.3));
    }
}
