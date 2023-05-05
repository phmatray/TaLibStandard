// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static CorrelResult Correl(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Correl(
            startIdx,
            endIdx,
            real0,
            real1,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new CorrelResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    public static CorrelResult Correl(int startIdx, int endIdx, double[] real0, double[] real1)
        => Correl(startIdx, endIdx, real0, real1, 30);

    public static CorrelResult Correl(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod)
        => Correl(startIdx, endIdx, real0.ToDouble(), real1.ToDouble(), timePeriod);
        
    public static CorrelResult Correl(int startIdx, int endIdx, float[] real0, float[] real1)
        => Correl(startIdx, endIdx, real0, real1, 30);
}
