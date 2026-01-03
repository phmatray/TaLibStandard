// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Hilbert Transform - Instantaneous Trendline for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtTrendlineResult containing the calculated trendline values.</returns>
    /// <remarks>
    /// The Hilbert Transform - Instantaneous Trendline removes the dominant cycle 
    /// component from the price data, leaving only the trend component. This creates 
    /// a smooth trendline that adapts to market conditions with minimal lag. It's 
    /// particularly useful for identifying the underlying trend direction while 
    /// filtering out cyclic price movements.
    /// </remarks>
    public static HtTrendlineResult HtTrendline(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.HtTrendline(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new HtTrendlineResult(retCode, outBegIdx, outNBElement, outReal);
    }

    /// <summary>
    /// Calculates the Hilbert Transform - Instantaneous Trendline for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtTrendlineResult containing the calculated trendline values.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static HtTrendlineResult HtTrendline(int startIdx, int endIdx, float[] real)
        => HtTrendline(startIdx, endIdx, real.ToDouble());
}
