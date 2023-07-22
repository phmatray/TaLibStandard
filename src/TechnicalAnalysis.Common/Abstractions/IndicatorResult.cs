// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents an abstract base class for technical indicators.
/// </summary>
public abstract record IndicatorResult
{
    /// <summary>
    /// Initializes a new instance of the IndicatorBase class.
    /// </summary>
    /// <param name="retCode">The return code indicating the status of the indicator calculation.</param>
    /// <param name="begIdx">The beginning index of the calculated output series.</param>
    /// <param name="nbElement">The number of elements in the calculated output series.</param>
    protected IndicatorResult(RetCode retCode, int begIdx, int nbElement)
    {
        RetCode = retCode;
        BegIdx = begIdx;
        NBElement = nbElement;
    }

    /// <summary>
    /// Gets the return code indicating the status of the indicator calculation.
    /// </summary>
    public RetCode RetCode { get; }

    /// <summary>
    /// Gets the beginning index of the calculated output series.
    /// </summary>
    public int BegIdx { get; }

    /// <summary>
    /// Gets the number of elements in the calculated output series.
    /// </summary>
    public int NBElement { get; }
}
