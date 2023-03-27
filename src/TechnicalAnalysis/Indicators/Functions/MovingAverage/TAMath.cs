using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MovingAverageResult MovingAverage(
        int startIdx,
        int endIdx,
        double[] real,
        int timePeriod,
        MAType maType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MovingAverage(
            startIdx,
            endIdx,
            real,
            timePeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);

        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, double[] real)
        => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);

    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, float[] real, int timePeriod, MAType maType)
        => MovingAverage(startIdx, endIdx, real.ToDouble(), timePeriod, maType);

    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, float[] real)
        => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);
}
