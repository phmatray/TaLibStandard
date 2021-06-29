namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode Obv(
            int startIdx,
            int endIdx,
            in double[] inReal,
            in double[] inVolume,
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

            if (inVolume == null)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            double prevOBV = inVolume[startIdx];
            double prevReal = inReal[startIdx];
            int outIdx = 0;
            for (int i = startIdx; i <= endIdx; i++)
            {
                double tempReal = inReal[i];
                if (tempReal > prevReal)
                {
                    prevOBV += inVolume[i];
                }
                else if (tempReal < prevReal)
                {
                    prevOBV -= inVolume[i];
                }

                outReal[outIdx] = prevOBV;
                outIdx++;
                prevReal = tempReal;
            }

            outBegIdx = startIdx;
            outNBElement = outIdx;
            return RetCode.Success;
        }

        public static int ObvLookback()
        {
            return 0;
        }
    }
}
