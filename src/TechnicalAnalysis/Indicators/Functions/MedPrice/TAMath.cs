using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MedPriceResult MedPrice(int startIdx, int endIdx, double[] high, double[] low)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MedPrice(startIdx, endIdx, high, low, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MedPriceResult MedPrice(int startIdx, int endIdx, float[] high, float[] low)
        => MedPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble());
}