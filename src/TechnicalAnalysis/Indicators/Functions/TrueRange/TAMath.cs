// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static TrueRangeResult TrueRange(int startIdx, int endIdx, double[] high, double[] low, double[] close)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.TrueRange(
            startIdx,
            endIdx,
            high,
            low,
            close,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new TrueRangeResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static TrueRangeResult TrueRange(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => TrueRange(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
}
