﻿// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

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

        return new MovingAverageResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, double[] real)
        => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);

    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, float[] real, int timePeriod, MAType maType)
        => MovingAverage(startIdx, endIdx, real.ToDouble(), timePeriod, maType);

    public static MovingAverageResult MovingAverage(int startIdx, int endIdx, float[] real)
        => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);
}
