using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode StdDev(
            int startIdx,
            int endIdx,
            in double[] inReal,
            in int optInTimePeriod,
            in double optInNbDev,
            ref int outBegIdx,
            ref int outNBElement,
            ref double[] outReal)
        {
            int i;
            double tempReal;
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

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            RetCode retCode = TA_INT_VAR(
                startIdx,
                endIdx,
                inReal,
                optInTimePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            if (retCode != RetCode.Success)
            {
                return retCode;
            }

            if (optInNbDev == 1.0)
            {
                i = 0;
                while (i < outNBElement)
                {
                    tempReal = outReal[i];
                    if (tempReal >= 1E-08)
                    {
                        outReal[i] = Math.Sqrt(tempReal);
                    }
                    else
                    {
                        outReal[i] = 0.0;
                    }

                    i++;
                }
            }
            else
            {
                for (i = 0; i < outNBElement; i++)
                {
                    tempReal = outReal[i];
                    if (tempReal >= 1E-08)
                    {
                        outReal[i] = Math.Sqrt(tempReal) * optInNbDev;
                    }
                    else
                    {
                        outReal[i] = 0.0;
                    }
                }
            }

            return RetCode.Success;
        }

        public static int StdDevLookback(int optInTimePeriod, double optInNbDev)
        {
            if (optInTimePeriod is < 2 or > 100000)
            {
                return -1;
            }

            return VarianceLookback(optInTimePeriod, optInNbDev);
        }
    }
}
