// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the On Balance Volume (OBV) indicator.
    /// </summary>
    /// <remarks>
    /// On Balance Volume (OBV) is a momentum indicator that uses volume flow to predict changes in stock price.
    /// Joseph Granville first developed the OBV metric in the 1963 book "Granville's New Key to Stock Market Profits".
    /// 
    /// The OBV is calculated by adding volume on up days and subtracting volume on down days. The theory is that 
    /// volume precedes price movement, so if a security is seeing an increasing OBV, it is a signal that volume is 
    /// increasing on upward price moves. This is interpreted as a bullish signal. Conversely, if OBV is decreasing 
    /// while prices are rising, it may indicate that the trend is not sustainable.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of prices (typically closing prices).</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An ObvResult object containing the calculated OBV values.</returns>
    public static ObvResult Obv(int startIdx, int endIdx, double[] real, double[] volume)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.Obv(startIdx, endIdx, real, volume, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new ObvResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the On Balance Volume (OBV) indicator using float arrays.
    /// </summary>
    /// <remarks>
    /// This is a float overload that converts input arrays to double arrays before processing.
    /// See the double array overload for a detailed description of the OBV indicator.
    /// </remarks>
    /// <param name="startIdx">The starting index for the calculation.</param>
    /// <param name="endIdx">The ending index for the calculation.</param>
    /// <param name="real">Array of prices (typically closing prices).</param>
    /// <param name="volume">Array of trading volumes.</param>
    /// <returns>An ObvResult object containing the calculated OBV values.</returns>
    public static ObvResult Obv(int startIdx, int endIdx, float[] real, float[] volume)
        => Obv(startIdx, endIdx, real.ToDouble(), volume.ToDouble());
}
