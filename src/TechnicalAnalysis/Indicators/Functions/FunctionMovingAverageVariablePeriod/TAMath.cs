using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionMovingAverageVariablePeriod;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        double[] real,
        double[] periods,
        int minPeriod,
        int maxPeriod,
        MAType maType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MovingAverageVariablePeriod(
            startIdx,
            endIdx,
            real,
            periods,
            minPeriod,
            maxPeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MovingAverageVariablePeriodResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        double[] real,
        double[] periods)
        => MovingAverageVariablePeriod(startIdx, endIdx, real, periods, 2, 30, MAType.Sma);

    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        float[] real,
        float[] periods,
        int minPeriod,
        int maxPeriod,
        MAType maType)
        => MovingAverageVariablePeriod(
            startIdx,
            endIdx,
            real.ToDouble(),
            periods.ToDouble(),
            minPeriod,
            maxPeriod,
            maType);
        
    public static MovingAverageVariablePeriodResult MovingAverageVariablePeriod(
        int startIdx,
        int endIdx,
        float[] real,
        float[] periods)
        => MovingAverageVariablePeriod(startIdx, endIdx, real, periods, 2, 30, MAType.Sma);
}