using System.Numerics;
using TechnicalAnalysis.Candles.CandleSpinningTop;

// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleSpinningTopResult CdlSpinningTop<T>(
        int startIdx, int endIdx, T[] open, T[] high, T[] low, T[] close)
        where T : IFloatingPoint<T>
    {
        return new CandleSpinningTop<T>(open, high, low, close)
            .Compute(startIdx, endIdx);
    }
}
