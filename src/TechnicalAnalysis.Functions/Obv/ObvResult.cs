// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the On Balance Volume (OBV) indicator calculation.
/// </summary>
/// <remarks>
/// OBV is a momentum indicator that uses volume flow to predict changes in stock price.
/// It maintains a running total of volume, adding volume on up days and subtracting
/// volume on down days. The theory is that volume precedes price movement, so if a
/// security is seeing increasing OBV, it is a signal that volume is supporting the
/// price movement. Divergences between OBV and price can signal potential reversals.
/// </remarks>
public record ObvResult : SingleOutputResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObvResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated OBV values.</param>
    public ObvResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement, real)
    {
    }
}
