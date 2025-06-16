// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the Beta coefficient - a measure of a security's volatility relative to a benchmark.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inReal0">Input array of security prices (the asset being analyzed).</param>
    /// <param name="inReal1">Input array of benchmark prices (typically market index).</param>
    /// <param name="optInTimePeriod">Number of periods for the Beta calculation. Typical value: 20.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outReal">Output array for the Beta values.</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// Beta measures the systematic risk of a security relative to the overall market.
    /// It's calculated using linear regression of security returns against market returns.
    /// 
    /// Calculation:
    /// Beta = Covariance(Security Returns, Market Returns) / Variance(Market Returns)
    /// 
    /// Interpretation:
    /// - Beta = 1.0: Security moves with the market
    /// - Beta &gt; 1.0: Security is more volatile than the market
    /// - Beta &lt; 1.0: Security is less volatile than the market
    /// - Beta &lt; 0: Security moves opposite to the market
    /// 
    /// Uses:
    /// - Portfolio risk assessment
    /// - CAPM (Capital Asset Pricing Model) calculations
    /// - Hedging strategies
    /// - Performance attribution
    /// 
    /// Note: This implementation uses percentage returns for calculations.
    /// </remarks>
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
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inReal0 == null!)
        {
            return BadParam;
        }

        if (inReal1 == null!)
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

        int nbInitialElementNeeded = optInTimePeriod;
        if (startIdx < nbInitialElementNeeded)
        {
            startIdx = nbInitialElementNeeded;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        int trailingIdx = startIdx - nbInitialElementNeeded;
        double trailingLastPriceX = inReal0[trailingIdx];
        double lastPriceX = trailingLastPriceX;
        double trailingLastPriceY = inReal1[trailingIdx];
        double lastPriceY = trailingLastPriceY;
        trailingIdx++;
        int i = trailingIdx;
        double tmpReal;
        while (true)
        {
            if (i >= startIdx)
            {
                break;
            }

            tmpReal = inReal0[i];
            x = (tmpReal - lastPriceX) / lastPriceX;

            lastPriceX = tmpReal;
            tmpReal = inReal1[i];
            i++;
            y = (tmpReal - lastPriceY) / lastPriceY;

            lastPriceY = tmpReal;
            sXX += x * x;
            sXY += x * y;
            sX += x;
            sY += y;
        }

        int outIdx = 0;
        double n = optInTimePeriod;
        do
        {
            tmpReal = inReal0[i];
            x = (tmpReal - lastPriceX) / lastPriceX;

            lastPriceX = tmpReal;
            tmpReal = inReal1[i];
            i++;
            y = (tmpReal - lastPriceY) / lastPriceY;

            lastPriceY = tmpReal;
            sXX += x * x;
            sXY += x * y;
            sX += x;
            sY += y;
            tmpReal = inReal0[trailingIdx];
            x = (tmpReal - trailingLastPriceX) / trailingLastPriceX;

            trailingLastPriceX = tmpReal;
            tmpReal = inReal1[trailingIdx];
            trailingIdx++;
            y = (tmpReal - trailingLastPriceY) / trailingLastPriceY;

            trailingLastPriceY = tmpReal;
            tmpReal = (n * sXX) - (sX * sX);
            outReal[outIdx] = ((n * sXY) - (sX * sY)) / tmpReal;
            outIdx++;

            sXX -= x * x;
            sXY -= x * y;
            sX -= x;
            sY -= y;
        }
        while (i <= endIdx);

        outNBElement = outIdx;
        outBegIdx = startIdx;
        return Success;
    }

    /// <summary>
    /// Returns the lookback period required for Beta calculation.
    /// </summary>
    /// <param name="optInTimePeriod">Number of periods for the Beta calculation. Valid range: 1 to 100000.</param>
    /// <returns>The number of historical data points required before the first valid Beta value can be calculated, or -1 if parameters are invalid.</returns>
    public static int BetaLookback(int optInTimePeriod)
    {
        return optInTimePeriod is < 1 or > 100000 ? -1 : optInTimePeriod;
    }
}
