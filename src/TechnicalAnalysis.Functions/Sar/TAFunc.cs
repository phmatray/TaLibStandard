// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Parabolic SAR (Stop and Reverse) - a trend-following indicator that provides entry/exit points.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="optInAcceleration">Acceleration factor increment. Typical value: 0.02.</param>
    /// <param name="optInMaximum">Maximum acceleration factor. Typical value: 0.20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the SAR values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Parabolic SAR follows price movements and acts as a trailing stop-loss system.
    /// The indicator appears as dots above or below the price chart.
    /// 
    /// Key concepts:
    /// - SAR dots below price: Uptrend (long position)
    /// - SAR dots above price: Downtrend (short position)
    /// - Acceleration Factor (AF): Increases by acceleration increment when new highs/lows are made
    /// - Maximum AF: Caps the acceleration to prevent SAR from getting too close to price
    /// 
    /// Trading signals:
    /// - Price crosses above SAR: Buy signal (SAR flips to below price)
    /// - Price crosses below SAR: Sell signal (SAR flips to above price)
    /// - SAR acts as dynamic stop-loss level
    /// 
    /// Strengths:
    /// - Excellent for trending markets
    /// - Clear entry/exit signals
    /// - Built-in risk management
    /// 
    /// Weaknesses:
    /// - Generates whipsaws in ranging markets
    /// - Always in the market (no neutral position)
    /// - Late signals in fast-moving markets
    /// 
    /// Best used in conjunction with trend indicators to filter trades.
    /// </remarks>
    public static RetCode Sar(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        double optInAcceleration,
        in double optInMaximum,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        double sar;
        double ep;
        int tempInt = 0;
        double[] epTemp = new double[1];
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inHigh == null! || 
            inLow == null! ||
            optInAcceleration < 0.0 ||
            optInMaximum < 0.0 ||
            outReal == null!)
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

        double af = optInAcceleration;
        if (af > optInMaximum)
        {
            optInAcceleration = optInMaximum;
            af = optInAcceleration;
        }

        RetCode retCode = MinusDM(startIdx, startIdx, inHigh, inLow, 1, ref tempInt, ref tempInt, ref epTemp);
        int isLong = epTemp[0] > 0.0 ? 0 : 1;

        if (retCode != Success)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return retCode;
        }

        outBegIdx = startIdx;
        int outIdx = 0;
        int todayIdx = startIdx;
        double newHigh = inHigh[todayIdx - 1];
        double newLow = inLow[todayIdx - 1];
        if (isLong == 1)
        {
            ep = inHigh[todayIdx];
            sar = newLow;
        }
        else
        {
            ep = inLow[todayIdx];
            sar = newHigh;
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

                    outReal[outIdx] = sar;
                    outIdx++;
                    af = optInAcceleration;
                    ep = newLow;
                    sar += af * (ep - sar);
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
                        af += optInAcceleration;
                        if (af > optInMaximum)
                        {
                            af = optInMaximum;
                        }
                    }

                    sar += af * (ep - sar);
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

                outReal[outIdx] = sar;
                outIdx++;
                af = optInAcceleration;
                ep = newHigh;
                sar += af * (ep - sar);
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
                outReal[outIdx] = sar;
                outIdx++;
                if (newLow < ep)
                {
                    ep = newLow;
                    af += optInAcceleration;
                    if (af > optInMaximum)
                    {
                        af = optInMaximum;
                    }
                }

                sar += af * (ep - sar);
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
    /// Returns the lookback period required for Parabolic SAR calculation.
    /// </summary>
    /// <param name="optInAcceleration">Acceleration factor increment. Must be non-negative.</param>
    /// <param name="optInMaximum">Maximum acceleration factor. Must be non-negative.</param>
    /// <returns>Always returns 1 if parameters are valid, or -1 if parameters are invalid.</returns>
    public static int SarLookback(double optInAcceleration, double optInMaximum)
    {
        return optInAcceleration < 0.0 ||
            optInMaximum < 0.0
            ? -1
            : 1;
    }
}
