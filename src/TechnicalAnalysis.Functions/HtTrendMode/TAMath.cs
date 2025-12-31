// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Functions.Internal;

namespace TechnicalAnalysis.Functions;

public static partial class TAMath
{
    /// <summary>
    /// Calculates the Hilbert Transform - Trend vs Cycle Mode for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtTrendModeResult containing integer values indicating market mode.</returns>
    /// <remarks>
    /// The Hilbert Transform - Trend vs Cycle Mode indicator determines whether the 
    /// market is in a trending or cycling mode. It returns integer values where:
    /// 0 indicates a cycling (ranging) market, and 1 indicates a trending market.
    /// This helps traders choose appropriate strategies - trend-following strategies 
    /// work better in trending markets, while oscillators work better in cycling markets.
    /// </remarks>
    public static HtTrendModeResult HtTrendMode(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        int[] outInteger = new int[endIdx - startIdx + 1];

        RetCode retCode = TAFunc.HtTrendMode(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outInteger);
            
        return new HtTrendModeResult(retCode, outBegIdx, outNBElement, outInteger);
    }

    /// <summary>
    /// Calculates the Hilbert Transform - Trend vs Cycle Mode for the input price data.
    /// </summary>
    /// <param name="startIdx">The starting index for the calculation range.</param>
    /// <param name="endIdx">The ending index for the calculation range.</param>
    /// <param name="real">The input price data.</param>
    /// <returns>An HtTrendModeResult containing integer values indicating market mode.</returns>
    /// <remarks>
    /// This overload accepts float input and converts it to double for calculation.
    /// </remarks>
    public static HtTrendModeResult HtTrendMode(int startIdx, int endIdx, float[] real)
        => TAMathHelper.Execute(startIdx, endIdx, real, HtTrendMode);
}
