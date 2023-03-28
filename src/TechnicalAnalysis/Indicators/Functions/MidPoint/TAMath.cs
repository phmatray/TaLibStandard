using TechnicalAnalysis.Common;
// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MidPointResult MidPoint(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MidPoint(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
        return new MidPointResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MidPointResult MidPoint(int startIdx, int endIdx, double[] real)
        => MidPoint(startIdx, endIdx, real, 14);

    public static MidPointResult MidPoint(int startIdx, int endIdx, float[] real, int timePeriod)
        => MidPoint(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static MidPointResult MidPoint(int startIdx, int endIdx, float[] real)
        => MidPoint(startIdx, endIdx, real, 14);
}
