// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Functions;

/// <summary>
/// Represents the result of the Money Flow Index (MFI) indicator calculation.
/// </summary>
/// <remarks>
/// The Money Flow Index is a momentum indicator that incorporates both price and volume 
/// data to measure buying and selling pressure. Often referred to as a volume-weighted RSI, 
/// MFI oscillates between 0 and 100. Values above 80 typically indicate overbought conditions, 
/// while values below 20 indicate oversold conditions. The indicator is particularly useful 
/// for identifying potential reversals and divergences between price and volume flow.
/// </remarks>
public record MfiResult : IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MfiResult"/> class.
    /// </summary>
    /// <param name="retCode">The return code indicating the success or failure of the calculation.</param>
    /// <param name="begIdx">The index of the first valid data point in the output array.</param>
    /// <param name="nbElement">The number of valid data points in the output array.</param>
    /// <param name="real">The array containing the calculated MFI values.</param>
    public MfiResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    /// <summary>
    /// Gets the array of Money Flow Index values.
    /// </summary>
    /// <value>
    /// An array of doubles representing the MFI values, ranging from 0 to 100. 
    /// Values above 80 suggest overbought conditions and potential selling opportunities, 
    /// values below 20 suggest oversold conditions and potential buying opportunities. 
    /// Divergences between MFI and price action can signal potential trend reversals.
    /// </value>
    public double[] Real { get; }
}
