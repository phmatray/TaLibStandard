// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the MidPrice indicator.
/// </summary>
/// <remarks>
/// The MidPrice indicator calculates the midpoint between the high and low prices
/// over a specified period. Unlike MidPoint which can work with any data series,
/// MidPrice specifically uses high and low price data to find the center of the trading range.
/// </remarks>
public record MidPriceResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MidPriceResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of midprice values calculated as (period high + period low) / 2.</param>
    public MidPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of midprice values.
    /// </summary>
    /// <remarks>
    /// Each value represents the midpoint of the high-low range over the lookback period,
    /// calculated as (period high + period low) / 2. This provides a smoothed representation
    /// of the price center and can be used to identify trend direction and support/resistance levels.
    /// </remarks>
    public double[] Real { get; }
}
