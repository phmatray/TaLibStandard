using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static HtTrendModeResult HtTrendMode(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        RetCode retCode = TACore.HtTrendMode(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outInteger);
            
        return new(retCode, outBegIdx, outNBElement, outInteger);
    }

    public static HtTrendModeResult HtTrendMode(int startIdx, int endIdx, float[] real)
        => HtTrendMode(startIdx, endIdx, real.ToDouble());
}
