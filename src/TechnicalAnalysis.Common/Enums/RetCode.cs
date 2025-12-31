// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents the return codes for various functions in the TechnicalAnalysis library.
/// </summary>
/// <remarks>
/// This enum contains only the error codes that are actively used in the library.
/// Legacy error codes from the original TA-Lib C library that are not applicable
/// to this .NET implementation have been removed.
/// </remarks>
public enum RetCode
{
    /// <summary>
    /// Operation completed successfully.
    /// </summary>
    Success = 0,

    /// <summary>
    /// Bad parameter provided.
    /// </summary>
    BadParam = 2,

    /// <summary>
    /// Start index is out of range.
    /// </summary>
    OutOfRangeStartIndex = 12,

    /// <summary>
    /// End index is out of range.
    /// </summary>
    OutOfRangeEndIndex = 13,

    /// <summary>
    /// Internal error occurred.
    /// </summary>
    InternalError = 5000
}
