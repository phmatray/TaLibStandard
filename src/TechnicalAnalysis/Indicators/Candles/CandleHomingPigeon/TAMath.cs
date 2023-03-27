using TechnicalAnalysis.Candles.CandleHomingPigeon;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHomingPigeonResult CdlHomingPigeon(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleHomingPigeon(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleHomingPigeonResult CdlHomingPigeon(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlHomingPigeon(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
