// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents an exception that is thrown when the end index is out of range.
/// </summary>
[Serializable]
public class OutOfRangeEndIndexException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OutOfRangeEndIndexException"/> class.
    /// </summary>
    public OutOfRangeEndIndexException()
        : base("End index is out of range")
    {
    }
}
