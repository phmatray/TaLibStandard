using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static WillRResult WillR(
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

        RetCode retCode = TACore.WillR(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new WillRResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static WillRResult WillR(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => WillR(startIdx, endIdx, high, low, close, 14);

    public static WillRResult WillR(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
        => WillR(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);
        
    public static WillRResult WillR(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => WillR(startIdx, endIdx, high, low, close, 14);
}