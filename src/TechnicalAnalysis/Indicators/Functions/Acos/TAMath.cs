// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static AcosResult Acos(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Acos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new AcosResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static AcosResult Acos(int startIdx, int endIdx, float[] real)
        => Acos(startIdx, endIdx, real.ToDouble());
}
