using TechnicalAnalysis.Candles.CandleKickingByLength;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleKickingByLengthResult CdlKickingByLength(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleKickingByLength(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleKickingByLengthResult CdlKickingByLength(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlKickingByLength(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}