// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static SarExtResult SarExt(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double startValue,
        double offsetOnReverse,
        double accelerationInitLong,
        double accelerationLong,
        double accelerationMaxLong,
        double accelerationInitShort,
        double accelerationShort,
        double accelerationMaxShort)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.SarExt(
            startIdx,
            endIdx,
            high,
            low,
            startValue,
            offsetOnReverse,
            accelerationInitLong,
            accelerationLong,
            accelerationMaxLong,
            accelerationInitShort,
            accelerationShort,
            accelerationMaxShort,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new SarExtResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static SarExtResult SarExt(int startIdx, int endIdx, double[] high, double[] low)
        => SarExt(startIdx, endIdx, high, low, 0.0, 0.0, 0.02, 0.02, 0.2, 0.02, 0.02, 0.2);

    public static SarExtResult SarExt(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        double startValue,
        double offsetOnReverse,
        double accelerationInitLong,
        double accelerationLong,
        double accelerationMaxLong,
        double accelerationInitShort,
        double accelerationShort,
        double accelerationMaxShort)
        => SarExt(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            startValue,
            offsetOnReverse,
            accelerationInitLong,
            accelerationLong,
            accelerationMaxLong,
            accelerationInitShort,
            accelerationShort,
            accelerationMaxShort);
        
    public static SarExtResult SarExt(int startIdx, int endIdx, float[] high, float[] low)
        => SarExt(startIdx, endIdx, high, low, 0.0, 0.0, 0.02, 0.02, 0.2, 0.02, 0.02, 0.2);
}
