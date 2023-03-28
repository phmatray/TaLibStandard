// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static StdDevResult StdDev(int startIdx, int endIdx, double[] real, int timePeriod, double nbDev)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.StdDev(
            startIdx,
            endIdx,
            real,
            timePeriod,
            nbDev,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new StdDevResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static StdDevResult StdDev(int startIdx, int endIdx, double[] real)
        => StdDev(startIdx, endIdx, real, 5, 1.0);

    public static StdDevResult StdDev(int startIdx, int endIdx, float[] real, int timePeriod, double nbDev)
        => StdDev(startIdx, endIdx, real.ToDouble(), timePeriod, nbDev);
        
    public static StdDevResult StdDev(int startIdx, int endIdx, float[] real)
        => StdDev(startIdx, endIdx, real, 5, 1.0);
}
