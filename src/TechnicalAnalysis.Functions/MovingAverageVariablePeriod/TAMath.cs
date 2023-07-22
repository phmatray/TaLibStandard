// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

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

        RetCode retCode = TAFunc.MovingAverageVariablePeriod(
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
