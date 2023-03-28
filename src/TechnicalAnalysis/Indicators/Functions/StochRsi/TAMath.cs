// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static StochRsiResult StochRsi(
        int startIdx,
        int endIdx,
        double[] real,
        int timePeriod,
        int fastK_Period,
        int fastD_Period,
        MAType fastD_MAType)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outFastK = new double[endIdx - startIdx + 1];
        double[] outFastD = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.StochRsi(
            startIdx,
            endIdx,
            real,
            timePeriod,
            fastK_Period,
            fastD_Period,
            fastD_MAType,
            ref outBegIdx,
            ref outNBElement,
            ref outFastK,
            ref outFastD);
            
        return new StochRsiResult(retCode, outBegIdx, outNBElement, outFastK, outFastD);
    }

    public static StochRsiResult StochRsi(int startIdx, int endIdx, double[] real)
        => StochRsi(startIdx, endIdx, real, 14, 5, 3, MAType.Sma);

    public static StochRsiResult StochRsi(
        int startIdx,
        int endIdx,
        float[] real,
        int timePeriod,
        int fastK_Period,
        int fastD_Period,
        MAType fastD_MAType)
        => StochRsi(startIdx, endIdx, real.ToDouble(), timePeriod, fastK_Period, fastD_Period, fastD_MAType);
        
    public static StochRsiResult StochRsi(int startIdx, int endIdx, float[] real)
        => StochRsi(startIdx, endIdx, real, 14, 5, 3, MAType.Sma);
}
