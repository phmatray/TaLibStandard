using System.Numerics;
using TechnicalAnalysis.Candles.CandleHighWave;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHighWaveResult CdlHighWave<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleHighWave<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
