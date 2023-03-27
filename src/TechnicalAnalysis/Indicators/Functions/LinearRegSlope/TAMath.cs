using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.LinearRegSlope(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, double[] real)
        => LinearRegSlope(startIdx, endIdx, real, 14);

    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, float[] real, int timePeriod)
        => LinearRegSlope(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static LinearRegSlopeResult LinearRegSlope(int startIdx, int endIdx, float[] real)
        => LinearRegSlope(startIdx, endIdx, real, 14);
}
