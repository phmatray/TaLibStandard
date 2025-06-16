// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAFunc
{
    /// <summary>
    /// Calculates the ZigZag indicator - filters out price movements smaller than a specified threshold.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation within the input arrays.</param>
    /// <param name="endIdx">The ending index for the calculation within the input arrays.</param>
    /// <param name="inHigh">Input array of high prices.</param>
    /// <param name="inLow">Input array of low prices.</param>
    /// <param name="optInDeviation">Minimum percentage price movement required for a reversal (0.0 to 100.0). Typical value: 5.0.</param>
    /// <param name="outBegIdx">The index of the first valid output value.</param>
    /// <param name="outNBElement">The number of valid output elements.</param>
    /// <param name="outZigZag">Output array containing the ZigZag values (0.0 for non-pivot points).</param>
    /// <returns>A RetCode indicating the success or failure of the calculation.</returns>
    /// <remarks>
    /// The ZigZag indicator:
    /// - Identifies significant price reversals by filtering out minor price movements
    /// - Connects swing highs and swing lows with straight lines
    /// - A reversal is confirmed when price moves by at least the specified deviation percentage
    /// - Non-pivot points in the output array are set to 0.0
    /// - Only pivot points (peaks and troughs) contain actual price values
    /// 
    /// Interpretation:
    /// - Useful for identifying support/resistance levels and chart patterns
    /// - Helps visualize the overall price trend by removing noise
    /// - The deviation parameter controls sensitivity (higher values = fewer reversals)
    /// - Note: This is a lagging indicator that repaints past values
    /// - Should not be used alone for trading signals due to its retrospective nature
    /// </remarks>
    public static RetCode ZigZag(
        int startIdx,
        int endIdx,
        in double[] inHigh,
        in double[] inLow,
        in double optInDeviation,
        ref int outBegIdx,
        ref int outNBElement,
        ref double[] outZigZag)
    {
        // Validate parameters
        if (startIdx < 0)
        {
            return OutOfRangeStartIndex;
        }

        if (endIdx < 0 || endIdx < startIdx)
        {
            return OutOfRangeEndIndex;
        }

        if (inHigh == null! || inLow == null!)
        {
            return BadParam;
        }

        if (optInDeviation is < 0.0 or > 100.0)
        {
            return BadParam;
        }

        if (outZigZag == null!)
        {
            return BadParam;
        }

        // ZigZag needs at least 2 data points
        int lookback = ZigZagLookback(optInDeviation);
        if (lookback < 0)
        {
            return BadParam;
        }
        
        if (startIdx < lookback)
        {
            startIdx = lookback;
        }

        if (startIdx > endIdx)
        {
            outBegIdx = 0;
            outNBElement = 0;
            return Success;
        }

        // Initialize
        outBegIdx = startIdx;
        
        // Convert percentage to decimal
        double deviationPercent = optInDeviation / 100.0;
        
        // Initialize first point
        double lastPeak = inHigh[0];
        double lastTrough = inLow[0];
        int lastPeakIdx = 0;
        int lastTroughIdx = 0;
        
        // Determine initial trend direction
        bool isUptrend = !(inHigh[startIdx] < lastPeak && inLow[startIdx] < lastTrough);
        
        // Clear output array
        for (int i = 0; i <= endIdx - startIdx; i++)
        {
            outZigZag[i] = 0.0;
        }
        
        // Set initial point
        outZigZag[0] = isUptrend ? lastTrough : lastPeak;

        // Main loop
        for (int i = startIdx; i <= endIdx; i++)
        {
            double currentHigh = inHigh[i];
            double currentLow = inLow[i];
            
            if (isUptrend)
            {
                // In uptrend, look for new highs
                if (currentHigh > lastPeak)
                {
                    lastPeak = currentHigh;
                    lastPeakIdx = i;
                }
                
                // Check for trend reversal
                double retracement = (lastPeak - currentLow) / lastPeak;
                if (retracement >= deviationPercent)
                {
                    // Trend reversal confirmed
                    if (lastPeakIdx - startIdx >= 0 && lastPeakIdx - startIdx < outZigZag.Length)
                    {
                        outZigZag[lastPeakIdx - startIdx] = lastPeak;
                    }
                    
                    lastTrough = currentLow;
                    lastTroughIdx = i;
                    isUptrend = false;
                }
            }
            else
            {
                // In downtrend, look for new lows
                if (currentLow < lastTrough)
                {
                    lastTrough = currentLow;
                    lastTroughIdx = i;
                }
                
                // Check for trend reversal
                double rally = (currentHigh - lastTrough) / lastTrough;
                if (rally >= deviationPercent)
                {
                    // Trend reversal confirmed
                    if (lastTroughIdx - startIdx >= 0 && lastTroughIdx - startIdx < outZigZag.Length)
                    {
                        outZigZag[lastTroughIdx - startIdx] = lastTrough;
                    }
                    
                    lastPeak = currentHigh;
                    lastPeakIdx = i;
                    isUptrend = true;
                }
            }
        }
        
        // Set final point
        int finalIdx = endIdx - startIdx;
        if (finalIdx >= 0 && finalIdx < outZigZag.Length)
        {
            outZigZag[finalIdx] = isUptrend
                ? lastPeakIdx == endIdx
                    ? lastPeak
                    : inLow[endIdx]
                : lastTroughIdx == endIdx
                    ? lastTrough
                    : inHigh[endIdx];
        }
        
        outNBElement = endIdx - startIdx + 1;
        return Success;
    }

    /// <summary>
    /// Calculates the lookback period for the ZigZag indicator.
    /// </summary>
    /// <param name="optInDeviation">Minimum percentage price movement required for a reversal (0.0 to 100.0).</param>
    /// <returns>The number of historical data points needed before the first ZigZag value can be calculated, or -1 if the deviation is invalid.</returns>
    /// <remarks>
    /// The ZigZag indicator requires at least 1 prior bar to establish an initial reference point
    /// for determining subsequent peaks and troughs.
    /// </remarks>
    public static int ZigZagLookback(double optInDeviation)
    {
        // ZigZag deviation parameter validation
        if (optInDeviation is < 0.0 or > 100.0)
        {
            return -1;
        }
        
        // ZigZag needs at least 1 prior bar to establish initial point
        return 1;
    }
}
