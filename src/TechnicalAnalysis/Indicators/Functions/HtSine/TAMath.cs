using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static HtSineResult HtSine(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outSine = new double[endIdx - startIdx + 1];
        double[] outLeadSine = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.HtSine(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outSine, ref outLeadSine);
            
        return new HtSineResult(retCode, outBegIdx, outNBElement, outSine, outLeadSine);
    }

    public static HtSineResult HtSine(int startIdx, int endIdx, float[] real)
        => HtSine(startIdx, endIdx, real.ToDouble());
}