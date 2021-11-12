using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static Log10Result Log10(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Log10(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new Log10Result(retCode, outBegIdx, outNBElement, outReal);
    }

    public static Log10Result Log10(int startIdx, int endIdx, float[] real)
        => Log10(startIdx, endIdx, real.ToDouble());
}