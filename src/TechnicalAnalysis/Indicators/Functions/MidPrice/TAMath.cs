using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MidPriceResult MidPrice(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MidPrice(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MidPriceResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MidPriceResult MidPrice(int startIdx, int endIdx, double[] high, double[] low)
        => MidPrice(startIdx, endIdx, high, low, 14);

    public static MidPriceResult MidPrice(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
        => MidPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);
        
    public static MidPriceResult MidPrice(int startIdx, int endIdx, float[] high, float[] low)
        => MidPrice(startIdx, endIdx, high, low, 14);
}