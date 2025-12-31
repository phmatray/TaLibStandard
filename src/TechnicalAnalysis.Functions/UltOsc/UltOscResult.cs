// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the Ultimate Oscillator (UltOsc) indicator.
/// </summary>
/// <remarks>
/// The Ultimate Oscillator is a momentum oscillator designed to capture momentum across three different timeframes.
/// It combines short-term (7 periods), intermediate-term (14 periods), and long-term (28 periods) market cycles
/// to reduce false signals and provide more reliable overbought/oversold readings.
/// </remarks>
public record UltOscResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UltOscResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array of Ultimate Oscillator values ranging from 0 to 100.</param>
    public UltOscResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
