// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static EmaResult Ema(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Ema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new EmaResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static EmaResult Ema(int startIdx, int endIdx, double[] real)
        => Ema(startIdx, endIdx, real, 30);

    public static EmaResult Ema(int startIdx, int endIdx, float[] real, int timePeriod)
        => Ema(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static EmaResult Ema(int startIdx, int endIdx, float[] real)
        => Ema(startIdx, endIdx, real, 30);
}
