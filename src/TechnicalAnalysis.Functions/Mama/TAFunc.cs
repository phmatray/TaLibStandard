// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the MESA Adaptive Moving Average (MAMA) and Following Adaptive Moving Average (FAMA).
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="optInFastLimit">Controls the maximum alpha for the fast-moving average. Range: 0.01 to 0.99. Typical value: 0.5.</param>
    /// <param name="optInSlowLimit">Controls the maximum alpha for the slow-moving average. Range: 0.01 to 0.99. Typical value: 0.05.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outMAMA">Output array for the MESA Adaptive Moving Average values.</param>
    /// <param name="outFAMA">Output array for the Following Adaptive Moving Average values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// MAMA is an adaptive moving average developed by John Ehlers that uses Hilbert Transform
    /// techniques to measure the dominant cycle period in the price data. The moving average
    /// adapts its smoothing factor based on the measured phase rate of change.
    /// 
    /// Key characteristics:
    /// - MAMA adapts quickly to price changes when the market is trending
    /// - It becomes more stable during cycling markets
    /// - FAMA is a smoothed version of MAMA that follows behind it
    /// - The difference between MAMA and FAMA can indicate trend strength
    /// 
    /// Trading signals:
    /// - Buy when MAMA crosses above FAMA
    /// - Sell when MAMA crosses below FAMA
    /// - The vertical distance between lines indicates trend strength
    /// - Convergence suggests potential trend change
    /// 
    /// The fast and slow limits control the adaptation range:
    /// - Fast limit: Maximum adaptation speed (typical: 0.5)
    /// - Slow limit: Minimum adaptation speed (typical: 0.05)
    /// </remarks>
    public static RetCode Mama(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in double optInFastLimit,
        in double optInSlowLimit,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outMAMA,
        ref double[] outFAMA)
    {
        const double A = 0.0962;
        const double B = 0.5769;
        double[] detrenderOdd = new double[3];
        double[] detrenderEven = new double[3];
        double[] q1Odd = new double[3];
        double[] q1Even = new double[3];
        double[] jIOdd = new double[3];
        double[] jIEven = new double[3];
        double[] jQOdd = new double[3];
        double[] jQEven = new double[3];
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null! ||
            optInFastLimit is < 0.01 or > 0.99 ||
            optInSlowLimit is < 0.01 or > 0.99 ||
            outMAMA == null! ||
            outFAMA == null!)
        {
            return BadParam;
        }

        double rad2Deg = 180.0 / (4.0 * Math.Atan(1.0));
        int lookbackTotal = (int)TACore.Globals.UnstablePeriod[FuncUnstId.Mama] + 32;
        if (startIdx < lookbackTotal)
        {
            startIdx = lookbackTotal;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        outBegIdx = startIdx;
        int trailingWMAIdx = startIdx - lookbackTotal;
        int today = trailingWMAIdx;
        double tempReal = inReal[today];
        today++;
        double periodWMASub = tempReal;
        double periodWMASum = tempReal;
        tempReal = inReal[today];
        today++;
        periodWMASub += tempReal;
        periodWMASum += tempReal * 2.0;
        tempReal = inReal[today];
        today++;
        periodWMASub += tempReal;
        periodWMASum += tempReal * 3.0;
        double trailingWMAValue = 0.0;
        int i = 9;
        do
        {
            tempReal = inReal[today];
            today++;
            periodWMASub += tempReal;
            periodWMASub -= trailingWMAValue;
            periodWMASum += tempReal * 4.0;
            trailingWMAValue = inReal[trailingWMAIdx];
            trailingWMAIdx++;
            periodWMASum -= periodWMASub;
            i--;
        }
        while (i != 0);

        int hilbertIdx = 0;
        detrenderOdd[0] = 0.0;
        detrenderOdd[1] = 0.0;
        detrenderOdd[2] = 0.0;
        detrenderEven[0] = 0.0;
        detrenderEven[1] = 0.0;
        detrenderEven[2] = 0.0;
        double prevDetrenderOdd = 0.0;
        double prevDetrenderEven = 0.0;
        double prevDetrenderInputOdd = 0.0;
        double prevDetrenderInputEven = 0.0;
        q1Odd[0] = 0.0;
        q1Odd[1] = 0.0;
        q1Odd[2] = 0.0;
        q1Even[0] = 0.0;
        q1Even[1] = 0.0;
        q1Even[2] = 0.0;
        double prevQ1Odd = 0.0;
        double prevQ1Even = 0.0;
        double prevQ1InputOdd = 0.0;
        double prevQ1InputEven = 0.0;
        jIOdd[0] = 0.0;
        jIOdd[1] = 0.0;
        jIOdd[2] = 0.0;
        jIEven[0] = 0.0;
        jIEven[1] = 0.0;
        jIEven[2] = 0.0;
        double prevJIOdd = 0.0;
        double prevJIEven = 0.0;
        double prevJIInputOdd = 0.0;
        double prevJIInputEven = 0.0;
        jQOdd[0] = 0.0;
        jQOdd[1] = 0.0;
        jQOdd[2] = 0.0;
        jQEven[0] = 0.0;
        jQEven[1] = 0.0;
        jQEven[2] = 0.0;
        double prevJQOdd = 0.0;
        double prevJQEven = 0.0;
        double prevJQInputOdd = 0.0;
        double prevJQInputEven = 0.0;
        double period = 0.0;
        int outIdx = 0;
        double prevQ2 = 0.0;
        double prevI2 = prevQ2;
        double im = 0.0;
        double re = im;
        double fama = 0.0;
        double mama = fama;
        double i1ForEvenPrev3 = 0.0;
        double i1ForOddPrev3 = i1ForEvenPrev3;
        double i1ForEvenPrev2 = 0.0;
        double i1ForOddPrev2 = i1ForEvenPrev2;
        double prevPhase = 0.0;
        while (true)
        {
            double hilbertTempReal;
            double tempReal2;
            double i2;
            double q2;
            if (today > endIdx)
            {
                break;
            }

            double adjustedPrevPeriod = (0.075 * period) + 0.54;
            double todayValue = inReal[today];
            periodWMASub += todayValue;
            periodWMASub -= trailingWMAValue;
            periodWMASum += todayValue * 4.0;
            trailingWMAValue = inReal[trailingWMAIdx];
            trailingWMAIdx++;
            double smoothedValue = periodWMASum * 0.1;
            periodWMASum -= periodWMASub;
            double detrender;
            double q1;
            double jI;
            double jQ;
            if (today % 2 == 0)
            {
                hilbertTempReal = A * smoothedValue;
                detrender = -detrenderEven[hilbertIdx];
                detrenderEven[hilbertIdx] = hilbertTempReal;
                detrender += hilbertTempReal;
                detrender -= prevDetrenderEven;
                prevDetrenderEven = B * prevDetrenderInputEven;
                detrender += prevDetrenderEven;
                prevDetrenderInputEven = smoothedValue;
                detrender *= adjustedPrevPeriod;
                hilbertTempReal = A * detrender;
                q1 = -q1Even[hilbertIdx];
                q1Even[hilbertIdx] = hilbertTempReal;
                q1 += hilbertTempReal;
                q1 -= prevQ1Even;
                prevQ1Even = B * prevQ1InputEven;
                q1 += prevQ1Even;
                prevQ1InputEven = detrender;
                q1 *= adjustedPrevPeriod;
                hilbertTempReal = A * i1ForEvenPrev3;
                jI = -jIEven[hilbertIdx];
                jIEven[hilbertIdx] = hilbertTempReal;
                jI += hilbertTempReal;
                jI -= prevJIEven;
                prevJIEven = B * prevJIInputEven;
                jI += prevJIEven;
                prevJIInputEven = i1ForEvenPrev3;
                jI *= adjustedPrevPeriod;
                hilbertTempReal = A * q1;
                jQ = -jQEven[hilbertIdx];
                jQEven[hilbertIdx] = hilbertTempReal;
                jQ += hilbertTempReal;
                jQ -= prevJQEven;
                prevJQEven = B * prevJQInputEven;
                jQ += prevJQEven;
                prevJQInputEven = q1;
                jQ *= adjustedPrevPeriod;
                hilbertIdx++;
                if (hilbertIdx == 3)
                {
                    hilbertIdx = 0;
                }

                q2 = (0.2 * (q1 + jI)) + (0.8 * prevQ2);
                i2 = (0.2 * (i1ForEvenPrev3 - jQ)) + (0.8 * prevI2);
                i1ForOddPrev3 = i1ForOddPrev2;
                i1ForOddPrev2 = detrender;
                tempReal2 = i1ForEvenPrev3 != 0.0 ? Math.Atan(q1 / i1ForEvenPrev3) * rad2Deg : 0.0;
            }
            else
            {
                hilbertTempReal = A * smoothedValue;
                detrender = -detrenderOdd[hilbertIdx];
                detrenderOdd[hilbertIdx] = hilbertTempReal;
                detrender += hilbertTempReal;
                detrender -= prevDetrenderOdd;
                prevDetrenderOdd = B * prevDetrenderInputOdd;
                detrender += prevDetrenderOdd;
                prevDetrenderInputOdd = smoothedValue;
                detrender *= adjustedPrevPeriod;
                hilbertTempReal = A * detrender;
                q1 = -q1Odd[hilbertIdx];
                q1Odd[hilbertIdx] = hilbertTempReal;
                q1 += hilbertTempReal;
                q1 -= prevQ1Odd;
                prevQ1Odd = B * prevQ1InputOdd;
                q1 += prevQ1Odd;
                prevQ1InputOdd = detrender;
                q1 *= adjustedPrevPeriod;
                hilbertTempReal = A * i1ForOddPrev3;
                jI = -jIOdd[hilbertIdx];
                jIOdd[hilbertIdx] = hilbertTempReal;
                jI += hilbertTempReal;
                jI -= prevJIOdd;
                prevJIOdd = B * prevJIInputOdd;
                jI += prevJIOdd;
                prevJIInputOdd = i1ForOddPrev3;
                jI *= adjustedPrevPeriod;
                hilbertTempReal = A * q1;
                jQ = -jQOdd[hilbertIdx];
                jQOdd[hilbertIdx] = hilbertTempReal;
                jQ += hilbertTempReal;
                jQ -= prevJQOdd;
                prevJQOdd = B * prevJQInputOdd;
                jQ += prevJQOdd;
                prevJQInputOdd = q1;
                jQ *= adjustedPrevPeriod;
                q2 = (0.2 * (q1 + jI)) + (0.8 * prevQ2);
                i2 = (0.2 * (i1ForOddPrev3 - jQ)) + (0.8 * prevI2);
                i1ForEvenPrev3 = i1ForEvenPrev2;
                i1ForEvenPrev2 = detrender;
                tempReal2 = i1ForOddPrev3 != 0.0 ? Math.Atan(q1 / i1ForOddPrev3) * rad2Deg : 0.0;
            }

            tempReal = prevPhase - tempReal2;
            prevPhase = tempReal2;
            if (tempReal < 1.0)
            {
                tempReal = 1.0;
            }

            if (tempReal > 1.0)
            {
                tempReal = optInFastLimit / tempReal;
                if (tempReal < optInSlowLimit)
                {
                    tempReal = optInSlowLimit;
                }
            }
            else
            {
                tempReal = optInFastLimit;
            }

            mama = (tempReal * todayValue) + ((1.0 - tempReal) * mama);
            tempReal *= 0.5;
            fama = (tempReal * mama) + ((1.0 - tempReal) * fama);
            if (today >= startIdx)
            {
                outMAMA[outIdx] = mama;
                outFAMA[outIdx] = fama;
                outIdx++;
            }

            re = (0.2 * ((i2 * prevI2) + (q2 * prevQ2))) + (0.8 * re);
            im = (0.2 * ((i2 * prevQ2) - (q2 * prevI2))) + (0.8 * im);
            prevQ2 = q2;
            prevI2 = i2;
            tempReal = period;
            if (im != 0.0 && re != 0.0)
            {
                period = 360.0 / (Math.Atan(im / re) * rad2Deg);
            }

            tempReal2 = 1.5 * tempReal;
            if (period > tempReal2)
            {
                period = tempReal2;
            }

            tempReal2 = 0.67 * tempReal;
            if (period < tempReal2)
            {
                period = tempReal2;
            }

            period = period switch
            {
                < 6.0 => 6.0,
                > 50.0 => 50.0,
                _ => period
            };

            period = (0.2 * period) + (0.8 * tempReal);
            today++;
        }

        outNBElement = outIdx;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period for the MAMA indicator.
    /// </summary>
    /// <param name="optInFastLimit">Controls the maximum alpha for the fast-moving average. Range: 0.01 to 0.99.</param>
    /// <param name="optInSlowLimit">Controls the maximum alpha for the slow-moving average. Range: 0.01 to 0.99.</param>
    /// <returns>The number of historical data points needed before the first MAMA/FAMA values can be calculated, or -1 if parameters are invalid.</returns>
    /// <remarks>
    /// The MAMA indicator requires a significant lookback period due to its use of the Hilbert Transform
    /// for cycle measurement. The base lookback period is 32 bars plus any additional unstable period
    /// configured for the MAMA function.
    /// </remarks>
    public static int MamaLookback(double optInFastLimit, double optInSlowLimit)
    {
        return optInFastLimit is < 0.01 or > 0.99 ||
            optInSlowLimit is < 0.01 or > 0.99
            ? -1
            : (int)TACore.Globals.UnstablePeriod[FuncUnstId.Mama] + 32;
    }
}
