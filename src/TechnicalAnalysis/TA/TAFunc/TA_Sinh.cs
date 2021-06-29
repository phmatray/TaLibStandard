using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Sinh(
            int startIdx,
            int endIdx,
            in double[] inReal,
            ref int outBegIdx,
            ref int outNBElement,
            ref double[] outReal)
        {
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

            int i = startIdx;
            int outIdx = 0;
            while (i <= endIdx)
            {
                outReal[outIdx] = Math.Sinh(inReal[i]);
                i++;
                outIdx++;
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int SinhLookback()
        {
            return 0;
        }
    }
}
