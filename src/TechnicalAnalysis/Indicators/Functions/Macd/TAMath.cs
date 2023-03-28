// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MacdResult Macd(
        int startIdx,
        int endIdx,
        double[] real,
        int optInFastPeriod,
        int optInSlowPeriod,
        int optInSignalPeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outMACD = new double[endIdx - startIdx + 1];
        double[] outMACDSignal = new double[endIdx - startIdx + 1];
        double[] outMACDHist = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Macd(
            startIdx,
            endIdx,
            real,
            optInFastPeriod,
            optInSlowPeriod,
            optInSignalPeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMACD,
            ref outMACDSignal,
            ref outMACDHist);
            
        return new MacdResult(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
    }

    public static MacdResult Macd(int startIdx, int endIdx, double[] real)
        => Macd(startIdx, endIdx, real, 12, 26, 9);

    public static MacdResult Macd(
        int startIdx,
        int endIdx,
        float[] real,
        int optInFastPeriod,
        int optInSlowPeriod,
        int optInSignalPeriod)
        => Macd(startIdx, endIdx, real.ToDouble(), optInFastPeriod, optInSlowPeriod, optInSignalPeriod);
        
    public static MacdResult Macd(int startIdx, int endIdx, float[] real)
        => Macd(startIdx, endIdx, real, 12, 26, 9);
}
