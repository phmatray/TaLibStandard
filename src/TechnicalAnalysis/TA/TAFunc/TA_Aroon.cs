namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Aroon(
            int startIdx,
            int endIdx,
            double[] inHigh,
            double[] inLow,
            int optInTimePeriod,
            ref int outBegIdx,
            ref int outNBElement,
            double[] outAroonDown,
            double[] outAroonUp)
        {
            int i;
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inHigh == null || inLow == null)
            {
                return RetCode.BadParam;
            }

            if (optInTimePeriod == -2147483648)
            {
                optInTimePeriod = 14;
            }
            else if (optInTimePeriod is < 2 or > 0x186a0)
            {
                return RetCode.BadParam;
            }

            if (outAroonDown == null)
            {
                return RetCode.BadParam;
            }

            if (outAroonUp == null)
            {
                return RetCode.BadParam;
            }

            if (startIdx < optInTimePeriod)
            {
                startIdx = optInTimePeriod;
            }

            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            int outIdx = 0;
            int today = startIdx;
            int trailingIdx = startIdx - optInTimePeriod;
            int lowestIdx = -1;
            int highestIdx = -1;
            double lowest = 0.0;
            double highest = 0.0;
            double factor = 100.0 / optInTimePeriod;
            Label_00BB:
            if (today > endIdx)
            {
                outBegIdx = startIdx;
                outNBElement = outIdx;
                return RetCode.Success;
            }

            double tmp = inLow[today];
            if (lowestIdx < trailingIdx)
            {
                lowestIdx = trailingIdx;
                lowest = inLow[lowestIdx];
                i = lowestIdx;
                while (true)
                {
                    i++;
                    if (i > today)
                    {
                        goto Label_00FF;
                    }

                    tmp = inLow[i];
                    if (tmp <= lowest)
                    {
                        lowestIdx = i;
                        lowest = tmp;
                    }
                }
            }

            if (tmp <= lowest)
            {
                lowestIdx = today;
                lowest = tmp;
            }

            Label_00FF:
            tmp = inHigh[today];
            if (highestIdx < trailingIdx)
            {
                highestIdx = trailingIdx;
                highest = inHigh[highestIdx];
                i = highestIdx;
                while (true)
                {
                    i++;
                    if (i > today)
                    {
                        goto Label_0136;
                    }

                    tmp = inHigh[i];
                    if (tmp >= highest)
                    {
                        highestIdx = i;
                        highest = tmp;
                    }
                }
            }

            if (tmp >= highest)
            {
                highestIdx = today;
                highest = tmp;
            }

            Label_0136:
            outAroonUp[outIdx] = factor * (optInTimePeriod - (today - highestIdx));
            outAroonDown[outIdx] = factor * (optInTimePeriod - (today - lowestIdx));
            outIdx++;
            trailingIdx++;
            today++;
            goto Label_00BB;
        }

        public static int AroonLookback(int optInTimePeriod)
        {
            if (optInTimePeriod == -2147483648)
            {
                optInTimePeriod = 14;
            }
            else if (optInTimePeriod is < 2 or > 0x186a0)
            {
                return -1;
            }

            return optInTimePeriod;
        }
    }
}
