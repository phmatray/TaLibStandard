// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MinusDM(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new MinusDMResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low)
        => MinusDM(startIdx, endIdx, high, low, 14);

    public static MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
        => MinusDM(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

    public static MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low)
        => MinusDM(startIdx, endIdx, high, low, 14);
}
