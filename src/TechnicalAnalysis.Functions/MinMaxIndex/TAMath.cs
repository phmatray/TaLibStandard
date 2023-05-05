// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        int[] outMinIdx = new int[endIdx - startIdx + 1];
        int[] outMaxIdx = new int[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.MinMaxIndex(
            startIdx,
            endIdx,
            real,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMinIdx,
            ref outMaxIdx);
            
        return new MinMaxIndexResult(retCode, outBegIdx, outNBElement, outMinIdx, outMaxIdx);
    }
        
    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, double[] real)
        => MinMaxIndex(startIdx, endIdx, real, 30);

    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, float[] real, int timePeriod)
        => MinMaxIndex(startIdx, endIdx, real.ToDouble(), timePeriod);        

    public static MinMaxIndexResult MinMaxIndex(int startIdx, int endIdx, float[] real)
        => MinMaxIndex(startIdx, endIdx, real, 30);
}
