using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static DemaResult Dema(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Dema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new DemaResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static DemaResult Dema(int startIdx, int endIdx, double[] real)
        => Dema(startIdx, endIdx, real, 30);

    public static DemaResult Dema(int startIdx, int endIdx, float[] real, int timePeriod)
        => Dema(startIdx, endIdx, real.ToDouble(), timePeriod);

    public static DemaResult Dema(int startIdx, int endIdx, float[] real)
        => Dema(startIdx, endIdx, real, 30);
}