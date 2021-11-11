using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MomResult Mom(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Mom(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MomResult Mom(int startIdx, int endIdx, double[] real)
        => Mom(startIdx, endIdx, real, 10);

    public static MomResult Mom(int startIdx, int endIdx, float[] real, int timePeriod)
        => Mom(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static MomResult Mom(int startIdx, int endIdx, float[] real)
        => Mom(startIdx, endIdx, real, 10);
}