using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static HtPhasorResult HtPhasor(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outInPhase = new double[endIdx - startIdx + 1];
        double[] outQuadrature = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.HtPhasor(
            startIdx,
            endIdx,
            real,
            ref outBegIdx,
            ref outNBElement,
            ref outInPhase,
            ref outQuadrature);
            
        return new(retCode, outBegIdx, outNBElement, outInPhase, outQuadrature);
    }

    public static HtPhasorResult HtPhasor(int startIdx, int endIdx, float[] real)
        => HtPhasor(startIdx, endIdx, real.ToDouble());
}
