// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static SubResult Sub(int startIdx, int endIdx, double[] real0, double[] real1)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Sub(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new SubResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static SubResult Sub(int startIdx, int endIdx, float[] real0, float[] real1)
        => Sub(startIdx, endIdx, real0.ToDouble(), real1.ToDouble());
}
