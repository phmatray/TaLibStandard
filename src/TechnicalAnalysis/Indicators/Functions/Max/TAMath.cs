using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MaxResult Max(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Max(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MaxResult Max(int startIdx, int endIdx, double[] real)
        => Max(startIdx, endIdx, real, 30);

    public static MaxResult Max(int startIdx, int endIdx, float[] real, int timePeriod)
        => Max(startIdx, endIdx, real.ToDouble(), timePeriod);

    public static MaxResult Max(int startIdx, int endIdx, float[] real)
        => Max(startIdx, endIdx, real, 30);
}
