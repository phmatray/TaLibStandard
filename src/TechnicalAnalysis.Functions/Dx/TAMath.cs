// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static DxResult Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Dx(
            startIdx,
            endIdx,
            high,
            low,
            close,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new DxResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static DxResult Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => Dx(startIdx, endIdx, high, low, close, 14);

    public static DxResult Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
        => Dx(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

    public static DxResult Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => Dx(startIdx, endIdx, high, low, close, 14);
}
