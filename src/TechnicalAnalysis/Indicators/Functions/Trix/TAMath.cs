using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static TrixResult Trix(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Trix(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new TrixResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static TrixResult Trix(int startIdx, int endIdx, double[] real)
        => Trix(startIdx, endIdx, real, 30);

    public static TrixResult Trix(int startIdx, int endIdx, float[] real, int timePeriod)
        => Trix(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static TrixResult Trix(int startIdx, int endIdx, float[] real)
        => Trix(startIdx, endIdx, real, 30);
}