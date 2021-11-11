using TechnicalAnalysis.Candles.CandleAbandonedBaby;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleAbandonedBabyResult CdlAbandonedBaby(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
    {
        return new CandleAbandonedBaby(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }
        
    public static CandleAbandonedBabyResult CdlAbandonedBaby(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return CdlAbandonedBaby(startIdx, endIdx, open, high, low, close, 0.3);
    }

    public static CandleAbandonedBabyResult CdlAbandonedBaby(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
    {
        return CdlAbandonedBaby(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
    }

    public static CandleAbandonedBabyResult CdlAbandonedBaby(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlAbandonedBaby(startIdx, endIdx, open, high, low, close, 0.3);
    }
}