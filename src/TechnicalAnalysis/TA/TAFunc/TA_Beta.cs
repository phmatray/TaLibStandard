namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Beta(
            int startIdx,
            int endIdx,
            in double[] inReal0,
            in double[] inReal1,
            in int optInTimePeriod,
            ref int outBegIdx,
            ref int outNBElement,
            ref double[] outReal)
        {
            double x;
            double y;
            double sXX = 0.0;
            double sXY = 0.0;
            double sX = 0.0;
            double sY = 0.0;
            double lastPriceX = 0.0;
            double lastPriceY = 0.0;
            double trailingLastPriceX = 0.0;
            double trailingLastPriceY = 0.0;
            double tmpReal = 0.0;
            double n = 0.0;
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inReal0 == null)
            {
                return RetCode.BadParam;
            }

            if (inReal1 == null)
            {
                return RetCode.BadParam;
            }

            if (optInTimePeriod is < 1 or > 100000)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            int nbInitialElementNeeded = optInTimePeriod;
            if (startIdx < nbInitialElementNeeded)
            {
                startIdx = nbInitialElementNeeded;
            }

            if (startIdx > endIdx)
            {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }

            int trailingIdx = startIdx - nbInitialElementNeeded;
            trailingLastPriceX = inReal0[trailingIdx];
            lastPriceX = trailingLastPriceX;
            trailingLastPriceY = inReal1[trailingIdx];
            lastPriceY = trailingLastPriceY;
            trailingIdx++;
            int i = trailingIdx;
            while (true)
            {
                if (i >= startIdx)
                {
                    break;
                }

                tmpReal = inReal0[i];
                if (lastPriceX is >= -1E-08 or >= 1E-08)
                {
                    x = (tmpReal - lastPriceX) / lastPriceX;
                }
                else
                {
                    x = 0.0;
                }

                lastPriceX = tmpReal;
                tmpReal = inReal1[i];
                i++;
                if (lastPriceY is >= -1E-08 or >= 1E-08)
                {
                    y = (tmpReal - lastPriceY) / lastPriceY;
                }
                else
                {
                    y = 0.0;
                }

                lastPriceY = tmpReal;
                sXX += x * x;
                sXY += x * y;
                sX += x;
                sY += y;
            }

            int outIdx = 0;
            n = optInTimePeriod;
            do
            {
                tmpReal = inReal0[i];
                if (lastPriceX is >= -1E-08 or >= 1E-08)
                {
                    x = (tmpReal - lastPriceX) / lastPriceX;
                }
                else
                {
                    x = 0.0;
                }

                lastPriceX = tmpReal;
                tmpReal = inReal1[i];
                i++;
                if (lastPriceY is >= -1E-08 or >= 1E-08)
                {
                    y = (tmpReal - lastPriceY) / lastPriceY;
                }
                else
                {
                    y = 0.0;
                }

                lastPriceY = tmpReal;
                sXX += x * x;
                sXY += x * y;
                sX += x;
                sY += y;
                tmpReal = inReal0[trailingIdx];
                if (trailingLastPriceX is >= -1E-08 or >= 1E-08)
                {
                    x = (tmpReal - trailingLastPriceX) / trailingLastPriceX;
                }
                else
                {
                    x = 0.0;
                }

                trailingLastPriceX = tmpReal;
                tmpReal = inReal1[trailingIdx];
                trailingIdx++;
                if (trailingLastPriceY is >= -1E-08 or >= 1E-08)
                {
                    y = (tmpReal - trailingLastPriceY) / trailingLastPriceY;
                }
                else
                {
                    y = 0.0;
                }

                trailingLastPriceY = tmpReal;
                tmpReal = n * sXX - sX * sX;
                if (tmpReal is >= -1E-08 or >= 1E-08)
                {
                    outReal[outIdx] = (n * sXY - sX * sY) / tmpReal;
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }

                sXX -= x * x;
                sXY -= x * y;
                sX -= x;
                sY -= y;
            }
            while (i <= endIdx);

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int BetaLookback(int optInTimePeriod)
        {
            if (optInTimePeriod is < 1 or > 100000)
            {
                return -1;
            }

            return optInTimePeriod;
        }
    }
}
