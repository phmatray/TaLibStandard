using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static RsiResult Rsi(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Rsi(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static RsiResult Rsi(int startIdx, int endIdx, double[] real)
        => Rsi(startIdx, endIdx, real, 14);

    public static RsiResult Rsi(int startIdx, int endIdx, float[] real, int timePeriod)
        => Rsi(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static RsiResult Rsi(int startIdx, int endIdx, float[] real)
        => Rsi(startIdx, endIdx, real, 14);
}
