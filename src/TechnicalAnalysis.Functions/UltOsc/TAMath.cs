// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static UltOscResult UltOsc(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int timePeriod1,
        int timePeriod2,
        int timePeriod3)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.UltOsc(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod1,
            timePeriod2,
            timePeriod3,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new UltOscResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static UltOscResult UltOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => UltOsc(startIdx, endIdx, high, low, close, 7, 14, 28);

    public static UltOscResult UltOsc(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        int timePeriod1,
        int timePeriod2,
        int timePeriod3)
        => UltOsc(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            close.ToDouble(),
            timePeriod1,
            timePeriod2,
            timePeriod3);
        
    public static UltOscResult UltOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => UltOsc(startIdx, endIdx, high, low, close, 7, 14, 28);
}
