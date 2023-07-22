// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    public static AroonResult Aroon(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outAroonDown = new double[endIdx - startIdx + 1];
        double[] outAroonUp = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Aroon(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outAroonDown,
            ref outAroonUp);
            
        return new AroonResult(retCode, outBegIdx, outNBElement, outAroonDown, outAroonUp);
    }

    public static AroonResult Aroon(int startIdx, int endIdx, double[] high, double[] low)
        => Aroon(startIdx, endIdx, high, low, 14);

    public static AroonResult Aroon(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
        => Aroon(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

    public static AroonResult Aroon(int startIdx, int endIdx, float[] high, float[] low)
        => Aroon(startIdx, endIdx, high, low, 14);
}
