using TechnicalAnalysis.Common;
// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MinResult Min(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Min(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new MinResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MinResult Min(int startIdx, int endIdx, double[] real)
        => Min(startIdx, endIdx, real, 30);

    public static MinResult Min(int startIdx, int endIdx, float[] real, int timePeriod)
        => Min(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static MinResult Min(int startIdx, int endIdx, float[] real)
        => Min(startIdx, endIdx, real, 30);
}
