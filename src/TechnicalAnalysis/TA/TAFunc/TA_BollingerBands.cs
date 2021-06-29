namespace TechnicalAnalysis
{
    using System;

    internal static partial class TACore
    {
        public static RetCode BollingerBands(
            int startIdx,
            int endIdx,
            double[] inReal,
            int optInTimePeriod,
            double optInNbDevUp,
            double optInNbDevDn,
            MAType optInMAType,
            ref int outBegIdx,
            ref int outNBElement,
            double[] outRealUpperBand,
            double[] outRealMiddleBand,
            double[] outRealLowerBand)
        {
            int i;
            double tempReal2;
            double tempReal;
            double[] tempBuffer2;
            double[] tempBuffer1;
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

            if (optInTimePeriod is < 2 or > 100000)
            {
                return RetCode.BadParam;
            }

            if (optInNbDevUp is < -3E+37 or > 3E+37)
            {
                return RetCode.BadParam;
            }

            if (optInNbDevDn is < -3E+37 or > 3E+37)
            {
                return RetCode.BadParam;
            }

            if (outRealUpperBand == null)
            {
                return RetCode.BadParam;
            }

            if (outRealMiddleBand == null)
            {
                return RetCode.BadParam;
            }

            if (outRealLowerBand == null)
            {
                return RetCode.BadParam;
            }

            if (inReal == outRealUpperBand)
            {
                tempBuffer1 = outRealMiddleBand;
                tempBuffer2 = outRealLowerBand;
            }
            else if (inReal == outRealLowerBand)
            {
                tempBuffer1 = outRealMiddleBand;
                tempBuffer2 = outRealUpperBand;
            }
            else if (inReal == outRealMiddleBand)
            {
                tempBuffer1 = outRealLowerBand;
                tempBuffer2 = outRealUpperBand;
            }
            else
            {
                tempBuffer1 = outRealMiddleBand;
                tempBuffer2 = outRealUpperBand;
            }

            if (tempBuffer1 == inReal || tempBuffer2 == inReal)
            {
                return RetCode.BadParam;
            }

            RetCode retCode = MovingAverage(
                startIdx,
                endIdx,
                inReal,
                optInTimePeriod,
                optInMAType,
                ref outBegIdx,
                ref outNBElement,
                tempBuffer1);
            if (retCode != RetCode.Success || outNBElement == 0)
            {
                outNBElement = 0;
                return retCode;
            }

            if (optInMAType == MAType.Sma)
            {
                TA_INT_stddev_using_precalc_ma(
                    inReal,
                    tempBuffer1,
                    outBegIdx,
                    outNBElement,
                    optInTimePeriod,
                    tempBuffer2);
            }
            else
            {
                retCode = StdDev(
                    outBegIdx,
                    endIdx,
                    inReal,
                    optInTimePeriod,
                    1.0,
                    ref outBegIdx,
                    ref outNBElement,
                    tempBuffer2);
                if (retCode != RetCode.Success)
                {
                    outNBElement = 0;
                    return retCode;
                }
            }

            if (tempBuffer1 != outRealMiddleBand)
            {
                Array.Copy(tempBuffer1, 0, outRealMiddleBand, 0, outNBElement);
            }

            if (optInNbDevUp != optInNbDevDn)
            {
                if (optInNbDevUp != 1.0)
                {
                    if (optInNbDevDn != 1.0)
                    {
                        i = 0;
                        while (i < outNBElement)
                        {
                            tempReal = tempBuffer2[i];
                            tempReal2 = outRealMiddleBand[i];
                            outRealUpperBand[i] = tempReal2 + tempReal * optInNbDevUp;
                            outRealLowerBand[i] = tempReal2 - tempReal * optInNbDevDn;
                            i++;
                        }

                        goto Label_02B1;
                    }

                    i = 0;
                    goto Label_025E;
                }

                i = 0;
            }
            else
            {
                if (optInNbDevUp != 1.0)
                {
                    i = 0;
                }
                else
                {
                    i = 0;
                    while (i < outNBElement)
                    {
                        tempReal = tempBuffer2[i];
                        tempReal2 = outRealMiddleBand[i];
                        outRealUpperBand[i] = tempReal2 + tempReal;
                        outRealLowerBand[i] = tempReal2 - tempReal;
                        i++;
                    }

                    goto Label_02B1;
                }

                while (i < outNBElement)
                {
                    tempReal = tempBuffer2[i] * optInNbDevUp;
                    tempReal2 = outRealMiddleBand[i];
                    outRealUpperBand[i] = tempReal2 + tempReal;
                    outRealLowerBand[i] = tempReal2 - tempReal;
                    i++;
                }

                goto Label_02B1;
            }

            while (true)
            {
                if (i >= outNBElement)
                {
                    goto Label_02B1;
                }

                tempReal = tempBuffer2[i];
                tempReal2 = outRealMiddleBand[i];
                outRealUpperBand[i] = tempReal2 + tempReal;
                outRealLowerBand[i] = tempReal2 - tempReal * optInNbDevDn;
                i++;
            }

            Label_025E:
            while (i < outNBElement)
            {
                tempReal = tempBuffer2[i];
                tempReal2 = outRealMiddleBand[i];
                outRealLowerBand[i] = tempReal2 - tempReal;
                outRealUpperBand[i] = tempReal2 + tempReal * optInNbDevUp;
                i++;
            }

            Label_02B1:
            return RetCode.Success;
        }

        public static int BollingerBandsLookback(
            int optInTimePeriod,
            double optInNbDevUp,
            double optInNbDevDn,
            MAType optInMAType)
        {
            if (optInTimePeriod is < 2 or > 100000)
            {
                return -1;
            }

            if (optInNbDevUp is < -3E+37 or > 3E+37)
            {
                return -1;
            }

            if (optInNbDevDn is < -3E+37 or > 3E+37)
            {
                return -1;
            }

            return MovingAverageLookback(optInTimePeriod, optInMAType);
        }
    }
}
