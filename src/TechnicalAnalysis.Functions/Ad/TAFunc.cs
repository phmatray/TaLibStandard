// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Chaikin Accumulation/Distribution Line (A/D Line) - a volume-based indicator that measures cumulative money flow.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="inClose">Input array of closing prices.</param>
    /// <param name="inVolume">Input array of volume data.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the A/D Line values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The A/D Line combines price and volume to show how money is flowing into or out of a security.
    /// 
    /// Calculation:
    /// 1. Money Flow Multiplier = [(Close - Low) - (High - Close)] / (High - Low)
    /// 2. Money Flow Volume = Money Flow Multiplier × Volume
    /// 3. A/D Line = Previous A/D Line + Money Flow Volume
    /// 
    /// Interpretation:
    /// - Rising A/D Line: Buying pressure (accumulation)
    /// - Falling A/D Line: Selling pressure (distribution)
    /// - Divergence with price: Potential trend reversal
    /// - Confirms price trends when moving in same direction
    /// 
    /// The A/D Line is cumulative, so absolute values are less important than the direction and divergences.
    /// </remarks>
    public static RetCode Ad(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double[] inClose,
        in double[] inVolume,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        var inCloseLocal = inClose;
        var inHighLocal = inHigh;
        var inLowLocal = inLow;
        var inVolumeLocal = inVolume;
        var outRealLocal = outReal;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHighLocal, inLowLocal, inCloseLocal, inVolumeLocal, outRealLocal)
        );
        if (validation != Success)
        {
            return validation;
        }

        int nbBar = endIdx - startIdx + 1;
        outNBElement = nbBar;
        outBegIdx = startIdx;
        int currentBar = startIdx;
        int outIdx = 0;
        double ad = 0.0;
        while (true)
        {
            if (nbBar == 0)
            {
                break;
            }

            double high = inHigh[currentBar];
            double low = inLow[currentBar];
            double tmp = high - low;
            double close = inClose[currentBar];
            if (tmp > 0.0)
            {
                ad += (close - low - (high - close)) / tmp * inVolume[currentBar];
            }

            outReal[outIdx] = ad;
            outIdx++;
            currentBar++;
            nbBar--;
        }

        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for A/D Line calculation.
    /// </summary>
    /// <returns>Always returns 0 as the A/D Line can be calculated from the first data point.</returns>
    public static int AdLookback()
    {
        return 0;
    }
}
