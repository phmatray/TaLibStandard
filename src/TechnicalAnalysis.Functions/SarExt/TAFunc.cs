// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Parabolic SAR - Extended (Enhanced SAR with additional parameters for better control).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="optInStartValue">Initial SAR value. Use 0 for automatic, positive for long, negative for short.</param>
    /// <param name="optInOffsetOnReverse">Percentage offset added when SAR reverses. Typical value: 0.0.</param>
    /// <param name="optInAccelerationInitLong">Initial acceleration factor for long positions. Typical value: 0.02.</param>
    /// <param name="optInAccelerationLong">Acceleration increment for long positions. Typical value: 0.02.</param>
    /// <param name="optInAccelerationMaxLong">Maximum acceleration factor for long positions. Typical value: 0.20.</param>
    /// <param name="optInAccelerationInitShort">Initial acceleration factor for short positions. Typical value: 0.02.</param>
    /// <param name="optInAccelerationShort">Acceleration increment for short positions. Typical value: 0.02.</param>
    /// <param name="optInAccelerationMaxShort">Maximum acceleration factor for short positions. Typical value: 0.20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the SAR values (negative values indicate short position).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Extended Parabolic SAR provides enhanced control over the standard SAR indicator.
    /// 
    /// Key enhancements:
    /// - Separate acceleration parameters for long and short positions
    /// - Customizable starting value and direction
    /// - Optional offset on reversal for reduced whipsaws
    /// - Negative output values indicate short positions
    /// 
    /// StartValue parameter:
    /// - 0: Automatic detection based on price movement
    /// - Positive: Start with long position at specified SAR value
    /// - Negative: Start with short position at absolute SAR value
    /// 
    /// Output interpretation:
    /// - Positive values: Long position (SAR below price)
    /// - Negative values: Short position (SAR above price)
    /// - Magnitude represents the actual SAR level
    /// 
    /// The offset parameter adds a percentage buffer when SAR reverses,
    /// helping to reduce false signals in choppy markets.
    /// 
    /// This extended version is particularly useful for:
    /// - Asymmetric market conditions (different behavior in uptrends vs downtrends)
    /// - Fine-tuning entry/exit levels
    /// - Reducing whipsaws through the offset parameter
    /// </remarks>
    public static RetCode SarExt(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double optInStartValue,
        in double optInOffsetOnReverse,
        double optInAccelerationInitLong,
        double optInAccelerationLong,
        in double optInAccelerationMaxLong,
        double optInAccelerationInitShort,
        double optInAccelerationShort,
        in double optInAccelerationMaxShort,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double sar;
        double ep;
        int isLong;
        double[] epTemp = new double[1];
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inHigh, inLow, outReal)
        );
        if (validation != Success)
        {
            return validation;
        }

        if (optInOffsetOnReverse < 0.0 ||
            optInAccelerationInitLong < 0.0 ||
            optInAccelerationLong < 0.0 ||
            optInAccelerationMaxLong < 0.0 ||
            optInAccelerationInitShort < 0.0 ||
            optInAccelerationShort < 0.0 ||
            optInAccelerationMaxShort < 0.0)
        {
            return BadParam;
        }

        if (startIdx < 1)
        {
            startIdx = 1;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        double afLong = optInAccelerationInitLong;
        double afShort = optInAccelerationInitShort;
        if (afLong > optInAccelerationMaxLong)
        {
            optInAccelerationInitLong = optInAccelerationMaxLong;
            afLong = optInAccelerationInitLong;
        }

        if (optInAccelerationLong > optInAccelerationMaxLong)
        {
            optInAccelerationLong = optInAccelerationMaxLong;
        }

        if (afShort > optInAccelerationMaxShort)
        {
            optInAccelerationInitShort = optInAccelerationMaxShort;
            afShort = optInAccelerationInitShort;
        }

        if (optInAccelerationShort > optInAccelerationMaxShort)
        {
            optInAccelerationShort = optInAccelerationMaxShort;
        }

        if (optInStartValue == 0.0)
        {
            int tempInt = 0;
            RetCode retCode = MinusDM(startIdx, startIdx, inHigh, inLow, 1, ref tempInt, ref tempInt, ref epTemp);
            isLong = epTemp[0] > 0.0 ? 0 : 1;

            if (retCode != Success)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return retCode;
            }
        }
        else
        {
            isLong = optInStartValue > 0.0 ? 1 : 0;
        }

        outBegIdx = startIdx;
        int outIdx = 0;
        int todayIdx = startIdx;
        double newHigh = inHigh[todayIdx - 1];
        double newLow = inLow[todayIdx - 1];
        switch (optInStartValue)
        {
            case 0.0 when isLong == 1:
                ep = inHigh[todayIdx];
                sar = newLow;
                break;
            case 0.0:
                ep = inLow[todayIdx];
                sar = newHigh;
                break;
            case > 0.0:
                ep = inHigh[todayIdx];
                sar = optInStartValue;
                break;
            default:
                ep = inLow[todayIdx];
                sar = Math.Abs(optInStartValue);
                break;
        }

        newLow = inLow[todayIdx];
        newHigh = inHigh[todayIdx];
        while (todayIdx <= endIdx)
        {
            double prevLow = newLow;
            double prevHigh = newHigh;
            newLow = inLow[todayIdx];
            newHigh = inHigh[todayIdx];
            todayIdx++;
            if (isLong == 1)
            {
                if (newLow <= sar)
                {
                    isLong = 0;
                    sar = ep;
                    if (sar < prevHigh)
                    {
                        sar = prevHigh;
                    }

                    if (sar < newHigh)
                    {
                        sar = newHigh;
                    }

                    if (optInOffsetOnReverse != 0.0)
                    {
                        sar += sar * optInOffsetOnReverse;
                    }

                    outReal[outIdx] = -sar;
                    outIdx++;
                    afShort = optInAccelerationInitShort;
                    ep = newLow;
                    sar += afShort * (ep - sar);
                    if (sar < prevHigh)
                    {
                        sar = prevHigh;
                    }

                    if (sar < newHigh)
                    {
                        sar = newHigh;
                    }
                }
                else
                {
                    outReal[outIdx] = sar;
                    outIdx++;
                    if (newHigh > ep)
                    {
                        ep = newHigh;
                        afLong += optInAccelerationLong;
                        if (afLong > optInAccelerationMaxLong)
                        {
                            afLong = optInAccelerationMaxLong;
                        }
                    }

                    sar += afLong * (ep - sar);
                    if (sar > prevLow)
                    {
                        sar = prevLow;
                    }

                    if (sar > newLow)
                    {
                        sar = newLow;
                    }
                }
            }
            else if (newHigh >= sar)
            {
                isLong = 1;
                sar = ep;
                if (sar > prevLow)
                {
                    sar = prevLow;
                }

                if (sar > newLow)
                {
                    sar = newLow;
                }

                if (optInOffsetOnReverse != 0.0)
                {
                    sar -= sar * optInOffsetOnReverse;
                }

                outReal[outIdx] = sar;
                outIdx++;
                afLong = optInAccelerationInitLong;
                ep = newHigh;
                sar += afLong * (ep - sar);
                if (sar > prevLow)
                {
                    sar = prevLow;
                }

                if (sar > newLow)
                {
                    sar = newLow;
                }
            }
            else
            {
                outReal[outIdx] = -sar;
                outIdx++;
                if (newLow < ep)
                {
                    ep = newLow;
                    afShort += optInAccelerationShort;
                    if (afShort > optInAccelerationMaxShort)
                    {
                        afShort = optInAccelerationMaxShort;
                    }
                }

                sar += afShort * (ep - sar);
                if (sar < prevHigh)
                {
                    sar = prevHigh;
                }

                if (sar < newHigh)
                {
                    sar = newHigh;
                }
            }
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period for the Extended Parabolic SAR function.
    /// </summary>
    /// <param name="optInStartValue">Initial SAR value (ignored for lookback calculation).</param>
    /// <param name="optInOffsetOnReverse">Percentage offset added when SAR reverses.</param>
    /// <param name="optInAccelerationInitLong">Initial acceleration factor for long positions.</param>
    /// <param name="optInAccelerationLong">Acceleration increment for long positions.</param>
    /// <param name="optInAccelerationMaxLong">Maximum acceleration factor for long positions.</param>
    /// <param name="optInAccelerationInitShort">Initial acceleration factor for short positions.</param>
    /// <param name="optInAccelerationShort">Acceleration increment for short positions.</param>
    /// <param name="optInAccelerationMaxShort">Maximum acceleration factor for short positions.</param>
    /// <returns>The minimum number of data points required (1), or -1 for invalid parameters.</returns>
    public static int SarExtLookback(
        double optInStartValue,
        double optInOffsetOnReverse,
        double optInAccelerationInitLong,
        double optInAccelerationLong,
        double optInAccelerationMaxLong,
        double optInAccelerationInitShort,
        double optInAccelerationShort,
        double optInAccelerationMaxShort)
    {
        return optInStartValue < 0.0 ||
               optInOffsetOnReverse < 0.0 ||
               optInAccelerationInitLong < 0.0 ||
               optInAccelerationLong < 0.0 ||
               optInAccelerationMaxLong < 0.0 ||
               optInAccelerationInitShort < 0.0 ||
               optInAccelerationShort < 0.0 ||
               optInAccelerationMaxShort < 0.0
            ? -1
            : 1;
    }
}
