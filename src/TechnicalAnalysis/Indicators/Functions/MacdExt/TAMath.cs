// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MacdExtResult MacdExt(
        int startIdx,
        int endIdx,
        double[] real,
        int fastPeriod,
        MAType fastMAType,
        int slowPeriod,
        MAType slowMAType,
        int signalPeriod,
        MAType signalMAType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outMACD = new double[endIdx - startIdx + 1];
        double[] outMACDSignal = new double[endIdx - startIdx + 1];
        double[] outMACDHist = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MacdExt(
            startIdx,
            endIdx,
            real,
            fastPeriod,
            fastMAType,
            slowPeriod,
            slowMAType,
            signalPeriod,
            signalMAType,
            ref outBegIdx,
            ref outNBElement,
            ref outMACD,
            ref outMACDSignal,
            ref outMACDHist);
            
        return new MacdExtResult(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
    }
        
    public static MacdExtResult MacdExt(int startIdx, int endIdx, double[] real)
        => MacdExt(startIdx, endIdx, real, 12, MAType.Sma, 26, MAType.Sma, 9, MAType.Sma);

    public static MacdExtResult MacdExt(
        int startIdx,
        int endIdx,
        float[] real,
        int fastPeriod,
        MAType fastMAType,
        int slowPeriod,
        MAType slowMAType,
        int signalPeriod,
        MAType signalMAType)
        => MacdExt(
            startIdx,
            endIdx,
            real.ToDouble(),
            fastPeriod,
            fastMAType,
            slowPeriod,
            slowMAType,
            signalPeriod,
            signalMAType);
        
    public static MacdExtResult MacdExt(int startIdx, int endIdx, float[] real)
        => MacdExt(startIdx, endIdx, real, 12, MAType.Sma, 26, MAType.Sma, 9, MAType.Sma);
}
