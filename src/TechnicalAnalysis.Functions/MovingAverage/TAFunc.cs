// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    public static RetCode MovingAverage(
        int startIdx,
        int endIdx,
        in double[] inReal,
        in int optInTimePeriod,
        in MAType optInMAType,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outReal)
    {
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod is < 1 or > 100000)
        {
            return BadParam;
        }

        if (outReal == null!)
        {
            return BadParam;
        }

        if (optInTimePeriod != 1)
        {
            switch (optInMAType)
            {
                case MAType.Sma:
                    return Sma(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Ema:
                    return Ema(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Wma:
                    return Wma(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Dema:
                    return Dema(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Tema:
                    return Tema(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Trima:
                    return Trima(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Kama:
                    return Kama(
                        startIdx,
                        endIdx,
                        inReal,
                        optInTimePeriod,
                        ref outBegIdx,
                        ref outNBElement,
                        ref outReal);

                case MAType.Mama:
                    {
                        double[] dummyBuffer = new double[endIdx - startIdx + 1];
                            
                        return Mama(
                            startIdx,
                            endIdx,
                            inReal,
                            0.5,
                            0.05,
                            ref outBegIdx,
                            ref outNBElement,
                            ref outReal,
                            ref dummyBuffer);
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
                        ref outReal);
            }

            return BadParam;
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
        return Success;
    }

    public static int MovingAverageLookback(int optInTimePeriod, MAType optInMAType)
    {
        return optInTimePeriod is < 1 or > 100000
            ? -1
            : optInTimePeriod > 1
                ? optInMAType switch
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
                }
                : 0;
    }
}
