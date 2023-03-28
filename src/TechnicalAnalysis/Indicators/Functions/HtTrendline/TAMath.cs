using TechnicalAnalysis.Common;
// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static HtTrendlineResult HtTrendline(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.HtTrendline(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new HtTrendlineResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static HtTrendlineResult HtTrendline(int startIdx, int endIdx, float[] real)
        => HtTrendline(startIdx, endIdx, real.ToDouble());
}
