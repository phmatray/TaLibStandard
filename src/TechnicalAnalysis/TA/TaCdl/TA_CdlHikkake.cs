namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode CdlHikkake(
            int startIdx,
            int endIdx,
            in double[] inOpen,
            in double[] inHigh,
            in double[] inLow,
            in double[] inClose,
            ref int outBegIdx,
            ref int outNBElement,
            ref int[] outInteger)
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

            if (outInteger == null)
            {
                return RetCode.BadParam;
            }

            int lookbackTotal = CdlHikkakeLookback();
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

            int patternIdx = 0;
            int pattern = 0;
            int i = startIdx - 3;
            while (true)
            {
                if (i >= startIdx)
                {
                    break;
                }

                if (inHigh[i - 1] < inHigh[i - 2] && inLow[i - 1] > inLow[i - 2]
                                                  && (inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1]
                                                      || inHigh[i] > inHigh[i - 1] && inLow[i] > inLow[i - 1]))
                {
                    pattern = (inHigh[i] >= inHigh[i - 1] ? -1 : 1) * 100;
                    patternIdx = i;
                }
                else if (i <= patternIdx + 3 && (pattern > 0 && inClose[i] > inHigh[patternIdx - 1]
                                                 || pattern < 0 && inClose[i] < inLow[patternIdx - 1]))
                {
                    patternIdx = 0;
                }

                i++;
            }

            i = startIdx;
            int outIdx = 0;
            do
            {
                if (inHigh[i - 1] < inHigh[i - 2] && inLow[i - 1] > inLow[i - 2]
                                                  && (inHigh[i] < inHigh[i - 1] && inLow[i] < inLow[i - 1]
                                                      || inHigh[i] > inHigh[i - 1] && inLow[i] > inLow[i - 1]))
                {
                    pattern = (inHigh[i] >= inHigh[i - 1] ? -1 : 1) * 100;
                    patternIdx = i;
                    outInteger[outIdx] = pattern;
                    outIdx++;
                }
                else if (i <= patternIdx + 3 && (pattern > 0 && inClose[i] > inHigh[patternIdx - 1]
                                                 || pattern < 0 && inClose[i] < inLow[patternIdx - 1]))
                {
                    int num;
                    if (pattern > 0)
                    {
                        num = 1;
                    }
                    else
                    {
                        num = -1;
                    }

                    outInteger[outIdx] = pattern + num * 100;
                    outIdx++;
                    patternIdx = 0;
                }
                else
                {
                    outInteger[outIdx] = 0;
                    outIdx++;
                }

                i++;
            }
            while (i <= endIdx);

            outNBElement = outIdx;
            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int CdlHikkakeLookback()
        {
            return 5;
        }
    }
}
