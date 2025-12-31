// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Median Price calculation.
/// </summary>
/// <remarks>
/// The Median Price is a simple price transformation that calculates the midpoint between 
/// the high and low prices for each period. Also known as the High-Low Average, it represents 
/// the middle of the day's trading range and is often used as a simplified representation 
/// of price action. It is calculated as: (High + Low) / 2. This indicator is useful for 
/// identifying the central tendency of price movement within each period.
/// </remarks>
public record MedPriceResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MedPriceResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated median price values.</param>
    public MedPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
