// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Hilbert Transform - Trend vs Cycle Mode (HT_TRENDMODE) calculation.
/// This indicator determines whether the market is in a trending or cycling mode using Hilbert Transform analysis,
/// helping traders choose appropriate strategies for different market conditions.
/// </summary>
public record HtTrendModeResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HtTrendModeResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="integers">The array of trend mode values indicating market state (0 = cycle mode, 1 = trend mode).</param>
    public HtTrendModeResult(RetCode retCode, int begIdx, int nbElement, int[] integers)
        : base(retCode, begIdx, nbElement)
    {
        Integers = integers;
    }

    /// <summary>
    /// Gets the array of trend mode indicator values.
    /// Each value is either 0 (indicating cycle/ranging mode) or 1 (indicating trending mode).
    /// This binary output helps determine which trading strategies are most appropriate for current market conditions.
    /// </summary>
    public int[] Integers { get; }
}
