// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static RocRResult RocR(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.RocR(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new RocRResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static RocRResult RocR(int startIdx, int endIdx, double[] real)
        => RocR(startIdx, endIdx, real, 10);

    public static RocRResult RocR(int startIdx, int endIdx, float[] real, int timePeriod)
        => RocR(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static RocRResult RocR(int startIdx, int endIdx, float[] real)
        => RocR(startIdx, endIdx, real, 10);
}
