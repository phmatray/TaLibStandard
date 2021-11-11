using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static HtDcPhaseResult HtDcPhase(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.HtDcPhase(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static HtDcPhaseResult HtDcPhase(int startIdx, int endIdx, float[] real)
        => HtDcPhase(startIdx, endIdx, real.ToDouble());
}