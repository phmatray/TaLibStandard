using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MinMaxResult MinMax(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outMin = new double[endIdx - startIdx + 1];
        double[] outMax = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MinMax(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMin,
            ref outMax);
            
        return new MinMaxResult(retCode, outBegIdx, outNBElement, outMin, outMax);
    }

    public static MinMaxResult MinMax(int startIdx, int endIdx, double[] real)
        => MinMax(startIdx, endIdx, real, 30);

    public static MinMaxResult MinMax(int startIdx, int endIdx, float[] real, int timePeriod)
        => MinMax(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static MinMaxResult MinMax(int startIdx, int endIdx, float[] real)
        => MinMax(startIdx, endIdx, real, 30);
}