// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Hilbert Transform - Sine Wave indicator.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input array.</param>
    /// <param name="endIdx">The ending index for the calculation within the input array.</param>
    /// <param name="inReal">Input array of price data (typically closing prices).</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outSine">Output array for the Sine Wave values.</param>
    /// <param name="outLeadSine">Output array for the Lead Sine Wave values (45 degrees phase lead).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The Hilbert Transform - Sine Wave indicator was developed by John Ehlers and uses digital signal 
    /// processing techniques to measure market cycles. It generates two outputs:
    /// 
    /// 1. Sine Wave: Oscillates between -1 and +1, representing the current phase of the detected cycle
    /// 2. Lead Sine: A sine wave with a 45-degree phase lead, used for early cycle detection
    /// 
    /// How it works:
    /// - Applies the Hilbert Transform to decompose price into cycle components
    /// - Calculates the dominant cycle period using phase accumulation
    /// - Generates sine waves based on the instantaneous phase
    /// - The crossing of Sine and Lead Sine indicates cycle turning points
    /// 
    /// Interpretation:
    /// - When Sine crosses above Lead Sine: Potential cycle bottom (buy signal)
    /// - When Sine crosses below Lead Sine: Potential cycle top (sell signal)
    /// - Indicator works best in cycling (ranging) markets
    /// - May produce false signals in strongly trending markets
    /// 
    /// Common use cases:
    /// - Identifying market cycles and their turning points
    /// - Distinguishing between trending and cycling market conditions
    /// - Timing entries and exits in range-bound markets
    /// - Confirming other oscillator signals
    /// 
    /// Limitations:
    /// - Requires significant historical data (lookback period of 63+ bars)
    /// - Less effective in strongly trending markets
    /// - Subject to whipsaws during transitions between trends and cycles
    /// - Best used in conjunction with trend indicators for filtering
    /// 
    /// The indicator uses advanced mathematics including:
    /// - Weighted Moving Average (WMA) for smoothing
    /// - Hilbert Transform for cycle decomposition
    /// - Phase accumulation for period detection
    /// - Trigonometric calculations for sine wave generation
    /// </remarks>
    public static RetCode HtSine(
        int startIdx,
        int endIdx,
        in double[] inReal,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outSine,
        ref double[] outLeadSine)
    {
        double smoothedValue;
        const double A = HilbertTransformConstants.A;
        const double B = HilbertTransformConstants.B;
        double[] detrenderOdd = new double[3];
        double[] detrenderEven = new double[3];
        double[] q1Odd = new double[3];
        double[] q1Even = new double[3];
        double[] jIOdd = new double[3];
        double[] jIEven = new double[3];
        double[] jQOdd = new double[3];
        double[] jQEven = new double[3];
        int smoothPriceIdx = 0;
        int maxIdxSmoothPrice = 49;
        RetCode validation = ValidationHelper.ValidateAll(
            () => ValidationHelper.ValidateIndexRange(startIdx, endIdx),
            () => ValidationHelper.ValidateArrays(inReal, outSine, outLeadSine)
        );
        if (validation != Success)
        {
            return validation;
        }

        double[] smoothPrice = new double[maxIdxSmoothPrice + 1];

        double tempReal = Math.Atan(1.0);
        double rad2Deg = 45.0 / tempReal;
        double deg2Rad = 1.0 / rad2Deg;
        double constDeg2RadBy360 = tempReal * 8.0;
        int lookbackTotal = (int)TACore.Globals.UnstablePeriod[FuncUnstId.HtSine] + 63;
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
        tempReal = inReal[today];
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
        int i = 34;
        do
        {
            tempReal = inReal[today];
            today++;
            periodWMASub += tempReal;
            periodWMASub -= trailingWMAValue;
            periodWMASum += tempReal * 4.0;
            trailingWMAValue = inReal[trailingWMAIdx];
            trailingWMAIdx++;
            smoothedValue = periodWMASum * 0.1;
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
        double i1ForEvenPrev3 = 0.0;
        double i1ForOddPrev3 = i1ForEvenPrev3;
        double i1ForEvenPrev2 = 0.0;
        double i1ForOddPrev2 = i1ForEvenPrev2;
        double smoothPeriod = 0.0;
        i = 0;
        while (i < 50)
        {
            smoothPrice[i] = 0.0;
            i++;
        }

        double dcPhase = 0.0;
        while (true)
        {
            double hilbertTempReal;
            double i2;
            double q2;
            if (today > endIdx)
            {
                outNBElement = outIdx;
                return Success;
            }

            double adjustedPrevPeriod = (0.075 * period) + 0.54;
            double todayValue = inReal[today];
            periodWMASub += todayValue;
            periodWMASub -= trailingWMAValue;
            periodWMASum += todayValue * 4.0;
            trailingWMAValue = inReal[trailingWMAIdx];
            trailingWMAIdx++;
            smoothedValue = periodWMASum * 0.1;
            periodWMASum -= periodWMASub;
            smoothPrice[smoothPriceIdx] = smoothedValue;
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

            double tempReal2 = 1.5 * tempReal;
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
            smoothPeriod = (0.33 * period) + (0.67 * smoothPeriod);
            double dcPeriod = smoothPeriod + 0.5;
            int dcPeriodInt = (int)dcPeriod;
            double realPart = 0.0;
            double imagPart = 0.0;
            int idx = smoothPriceIdx;
            for (i = 0; i < dcPeriodInt; i++)
            {
                tempReal = i * constDeg2RadBy360 / dcPeriodInt;
                tempReal2 = smoothPrice[idx];
                realPart += Math.Sin(tempReal) * tempReal2;
                imagPart += Math.Cos(tempReal) * tempReal2;
                if (idx == 0)
                {
                    idx = 49;
                }
                else
                {
                    idx--;
                }
            }

            tempReal = Math.Abs(imagPart);
            switch (tempReal)
            {
                case > 0.0:
                    dcPhase = Math.Atan(realPart / imagPart) * rad2Deg;
                    break;
                case <= 0.01:
                    switch (realPart)
                    {
                        case < 0.0:
                            dcPhase -= 90.0;
                            break;
                        case > 0.0:
                            dcPhase += 90.0;
                            break;
                    }

                    break;
            }

            dcPhase += 90.0;
            dcPhase += 360.0 / smoothPeriod;
            if (imagPart < 0.0)
            {
                dcPhase += 180.0;
            }

            if (dcPhase > 315.0)
            {
                dcPhase -= 360.0;
            }

            if (today >= startIdx)
            {
                outSine[outIdx] = Math.Sin(dcPhase * deg2Rad);
                outLeadSine[outIdx] = Math.Sin((dcPhase + 45.0) * deg2Rad);
                outIdx++;
            }

            smoothPriceIdx++;
            if (smoothPriceIdx > maxIdxSmoothPrice)
            {
                smoothPriceIdx = 0;
            }

            today++;
        }
    }

    /// <summary>
    /// Returns the lookback period required for the Hilbert Transform - Sine Wave calculation.
    /// </summary>
    /// <returns>The number of historical data points required before the first valid HT-Sine value can be calculated.</returns>
    /// <remarks>
    /// The Hilbert Transform - Sine Wave requires a substantial amount of historical data to properly 
    /// initialize its internal calculations and produce reliable results. The lookback period consists of:
    /// 
    /// - Base period of 63 bars for the Hilbert Transform calculations
    /// - Additional unstable period that may be configured for this function
    /// 
    /// This extended lookback is necessary because:
    /// - The indicator uses multiple stages of filtering and smoothing
    /// - Accurate cycle detection requires sufficient historical context
    /// - The Hilbert Transform needs to establish stable phase relationships
    /// 
    /// Typically returns 63 bars plus any additional unstable period configured globally.
    /// </remarks>
    public static int HtSineLookback()
    {
        return (int)TACore.Globals.UnstablePeriod[FuncUnstId.HtSine] + 63;
    }
}
