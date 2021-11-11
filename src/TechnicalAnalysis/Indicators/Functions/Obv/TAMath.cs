using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static ObvResult Obv(int startIdx, int endIdx, double[] real, double[] volume)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Obv(startIdx, endIdx, real, volume, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static ObvResult Obv(int startIdx, int endIdx, float[] real, float[] volume)
        => Obv(startIdx, endIdx, real.ToDouble(), volume.ToDouble());
}