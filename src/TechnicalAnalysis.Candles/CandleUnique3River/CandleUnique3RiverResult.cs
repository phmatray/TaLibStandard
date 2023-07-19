// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Candles;

/// <summary>
/// 
/// </summary>
public record CandleUnique3RiverResult : IndicatorBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="retCode">The return code indicating the status of the indicator calculation.</param>
    /// <param name="begIdx">The beginning index of the calculated output series.</param>
    /// <param name="nbElement">The number of elements in the calculated output series.</param>
    /// <param name="integers"></param>
    public CandleUnique3RiverResult(RetCode retCode, int begIdx, int nbElement, int[] integers)
        : base(retCode, begIdx, nbElement)
    {
        Integers = integers;
    }

    /// <summary>
    /// 
    /// </summary>
    public int[] Integers { get; }
}
