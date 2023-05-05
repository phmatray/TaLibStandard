// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static HtPhasorResult HtPhasor(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outInPhase = new double[endIdx - startIdx + 1];
        double[] outQuadrature = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.HtPhasor(
            startIdx,
            endIdx,
            real,
            ref outBegIdx,
            ref outNBElement,
            ref outInPhase,
            ref outQuadrature);
            
        return new HtPhasorResult(retCode, outBegIdx, outNBElement, outInPhase, outQuadrature);
    }

    public static HtPhasorResult HtPhasor(int startIdx, int endIdx, float[] real)
        => HtPhasor(startIdx, endIdx, real.ToDouble());
}
