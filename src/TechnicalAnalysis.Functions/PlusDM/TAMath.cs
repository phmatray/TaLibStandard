// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static PlusDMResult PlusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.PlusDM(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new PlusDMResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static PlusDMResult PlusDM(int startIdx, int endIdx, double[] high, double[] low)
        => PlusDM(startIdx, endIdx, high, low, 14);

    public static PlusDMResult PlusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
        => PlusDM(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

    public static PlusDMResult PlusDM(int startIdx, int endIdx, float[] high, float[] low)
        => PlusDM(startIdx, endIdx, high, low, 14);
}
