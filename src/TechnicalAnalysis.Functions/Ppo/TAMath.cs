// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static PpoResult Ppo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, MAType maType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Ppo(
            startIdx,
            endIdx,
            real,
            fastPeriod,
            slowPeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new PpoResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static PpoResult Ppo(int startIdx, int endIdx, double[] real)
        => Ppo(startIdx, endIdx, real, 12, 26, MAType.Sma);

    public static PpoResult Ppo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, MAType maType)
        => Ppo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);
        
    public static PpoResult Ppo(int startIdx, int endIdx, float[] real)
        => Ppo(startIdx, endIdx, real, 12, 26, MAType.Sma);
}
