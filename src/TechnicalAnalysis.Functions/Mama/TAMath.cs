// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static MamaResult Mama(int startIdx, int endIdx, double[] real, double fastLimit, double slowLimit)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outMAMA = new double[endIdx - startIdx + 1];
        double[] outFAMA = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Mama(
            startIdx,
            endIdx,
            real,
            fastLimit,
            slowLimit,
            ref outBegIdx,
            ref outNBElement,
            ref outMAMA,
            ref outFAMA);
            
        return new MamaResult(retCode, outBegIdx, outNBElement, outMAMA, outFAMA);
    }
        
    public static MamaResult Mama(int startIdx, int endIdx, double[] real)
        => Mama(startIdx, endIdx, real, 0.5, 0.05);

    public static MamaResult Mama(int startIdx, int endIdx, float[] real, double fastLimit, double slowLimit)
        => Mama(startIdx, endIdx, real.ToDouble(), fastLimit, slowLimit);
        
    public static MamaResult Mama(int startIdx, int endIdx, float[] real)
        => Mama(startIdx, endIdx, real, 0.5, 0.05);
}
