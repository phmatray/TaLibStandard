using System;
using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode HtDcPeriod(
            int startIdx,
            int endIdx,
            in double[] inReal,
            ref int outBegIdx,
            ref int outNBElement,
            ref double[] outReal)
        {
            double smoothedValue;
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
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inReal == null)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            double rad2Deg = 180.0 / (4.0 * Math.Atan(1.0));
            int lookbackTotal = (int)Globals.unstablePeriod[6] + 32;
            if (startIdx < lookbackTotal)
            {
                startIdx = lookbackTotal;
            }

            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
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
            double detrender = 0.0;
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
            double q1 = 0.0;
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
            double jI = 0.0;
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
            double jQ = 0.0;
            double prevJQOdd = 0.0;
            double prevJQEven = 0.0;
            double prevJQInputOdd = 0.0;
            double prevJQInputEven = 0.0;
            double period = 0.0;
            int outIdx = 0;
            double prevQ2 = 0.0;
            double prevI2 = prevQ2;
            double Im = 0.0;
            double Re = Im;
            double I1ForEvenPrev3 = 0.0;
            double I1ForOddPrev3 = I1ForEvenPrev3;
            double I1ForEvenPrev2 = 0.0;
            double I1ForOddPrev2 = I1ForEvenPrev2;
            double smoothPeriod = 0.0;
            while (true)
            {
                double hilbertTempReal;
                double I2;
                double Q2;
                if (today > endIdx)
                {
                    break;
                }

                double adjustedPrevPeriod = 0.075 * period + 0.54;
                double todayValue = inReal[today];
                periodWMASub += todayValue;
                periodWMASub -= trailingWMAValue;
                periodWMASum += todayValue * 4.0;
                trailingWMAValue = inReal[trailingWMAIdx];
                trailingWMAIdx++;
                smoothedValue = periodWMASum * 0.1;
                periodWMASum -= periodWMASub;
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
                    hilbertTempReal = A * I1ForEvenPrev3;
                    jI = -jIEven[hilbertIdx];
                    jIEven[hilbertIdx] = hilbertTempReal;
                    jI += hilbertTempReal;
                    jI -= prevJIEven;
                    prevJIEven = B * prevJIInputEven;
                    jI += prevJIEven;
                    prevJIInputEven = I1ForEvenPrev3;
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

                    Q2 = 0.2 * (q1 + jI) + 0.8 * prevQ2;
                    I2 = 0.2 * (I1ForEvenPrev3 - jQ) + 0.8 * prevI2;
                    I1ForOddPrev3 = I1ForOddPrev2;
                    I1ForOddPrev2 = detrender;
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
                    hilbertTempReal = A * I1ForOddPrev3;
                    jI = -jIOdd[hilbertIdx];
                    jIOdd[hilbertIdx] = hilbertTempReal;
                    jI += hilbertTempReal;
                    jI -= prevJIOdd;
                    prevJIOdd = B * prevJIInputOdd;
                    jI += prevJIOdd;
                    prevJIInputOdd = I1ForOddPrev3;
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
                    Q2 = 0.2 * (q1 + jI) + 0.8 * prevQ2;
                    I2 = 0.2 * (I1ForOddPrev3 - jQ) + 0.8 * prevI2;
                    I1ForEvenPrev3 = I1ForEvenPrev2;
                    I1ForEvenPrev2 = detrender;
                }

                Re = 0.2 * (I2 * prevI2 + Q2 * prevQ2) + 0.8 * Re;
                Im = 0.2 * (I2 * prevQ2 - Q2 * prevI2) + 0.8 * Im;
                prevQ2 = Q2;
                prevI2 = I2;
                tempReal = period;
                if (Im != 0.0 && Re != 0.0)
                {
                    period = 360.0 / (Math.Atan(Im / Re) * rad2Deg);
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

                if (period < 6.0)
                {
                    period = 6.0;
                }
                else if (period > 50.0)
                {
                    period = 50.0;
                }

                period = 0.2 * period + 0.8 * tempReal;
                smoothPeriod = 0.33 * period + 0.67 * smoothPeriod;
                if (today >= startIdx)
                {
                    outReal[outIdx] = smoothPeriod;
                    outIdx++;
                }

                today++;
            }

            outNBElement = outIdx;
            return RetCode.Success;
        }

        public static int HtDcPeriodLookback()
        {
            return (int)Globals.unstablePeriod[6] + 32;
        }
    }
}
