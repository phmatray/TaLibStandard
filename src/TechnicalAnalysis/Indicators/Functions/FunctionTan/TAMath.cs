using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionTan;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static TanResult Tan(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Tan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new TanResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static TanResult Tan(int startIdx, int endIdx, float[] real)
        => Tan(startIdx, endIdx, real.ToDouble());
}