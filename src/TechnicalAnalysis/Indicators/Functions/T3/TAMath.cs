using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static T3Result T3(int startIdx, int endIdx, double[] real, int timePeriod, double vFactor)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.T3(
            startIdx,
            endIdx,
            real,
            timePeriod,
            vFactor,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static T3Result T3(int startIdx, int endIdx, double[] real)
        => T3(startIdx, endIdx, real, 5, 0.7);

    public static T3Result T3(int startIdx, int endIdx, float[] real, int timePeriod, double vFactor)
        => T3(startIdx, endIdx, real.ToDouble(), timePeriod, vFactor);
        
    public static T3Result T3(int startIdx, int endIdx, float[] real)
        => T3(startIdx, endIdx, real, 5, 0.7);
}
