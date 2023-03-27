using TechnicalAnalysis.Candles.CandleMorningStar;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMorningStarResult CdlMorningStar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
    {
        return new CandleMorningStar(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    public static CandleMorningStarResult CdlMorningStar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return CdlMorningStar(startIdx, endIdx, open, high, low, close, 0.3);
    }

    public static CandleMorningStarResult CdlMorningStar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
    {
        return CdlMorningStar(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
    }

    public static CandleMorningStarResult CdlMorningStar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlMorningStar(startIdx, endIdx, open, high, low, close, 0.3);
    }
}
