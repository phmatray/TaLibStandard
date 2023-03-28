using TechnicalAnalysis.Common;
// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static AtanResult Atan(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Atan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new AtanResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static AtanResult Atan(int startIdx, int endIdx, float[] real)
        => Atan(startIdx, endIdx, real.ToDouble());
}
