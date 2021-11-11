using TechnicalAnalysis.Candles.CandlePiercing;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandlePiercingResult CdlPiercing(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandlePiercing(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandlePiercingResult CdlPiercing(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlPiercing(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}