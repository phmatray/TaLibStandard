using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RetCode MovingAverage(
            int startIdx,
            int endIdx,
            double[] inReal,
            int optInTimePeriod,
            MAType optInMAType,
            ref int outBegIdx,
            ref int outNBElement,
            double[] outReal)
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

            if (optInTimePeriod == -2147483648)
            {
                optInTimePeriod = 30;
            }
            else if (optInTimePeriod is < 1 or > 100000)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            if (optInTimePeriod != 1)
            {
                switch (optInMAType)
                {
                    case MAType.Sma:
                        return Sma(startIdx, endIdx, inReal, optInTimePeriod, ref outBegIdx, ref outNBElement, outReal);

                    case MAType.Ema:
                        return Ema(startIdx, endIdx, inReal, optInTimePeriod, ref outBegIdx, ref outNBElement, outReal);

                    case MAType.Wma:
                        return Wma(startIdx, endIdx, inReal, optInTimePeriod, ref outBegIdx, ref outNBElement, outReal);

                    case MAType.Dema:
                        return Dema(
                            startIdx,
                            endIdx,
                            inReal,
                            optInTimePeriod,
                            ref outBegIdx,
                            ref outNBElement,
                            outReal);

                    case MAType.Tema:
                        return Tema(
                            startIdx,
                            endIdx,
                            inReal,
                            optInTimePeriod,
                            ref outBegIdx,
                            ref outNBElement,
                            outReal);

                    case MAType.Trima:
                        return Trima(
                            startIdx,
                            endIdx,
                            inReal,
                            optInTimePeriod,
                            ref outBegIdx,
                            ref outNBElement,
                            outReal);

                    case MAType.Kama:
                        return Kama(
                            startIdx,
                            endIdx,
                            inReal,
                            optInTimePeriod,
                            ref outBegIdx,
                            ref outNBElement,
                            outReal);

                    case MAType.Mama:
                        {
                            double[] dummyBuffer = new double[endIdx - startIdx + 1];
                            if (dummyBuffer != null)
                            {
                                return Mama(
                                    startIdx,
                                    endIdx,
                                    inReal,
                                    0.5,
                                    0.05,
                                    ref outBegIdx,
                                    ref outNBElement,
                                    outReal,
                                    dummyBuffer);
                            }

                            return RetCode.AllocErr;
                        }

                    case MAType.T3:
                        return T3(
                            startIdx,
                            endIdx,
                            inReal,
                            optInTimePeriod,
                            0.7,
                            ref outBegIdx,
                            ref outNBElement,
                            outReal);
                }

                return RetCode.BadParam;
            }

            int nbElement = endIdx - startIdx + 1;
            outNBElement = nbElement;
            int todayIdx = startIdx;
            int outIdx = 0;
            while (outIdx < nbElement)
            {
                outReal[outIdx] = inReal[todayIdx];
                outIdx++;
                todayIdx++;
            }

            outBegIdx = startIdx;
            return RetCode.Success;
        }

        public static int MovingAverageLookback(int optInTimePeriod, MAType optInMAType)
        {
            if (optInTimePeriod == -2147483648)
            {
                optInTimePeriod = 30;
            }
            else if (optInTimePeriod is < 1 or > 100000)
            {
                return -1;
            }

            if (optInTimePeriod > 1)
            {
                return optInMAType switch
                {
                    MAType.Sma => SmaLookback(optInTimePeriod),
                    MAType.Ema => EmaLookback(optInTimePeriod),
                    MAType.Wma => WmaLookback(optInTimePeriod),
                    MAType.Dema => DemaLookback(optInTimePeriod),
                    MAType.Tema => TemaLookback(optInTimePeriod),
                    MAType.Trima => TrimaLookback(optInTimePeriod),
                    MAType.Kama => KamaLookback(optInTimePeriod),
                    MAType.Mama => MamaLookback(0.5, 0.05),
                    MAType.T3 => T3Lookback(optInTimePeriod, 0.7),
                    _ => throw new ArgumentOutOfRangeException(nameof(optInMAType), optInMAType, null)
                };
            }

            return 0;
        }
    }
}
