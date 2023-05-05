// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static StochResult Stoch(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double[] close,
        int fastKPeriod,
        int slowKPeriod,
        MAType slowKMAType,
        int slowDPeriod,
        MAType slowDMAType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outSlowK = new double[endIdx - startIdx + 1];
        double[] outSlowD = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Stoch(
            startIdx,
            endIdx,
            high,
            low,
            close,
            fastKPeriod,
            slowKPeriod,
            slowKMAType,
            slowDPeriod,
            slowDMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outSlowK,
            ref outSlowD);
            
        return new StochResult(retCode, outBegIdx, outNBElement, outSlowK, outSlowD);
    }

    public static StochResult Stoch(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        => Stoch(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma, 3, MAType.Sma);

    public static StochResult Stoch(
        int startIdx,
        int endIdx,
        float[] high,
        float[] low,
        float[] close,
        int fastKPeriod,
        int slowKPeriod,
        MAType slowKMAType,
        int slowDPeriod,
        MAType slowDMAType)
        => Stoch(
            startIdx,
            endIdx,
            high.ToDouble(),
            low.ToDouble(),
            close.ToDouble(),
            fastKPeriod,
            slowKPeriod,
            slowKMAType,
            slowDPeriod,
            slowDMAType);
        
    public static StochResult Stoch(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        => Stoch(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma, 3, MAType.Sma);
}
