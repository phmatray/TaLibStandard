﻿// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        int[] outInteger = new int[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MaxIndex(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outInteger);
            
        return new MaxIndexResult(retCode, outBegIdx, outNBElement, outInteger);
    }
        
    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real)
        => MaxIndex(startIdx, endIdx, real, 30);

    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real, int timePeriod)
        => MaxIndex(startIdx, endIdx, real.ToDouble(), timePeriod);

    public static MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real)
        => MaxIndex(startIdx, endIdx, real, 30);
}
