using TechnicalAnalysis.Candles.CandleHaramiCross;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHaramiCrossResult CdlHaramiCross(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleHaramiCross(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleHaramiCrossResult CdlHaramiCross(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlHaramiCross(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}