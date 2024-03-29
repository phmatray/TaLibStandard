﻿// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static AdxrResult Adxr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Adxr(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new AdxrResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static AdxrResult Adxr(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => Adxr(startIdx, endIdx, high, low, close, 14);

    public static AdxrResult Adxr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
        => Adxr(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);
        
    public static AdxrResult Adxr(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => Adxr(startIdx, endIdx, high, low, close, 14);
}
