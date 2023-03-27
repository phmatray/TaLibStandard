using TechnicalAnalysis.Candles.CandleHarami;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleHaramiResult CdlHarami(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleHarami(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleHaramiResult CdlHarami(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlHarami(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
