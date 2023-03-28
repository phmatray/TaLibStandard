using System.Numerics;
using TechnicalAnalysis.Candles.CandleCounterAttack;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleCounterAttackResult CdlCounterAttack<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleCounterAttack<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
