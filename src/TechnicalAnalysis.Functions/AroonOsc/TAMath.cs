// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.AroonOsc(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new AroonOscResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low)
        => AroonOsc(startIdx, endIdx, high, low, 14);

    public static AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
        => AroonOsc(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

    public static AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low)
        => AroonOsc(startIdx, endIdx, high, low, 14);
}
