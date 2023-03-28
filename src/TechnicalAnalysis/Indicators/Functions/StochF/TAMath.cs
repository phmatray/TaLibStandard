// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static StochFResult StochF(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int fastK_Period,
        int fastD_Period,
        MAType fastD_MAType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outFastK = new double[endIdx - startIdx + 1];
        double[] outFastD = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.StochF(
            startIdx,
            endIdx,
            high,
            low,
            close,
            fastK_Period,
            fastD_Period,
            fastD_MAType,
            ref outBegIdx,
            ref outNBElement,
            ref outFastK,
            ref outFastD);
            
        return new StochFResult(retCode, outBegIdx, outNBElement, outFastK, outFastD);
    }

    public static StochFResult StochF(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);

    public static StochFResult StochF(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        int fastK_Period,
        int fastD_Period,
        MAType fastD_MAType)
        => StochF(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            close.ToDouble(),
            fastK_Period,
            fastD_Period,
            fastD_MAType);
        
    public static StochFResult StochF(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);
}
