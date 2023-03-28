// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static T3Result T3(int startIdx, int endIdx, double[] real, int timePeriod, double vFactor)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.T3(
            startIdx,
            endIdx,
            real,
            timePeriod,
            vFactor,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new T3Result(retCode, outBegIdx, outNBElement, outReal);
    }

    public static T3Result T3(int startIdx, int endIdx, double[] real)
        => T3(startIdx, endIdx, real, 5, 0.7);

    public static T3Result T3(int startIdx, int endIdx, float[] real, int timePeriod, double vFactor)
        => T3(startIdx, endIdx, real.ToDouble(), timePeriod, vFactor);
        
    public static T3Result T3(int startIdx, int endIdx, float[] real)
        => T3(startIdx, endIdx, real, 5, 0.7);
}
