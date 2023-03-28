// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static PlusDIResult PlusDI(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.PlusDI(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new PlusDIResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static PlusDIResult PlusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => PlusDI(startIdx, endIdx, high, low, close, 14);

    public static PlusDIResult PlusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
        => PlusDI(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);
        
    public static PlusDIResult PlusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => PlusDI(startIdx, endIdx, high, low, close, 14);
}
