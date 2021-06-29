namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Bop(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
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

            if (inOpen == null || inHigh == null || inLow == null || inClose == null)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            int outIdx = 0;
            for (int i = startIdx; i <= endIdx; i++)
            {
                double tempReal = inHigh[i] - inLow[i];
                if (tempReal < 1E-08)
                {
                    outReal[outIdx] = 0.0;
                    outIdx++;
                }
                else
                {
                    outReal[outIdx] = (inClose[i] - inOpen[i]) / tempReal;
                    outIdx++;
                }
            }

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int BopLookback()
        {
            return 0;
        }
    }
}
