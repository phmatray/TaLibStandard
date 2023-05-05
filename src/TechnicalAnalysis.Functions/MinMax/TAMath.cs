// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static MinMaxResult MinMax(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outMin = new double[endIdx - startIdx + 1];
        double[] outMax = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MinMax(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMin,
            ref outMax);
            
        return new MinMaxResult(retCode, outBegIdx, outNBElement, outMin, outMax);
    }

    public static MinMaxResult MinMax(int startIdx, int endIdx, double[] real)
        => MinMax(startIdx, endIdx, real, 30);

    public static MinMaxResult MinMax(int startIdx, int endIdx, float[] real, int timePeriod)
        => MinMax(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static MinMaxResult MinMax(int startIdx, int endIdx, float[] real)
        => MinMax(startIdx, endIdx, real, 30);
}
