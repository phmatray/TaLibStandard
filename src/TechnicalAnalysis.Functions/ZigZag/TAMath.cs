// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static ZigZagResult ZigZag(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double deviation)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outZigZag = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.ZigZag(
            startIdx,
            endIdx,
            high,
            low,
            deviation,
            ref outBegIdx,
            ref outNBElement,
            ref outZigZag);
            
        return new ZigZagResult(retCode, outBegIdx, outNBElement, outZigZag);
    }

    public static ZigZagResult ZigZag(int startIdx, int endIdx, double[] high, double[] low)
        => ZigZag(startIdx, endIdx, high, low, 5.0);

    public static ZigZagResult ZigZag(int startIdx, int endIdx, float[] high, float[] low, double deviation)
        => ZigZag(startIdx, endIdx, high.ToDouble(), low.ToDouble(), deviation);
        
    public static ZigZagResult ZigZag(int startIdx, int endIdx, float[] high, float[] low)
        => ZigZag(startIdx, endIdx, high, low, 5.0);
}