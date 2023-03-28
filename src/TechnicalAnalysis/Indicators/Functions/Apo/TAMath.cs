// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static ApoResult Apo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, MAType maType)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Apo(
            startIdx,
            endIdx,
            real,
            fastPeriod,
            slowPeriod,
            maType,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new ApoResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static ApoResult Apo(int startIdx, int endIdx, double[] real)
        => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);

    public static ApoResult Apo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, MAType maType)
        => Apo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);

    public static ApoResult Apo(int startIdx, int endIdx, float[] real)
        => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);
}
