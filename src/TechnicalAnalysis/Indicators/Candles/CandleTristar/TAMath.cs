using TechnicalAnalysis.Candles.CandleTristar;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleTristarResult CdlTristar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleTristar(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleTristarResult CdlTristar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlTristar(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
