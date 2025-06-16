// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the True Range (TR) indicator calculation.
/// True Range is a volatility measure that captures the greatest of: current high minus low, absolute value of current high minus previous close, or absolute value of current low minus previous close.
/// </summary>
public record TrueRangeResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrueRangeResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated True Range values.</param>
    public TrueRangeResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of True Range values.
    /// Each value represents the greatest of: (High - Low), |High - Previous Close|, or |Low - Previous Close|.
    /// This captures volatility including gaps between trading sessions.
    /// </summary>
    public double[] Real { get; }
}
