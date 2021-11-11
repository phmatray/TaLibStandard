using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static ApoResult Apo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, MAType maType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Apo(
            startIdx,
            endIdx,
            real,
            fastPeriod,
            slowPeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static ApoResult Apo(int startIdx, int endIdx, double[] real)
        => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);

    public static ApoResult Apo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, MAType maType)
        => Apo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);

    public static ApoResult Apo(int startIdx, int endIdx, float[] real)
        => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);
}