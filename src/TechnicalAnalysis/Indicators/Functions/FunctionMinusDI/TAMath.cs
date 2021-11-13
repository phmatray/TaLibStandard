using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMinusDI;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MinusDIResult MinusDI(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MinusDI(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MinusDIResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MinusDIResult MinusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => MinusDI(startIdx, endIdx, high, low, close, 14);

    public static MinusDIResult MinusDI(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        int timePeriod)
        => MinusDI(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

    public static MinusDIResult MinusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => MinusDI(startIdx, endIdx, high, low, close, 14);
}