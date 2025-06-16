// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Chaikin Accumulation/Distribution Oscillator (A/D Oscillator) calculation.
/// </summary>
/// <remarks>
/// The Chaikin A/D Oscillator is a momentum indicator that measures the difference between 
/// fast and slow exponential moving averages of the Accumulation/Distribution Line. 
/// It helps identify changes in the momentum of accumulation or distribution, providing 
/// early signals of potential trend changes. Positive values indicate bullish momentum, 
/// while negative values indicate bearish momentum.
/// </remarks>
public record AdOscResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdOscResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated A/D Oscillator values.</param>
    public AdOscResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Chaikin A/D Oscillator values.
    /// </summary>
    /// <value>
    /// An array of doubles representing the oscillator values. Positive values suggest 
    /// increasing buying pressure (bullish momentum), negative values suggest increasing 
    /// selling pressure (bearish momentum), and crossovers through zero may indicate 
    /// potential trend changes.
    /// </value>
    public double[] Real { get; }
}
