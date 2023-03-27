using TechnicalAnalysis.Candles.CandleThrusting;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleThrustingResult CdlThrusting(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleThrusting(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleThrustingResult CdlThrusting(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlThrusting(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
