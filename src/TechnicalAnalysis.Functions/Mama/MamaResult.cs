// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using TechnicalAnalysis.Common.Abstractions;

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of calculating the MESA Adaptive Moving Average (MAMA) indicator.
/// </summary>
/// <remarks>
/// MAMA is an adaptive moving average developed by John Ehlers that automatically adjusts
/// to price movement based on the rate of change of phase. It consists of two lines:
/// MAMA (the adaptive moving average) and FAMA (Following Adaptive Moving Average),
/// which work together to identify trends with minimal lag.
/// </remarks>
public record MamaResult : DualOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MamaResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output arrays.</param>
    /// <param name="nbElement">The number of valid data points in the output arrays.</param>
    /// <param name="mama">The array of MESA Adaptive Moving Average values.</param>
    /// <param name="fama">The array of Following Adaptive Moving Average values.</param>
    public MamaResult(RetCode retCode, int begIdx, int nbElement, double[] mama, double[] fama)
        : base(retCode, begIdx, nbElement, mama, fama)
    {
    }

    /// <summary>
    /// Gets the array of Following Adaptive Moving Average (FAMA) values.
    /// </summary>
    /// <remarks>
    /// FAMA is a slower-moving average that follows MAMA. The relationship between
    /// MAMA and FAMA can be used to generate trading signals:
    /// - When MAMA crosses above FAMA, it may signal a buy opportunity
    /// - When MAMA crosses below FAMA, it may signal a sell opportunity
    /// </remarks>
    public double[] FAMA => Real1;

    /// <summary>
    /// Gets the array of MESA Adaptive Moving Average (MAMA) values.
    /// </summary>
    /// <remarks>
    /// MAMA adapts quickly to price changes while maintaining smoothness.
    /// It automatically adjusts its smoothing based on the measured cycle period,
    /// providing faster response to market changes than traditional moving averages.
    /// </remarks>
    public double[] MAMA => Real0;
}
