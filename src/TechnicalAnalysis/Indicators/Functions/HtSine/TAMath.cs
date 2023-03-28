// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static HtSineResult HtSine(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outSine = new double[endIdx - startIdx + 1];
        double[] outLeadSine = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.HtSine(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outSine, ref outLeadSine);
            
        return new HtSineResult(retCode, outBegIdx, outNBElement, outSine, outLeadSine);
    }

    public static HtSineResult HtSine(int startIdx, int endIdx, float[] real)
        => HtSine(startIdx, endIdx, real.ToDouble());
}
