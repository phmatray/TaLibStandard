using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static TemaResult Tema(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Tema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static TemaResult Tema(int startIdx, int endIdx, double[] real)
        => Tema(startIdx, endIdx, real, 30);

    public static TemaResult Tema(int startIdx, int endIdx, float[] real, int timePeriod)
        => Tema(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static TemaResult Tema(int startIdx, int endIdx, float[] real)
        => Tema(startIdx, endIdx, real, 30);
}
