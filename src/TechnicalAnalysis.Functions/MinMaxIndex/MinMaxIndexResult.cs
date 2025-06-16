// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the indices of minimum and maximum values over a specified period.
/// </summary>
/// <remarks>
/// The MinMaxIndex function identifies the array indices where the minimum and maximum values
/// occur within a rolling window. This is useful for locating exact positions of peaks and troughs
/// in price data, which can be used for support/resistance analysis or pattern recognition.
/// </remarks>
public record MinMaxIndexResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MinMaxIndexResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="minIdx">The array of indices where minimum values occur within each period.</param>
    /// <param name="maxIdx">The array of indices where maximum values occur within each period.</param>
    public MinMaxIndexResult(RetCode retCode, int begIdx, int nbElement, int[] minIdx, int[] maxIdx)
        : base(retCode, begIdx, nbElement)
    {
        MinIdx = minIdx;
        MaxIdx = maxIdx;
    }

    /// <summary>
    /// Gets the array of indices where maximum values occur.
    /// </summary>
    /// <remarks>
    /// Each element contains the index position in the original data array where
    /// the maximum value was found within the specified lookback period.
    /// These indices can be used to identify the exact timing of peaks.
    /// </remarks>
    public int[] MaxIdx { get; }

    /// <summary>
    /// Gets the array of indices where minimum values occur.
    /// </summary>
    /// <remarks>
    /// Each element contains the index position in the original data array where
    /// the minimum value was found within the specified lookback period.
    /// These indices can be used to identify the exact timing of troughs.
    /// </remarks>
    public int[] MinIdx { get; }
}
