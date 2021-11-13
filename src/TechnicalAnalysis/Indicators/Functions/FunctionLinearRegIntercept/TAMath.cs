using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionLinearRegIntercept;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.LinearRegIntercept(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new LinearRegInterceptResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, double[] real)
        => LinearRegIntercept(startIdx, endIdx, real, 14);

    public static LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, float[] real, int timePeriod)
        => LinearRegIntercept(startIdx, endIdx, real.ToDouble(), timePeriod);

    public static LinearRegInterceptResult LinearRegIntercept(int startIdx, int endIdx, float[] real)
        => LinearRegIntercept(startIdx, endIdx, real, 14);
}